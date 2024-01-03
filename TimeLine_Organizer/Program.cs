using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using System.Windows.Forms;

class TimeLine_OrganizingManager
{
    static void Main(string[] args)
    {
        string exePath = AppDomain.CurrentDomain.BaseDirectory;
        string sourceFolderPath = Path.Combine(exePath, "Pictures");
        string destinationFolderPath = Path.Combine(exePath, "Sorted");
        string failedFolderPath = Path.Combine(destinationFolderPath, "Failed");

        Directory.CreateDirectory(destinationFolderPath); 
        Directory.CreateDirectory(failedFolderPath); 

        var imageExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };   // 흔하게 사용하는 확장자

        var imageFiles = Directory.GetFiles(sourceFolderPath, "*.*", SearchOption.AllDirectories)
            .Where(file => imageExtensions.Contains(Path.GetExtension(file)))
            .Select(filePath => new FileInfo(filePath))
            .Select(fileInfo => new
            {
                FileInfo = fileInfo,
                DateTaken = GetDateTakenFromImage(fileInfo.FullName),
                IsDateTakenAvailable = GetDateTakenFromImage(fileInfo.FullName) != null
            })
            .OrderBy(file => !file.IsDateTakenAvailable)
            .ThenBy(file => file.DateTaken ?? file.FileInfo.CreationTime)
            .ToList();

        int index0 = 0, index1 = 0;
        int failedCount = 0;

        foreach (var file in imageFiles)
        {
            try
            {
                string newFileName;
                string datePart = file.IsDateTakenAvailable ? file.DateTaken.Value.ToString("yyyyMMdd") : file.FileInfo.CreationTime.ToString("yyyyMMdd");
                string prefix = file.IsDateTakenAvailable ? "0_" : "1_";
                int index = file.IsDateTakenAvailable ? index0++ : index1++;

                newFileName = $"{prefix}{index}_{datePart}_{file.FileInfo.Name}";

                string newFolderPath = Path.Combine(destinationFolderPath, file.IsDateTakenAvailable ? file.DateTaken.Value.ToString("yyyy_MM") : file.FileInfo.CreationTime.ToString("yyyy_MM"));
                Directory.CreateDirectory(newFolderPath);
                string newFilePath = Path.Combine(newFolderPath, newFileName);

                File.Copy(file.FileInfo.FullName, newFilePath, overwrite: true); // 파일 복사
            }
            catch
            {
                failedCount++;
                try
                {                    
                    string failedFilePath = Path.Combine(failedFolderPath, file.FileInfo.Name);
                    File.Copy(file.FileInfo.FullName, failedFilePath, overwrite: true);
                }
                catch
                {
                    // ##
                    // Failed 폴더에 복사하는 데 실패한 경우 추후 개발
                }
            }
        }

        // 결과 메시지 표시
        if (failedCount == 0)
        {
            MessageBox.Show("모든 이미지 파일 정렬에 성공했습니다.!", "결과", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show($"{failedCount}개의 파일은 정렬 & 복사에 실패했습니다. \nFailed 폴더를 참조해주세요.", "결과", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private static DateTime? GetDateTakenFromImage(string path)
    {
        try
        {
            using (var image = Image.Load(path))
            {
                var profile = image.Metadata.ExifProfile;
                if (profile != null)
                {
                    var dateTimeOriginal = profile.Values.FirstOrDefault(v => v.Tag == ExifTag.DateTimeOriginal);
                    if (dateTimeOriginal != null)
                    {
                        var dateTimeString = dateTimeOriginal.ToString();
                        if (!string.IsNullOrEmpty(dateTimeString))
                        {
                            return DateTime.ParseExact(dateTimeString, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                    }
                }
            }
        }
        catch
        {
            //##
            // 이미지 로드 실패 또는 EXIF 데이터 없음 
            // 추후 필요하면 개발
            return null;
        }
        return null;
    }
}