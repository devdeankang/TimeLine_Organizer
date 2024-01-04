# TimeLine_Organizer (시간 순으로 이미지 파일 정렬)

**이 프로젝트는 지정된 폴더 내의 이미지 파일들을 촬영 날짜 또는 생성 날짜 순으로 정렬하고, 정렬된 파일들을 새로운 폴더에 복사하는 도구입니다. 이 프로그램은 .NET을 사용하여 개발되었으며, 윈도우 환경에서 실행됩니다.**





# 📄 목차 (Contents)

- [배포 전략](#-배포-전략-deployment-strategy)
- [시작하기](#-시작하기-getting-started)
  - [전제 조건](#전제-조건-prerequisites)
  - [설치 및 실행](#설치-및-실행-installation-and-execution)
- [사용 방법](#-사용-방법-usage)
- [개발 환경](#-개발-환경-development-environment)
- [추후 개발 목표](#-추후-개발-목표--future-development-goals)










## 🎈시작하기 (Getting Started)

### 전제 조건 (Prerequisites)

- .NET 6 SDK 또는 이상

### 설치 및 실행 (Installation and Execution)

1. [릴리즈 페이지](https://github.com/devdeankang/TimeLine_Organizer/tree/Release)에서 최신 릴리즈 파일을 다운로드합니다.

2. 다운로드된 파일을 실행하여 프로그램을 시작합니다.

   

## 📜 사용 방법 (Usage)

**TimeLine_Organizer 사용법**

1. 원하는 사진 파일들(jpg, jpeg, png, gif, bmp, tiff)을 `@path/Pictures` 폴더에 이동시킵니다. 이 폴더는 하위 디렉토리를 포함할 수 있으나, 압축 파일은 해제된 상태여야 합니다.
2. `TimeLine_Organizer.exe` 프로그램을 실행합니다.
   - Pictures 폴더의 원본 파일은 변경되지 않습니다.
   - 정렬에 성공한 파일은 "Sorted" 디렉토리에, 실패한 파일은 "Failed" 디렉토리에 복사됩니다.
   - 성공한 파일은 연도별, 월별 디렉토리로 분류됩니다.
   - 촬영 날짜 기준으로 정렬된 파일은 파일명 앞에 "0_", 파일 생성 날짜 기준으로 정렬된 파일은 "1_"로 시작합니다.
   - 예시: "0_20240101_파일명.png" (촬영 날짜 기준 정렬)

**주의**: 절대 경로 내에 위치한 Pictures 디렉토리는 수정하거나 변경하지 마세요.





## 🛠 개발 환경 (Development Environment)

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white) ![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

- ImageSharp 라이브러리


  

## ⛏ 배포 전략 (Deployment Strategy)

이 프로젝트는 Self-Contained Deployment (SCD) 방식으로 배포됩니다. 이는 하나의 실행 파일로 라이브러리를 패키징하여 추가적인 설치 과정 없이 바로 애플리케이션을 실행할 수 있게 합니다. 초기 프로젝트의 배포를 위해 인스톨러를 거치는 과정 대신 직접 실행 가능한 방식을 선택했습니다. SCD와 인스톨러 방식의 차이에 대한 더 자세한 설명은 [이 블로그](https://gameclientdevelop.tistory.com/37)에서 확인할 수 있습니다.




## ⚙ 추후 개발 목표  (Future Development Goals)

이 프로젝트는 지속적인 발전을 목표로 하고 있으며, 다음과 같은 기능들을 추가할 계획입니다:

1. **멀티미디어 컨텐츠 지원**: 현재는 이미지 파일만을 지원하지만, 향후 동영상과 오디오 파일들도 포함하여 다양한 멀티미디어 컨텐츠를 정렬할 수 있도록 기능을 확장할 예정입니다. 이를 통해 사용자는 하나의 도구로 다양한 파일 형식의 정렬을 수행할 수 있게 됩니다.

2. **WPF 기반 UI 개발**: 사용자 경험을 향상시키기 위해 WPF(Window Presentation Foundation)를 사용하여 그래픽 사용자 인터페이스를 개발할 계획입니다. 이 UI를 통해 사용자는 파일 관리를 더 직관적으로 수행할 수 있게 됩니다.

3. **인스톨러 제공**: 사용자의 편의성을 높이기 위해 인스톨러를 통한 프로그램 설치 방식을 도입할 예정입니다. 이를 통해 사용자는 프로그램 설치 및 관리를 더욱 쉽게 할 수 있게 됩니다.

이러한 목표들은 추후 사용자의 요구에 따라 조정될 수 있습니다. 
