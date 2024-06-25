# wd_tam_ride

Modification of [Project Westdrive's original "AVAS" VR city ride](https://gitlab.com/fnnezami/project-westdrive/-/tree/MS-Wissenschaft?ref_type=heads) to [assess self-driving car acceptance using VR by Farbod Nosrat Nezami and Maximilian A. Wächter](https://ieeexplore.ieee.org/document/9781604).
This optimized modification allows simultaneous recording of head-tracking, eye-tracking, and EEG data while performing the experimental task.

This modification would not have been possible without the help of my colleague [Debora Nolte](https://github.com/debnolte).

![Westdrive Logo](https://gitlab.com/farbod69/project-westdrive/raw/master/westdrive%20logo.svg)

![Westdrive Version](https://img.shields.io/badge/Version-2.0-green.svg)
![Main Branch](https://img.shields.io/badge/Stable%20Branch-Master-brightgreen.svg)

## Introduction
### Important Notice:
For better ease of use we have devided the project into two seperate repositories, one containing 3d assets and model called Westdrive Assets Foundation and the other
for functionalities of Westdrive which is called Westdrive Core. One can use these two repositories combined or separetely to create their own simulation outside the scope of 
senarios existing in this version of Westdrive. 

you can find the [Westdrive Assets Foundation](https://gitlab.com/farbod69/westdrive-asset-foundation) here : https://gitlab.com/farbod69/westdrive-asset-foundation
and [Westdrive Core](https://gitlab.com/farbod69/westdrive-core) here : https://gitlab.com/farbod69/westdrive-core
## Demo Video
[![Demo Video](https://img.youtube.com/vi/IJF_sG5EElY/0.jpg)](https://www.youtube.com/watch?v=IJF_sG5EElY)

## Hardware Requirements

### Minimum Requirements
*  Intel Core i7 7th Generation
*  16 Gb RAM
*  Geforce GTX 1070Ti
*  Operating System: Windows 10 home 

### Sugessted Requirements
*  Intel Core i7/i9 8th Generation or newer
*  16 Gb RAM
*  Geforce GTX 1080Ti or better
*  Operating System: Windows 10 home 

---
Project Westdrive has been developed and tested on following Hardwares:

System 1:
![CPU](https://img.shields.io/badge/CPU%3A-CPU--Intel%20Xeon%20W--2133%20%40%203.60%20GHz-green.svg)
![RAM](https://img.shields.io/badge/RAM%3A-16%2C0%20GB-green.svg)
![Graphics Card](https://img.shields.io/badge/GPU%3A-Nvidia%20Geforce%20RTX%202080%20Ti-green.svg)
![OS](https://img.shields.io/badge/OS%3A-Microsoft%20Windows%2010%20Pro-green.svg)
![Performance Quality](https://img.shields.io/badge/Performance%3A-Good-brightgreen.svg)

---
System 2:
![CPU](https://img.shields.io/badge/CPU-Intel%20Xeon%20E5--1607%20v4%20%40%203.10GHz-green.svg)
![RAM](https://img.shields.io/badge/RAM%3A-32%2C0%20GB-green.svg)
![Graphics Card](https://img.shields.io/badge/GPU%3A-Nvidia%20Geforce%20GTX%201080%20Ti-green.svg)
![OS](https://img.shields.io/badge/OS%3A-Microsoft%20Windows%2010%20Pro-green.svg)
![Performance Quality](https://img.shields.io/badge/Performance%3A-acceptable-yellowgreen.svg)

## Software requirements

![Unity Version](https://img.shields.io/badge/Unity%20version%3A-2019.1.0f2-blue.svg)
![dot net compatibiliyy](https://img.shields.io/badge/.Net%20API%20Level%3A-4.xx-blue.svg)
![SteamVR Plugin](https://img.shields.io/badge/SteamVR%20Plugin%20Version%3A-2.2.0-green.svg)
![Render Pipeline](https://img.shields.io/badge/Render%20Pipeline%3A-Lightweight%20Render%20Pipeline-yellow.svg)

## Testing Releases:

- You need only latest Nvidia drivers and Steam VR
- the project has been tested on Nvidia 2080 Ti but should work with the minimum of GTX 1070 
- This version includes a connection to a web-based questionnaire. Since in this release, the questionnaire is not included. that part will be skipped. 
- the current version is based on the German language. This can easily be changed by changing the language to "ENG" in the config.ini file however part of the embedded audios for this release is only in German.

Note: 
The executable release is meant to be a showcase of Westdrive capabilities. Westdrive is meant to be customized and built for your specific needs. So we recommend you to download the code and build it yourself after implementing your own scenarios.

Note:
We still consider Westdrive in beta phase, we are using it at its current state to gather data for our project, yet we are constantly working on the code to improve its stability and add new functionalities.

## Builded version
you can download the standalone version [here](https://drive.google.com/file/d/1bBagKateS1WYV0HRvFxZbwWId148Rayk/view?usp=sharing)

## Build prepration
in the following section, it is explained how you can clone and improt the project for build and developement inside Unity environment.
### Step one: Preparing Unity
please [download](https://unity3d.com/get-unity/download) the corresponding version Unity and install it on your machine. It is highly recommended to 
download and install Unity through [Unity Hub](https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe?_ga=2.187579435.2096600450.1550663193-640931691.1544444769).
It is easier to manage various installations of Unity when using Unity Hub. You can find more information on Unity Hub [here](https://docs.unity3d.com/Manual/GettingStartedUnityHub.html).
#### notice:

> Please always make sure you are using the unity version mentioned here to ensure correct build and functionality of Westdrive. 

### Step two: cloning the project
First make sure you have installed a git client on you machine. If you need one you can find many of them online. Alternatively you can just [download](https://desktop.github.com/) and install
official Github client for Microsot Windows. 
> if you just want to use Project westdrive you can alternatively dowload the project as an archive file (see below), however to contribute to the project or make your own forks you will need a GitLab [account](https://gitlab.com/users/sign_in#register-pane).

## Tutorial Videos:
| Subject | Link | comments |
| ------ | ------ | ------ | 
| Project Overview | [Westdrive project overview ](https://drive.google.com/open?id=1UHhi1XRZ67xlvVx03mMJhJum_taruspI) | including build process and configurations |
| City AI Overview | [Westdrive City AI part 1](https://drive.google.com/open?id=1xM9M7P7LeXEW1AsxhxT3prL8Cmu_GXp2) | City AI toolkit overview, creating paths |
| City AI make a dynamic object | [Westdrive City AI part 2](https://drive.google.com/open?id=16I3TngkdJMpwlc7Fs_fsP50ofONlsR-z) | preparing cars and making dynamic objects using City AI toolkit |
| Generic API | [Westdrive generic API](https://drive.google.com/open?id=1ELYYJx6NZhTF2Bo_kSFrqOeeV6EuS9u8) | Serialization, Traking, IO and Net|


## Third party assets
in the following secion all used assets with their links in the unity asset sote, with their corresponding functionality is listed.
#### note:

> Assets are separeted in taged with paid and free, and also essential or optional. 

#### note:

> If you plan to use the paid assets in other projects, please make sure you purchase them for your organization in the Unity asset store 

#### note:

> optional assets are usualy 3d assets that can be replaced by your own designs or other 3d models. 

### List of assets
| Asset Name | Link on Asset Store | Description | Paid / Free | Essentail / Optional |
| ------ | ------ | ------ | ------ | ------ |
| SteamVR | [SteamVR Plugin](https://assetstore.unity.com/packages/tools/integration/steamvr-plugin-32647) | main api to use HTV Vive/ Vive Pro HMDs in Unity3d | free | ![note:](https://img.shields.io/badge/note-Essential-yellow.svg) |
| *MeshKit | [MeshKit - Mesh Decimation, Separation, Combining and Editing Tools](https://assetstore.unity.com/packages/tools/utilities/meshkit-mesh-decimation-separation-combining-and-editing-tools-39794) | used to simplify and combine mesh structures in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |
| Book Of The Dead | [Book Of The Dead: Environment](https://assetstore.unity.com/packages/essentials/tutorial-projects/book-of-the-dead-environment-121175) | published by Unity Technologies, trees and nature 3d models are used in city environment | free | ![note:](https://img.shields.io/badge/note-Essential-yellow.svg)|
| **SUV03 | [Unlock Sport Utility Vehicle 03 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-sport-utility-vehicle-03-118124) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)| 
| **EC02 | [Unlock economy car #02 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-economy-car-02-119661) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **EC03 | [Unlock economy car #03 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-economy-car-03-120628) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **SS07 | [Unlock super sport car #07 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-super-sports-car-07-109989) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **EC01 | [Unlock economy car #01 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-economy-car-01-119214) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **SS05 | [Unlock super sport car #05 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-super-sports-car-05-109108) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **SC05SI | [Unlock sport car #05 SI ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-sports-car-05-si-107946) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **SC05 | [Unlock economy car #05 ](https://assetstore.unity.com/packages/3d/vehicles/land/unlock-sports-car-05-107944) | one of the car assets used in the project | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| +SALSA With RandomEyes| **Deprecated** | used to synconase taxi driver lips and voice | Paid | ![note:](https://img.shields.io/badge/note-Deleted-red.svg)|
| Truck | [Single Detailed Truck](https://assetstore.unity.com/packages/3d/vehicles/land/single-detailed-truck-895) | detailed truck with trailer | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |
| Tocus | [3D Low Poly Car For Games (Tocus)](https://assetstore.unity.com/packages/3d/vehicles/land/3d-low-poly-car-for-games-tocus-101652) | one of the assets used as parked cars | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| low poly car 1 | [Low Poly Destructible 2 Cars no. 8](https://assetstore.unity.com/packages/3d/vehicles/land/low-poly-destructible-2-cars-no-8-45368) | one the assets used as parked cars | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| **European Buildings | [European Building Collection Volume 1](https://assetstore.unity.com/packages/3d/environments/urban/european-building-collection-volume-1-20676) | part of buildings in the city | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |
| **City building set | [City Building Set 1](https://assetstore.unity.com/packages/3d/environments/urban/city-building-set-1-50422) | part of buildings in the city | paid | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |
| Tractor | [Farm Machinery: Low Poly Tractor and Planter](https://assetstore.unity.com/packages/3d/vehicles/land/farm-machinery-low-poly-tractor-and-planter-94533) | tracktor has been used in the city | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |
| Sport Car | [Sport Car - 3D model](https://assetstore.unity.com/packages/3d/characters/sport-car-3d-model-88076) | used as parked car in the city | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| GR3D | [GR3D Sports Utility Vehicle SUV 091614SSUV](https://assetstore.unity.com/packages/3d/vehicles/land/gr3d-sports-utility-vehicle-suv-091614ssuv-25545) | used as parked car in the city | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg)|
| Low Poly Street Pack | [Low Poly Street Pack](https://assetstore.unity.com/packages/3d/environments/urban/low-poly-street-pack-67475) | used for city street and construction sites | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |
| Nature Starter Kit 2 | [Nature Starter Kit 2](https://assetstore.unity.com/packages/3d/environments/nature-starter-kit-2-52977) | used for nature of city along side book of the dead assets | free | ![note:](https://img.shields.io/badge/note-Essential-yellow.svg)|
| Free HDR Sky | [Free HDR Sky](https://assetstore.unity.com/packages/2d/textures-materials/sky/free-hdr-sky-61217) | used as the skybox of the city | free | ![note:](https://img.shields.io/badge/note-Essential-yellow.svg)|
| Town Houses | [Town Houses Pack](https://assetstore.unity.com/packages/3d/environments/urban/town-houses-pack-42717) | part of city buildings | free | ![note:](https://img.shields.io/badge/note-Optional-green.svg) |

#### *
> This asset is used once and will be deleted once the city is updated with our assets but will be in use for the next year.

### ** 
> these assets are part of the city now but they will be replaced with the assets created at our team during the course of next year and will be deleted from our repository then

### + 
> this asset is deprecated, we have deleted its functionality since it was not visible in VR and replaced it with normal audio output from Taxi driver. This asset will be removed from our repository on our next commit.

## Avatars and animations:
Avaratars and animations in westdrive is created by us using Adobe Mixamo and Fuse cc. At the momenet westdrive is using avatars of our own creation using mentioned tools but due to 
their complex mesh anatomy we are replacing them with simpler low poly avatars created by us in blender soon. 

### acknowledgement to creators and team assistants

Our acknowledgement goes to creator of all free and paid assets mentioned above, Adobe, Unity Technologies and Blenders for their tools as well as following persons who helped us in creating and maintaining Westdrive
*  Phillip Spaniol - main graphic designer in out team who is creating out new 3d models
*  Johannes Maximilian Pingle - helped commenting part of the codes
*  Sumin Kim - helped commenting part of the codes
*  Fabian Radke - working of ANN to convert head tracking data to eyetracking data withing Westdrive
*  Prof. Dr. Peter König - main supervisor of the project
*  prof. Dr. Gordon Pipa - second supervisor of the project
*  Stahlwerk Stiftung Georgsmarienhütte, University of Osnabrück and Deutsche Forschungsgemeinschaft for their financial support

### current term of use
You are free to share, change and use Westdrive in whatever maner you like as long as you accept the following conditions:

-Westdrive is an open source city simulation for self driving cars and similiar experiments. It is made available for scientists and anyone who is interested in research in an 
Virtual environement. Therefore any financial use of this tool is prohibited. 

-Assets presented here are mainly free assets from unity asset store which can be used in other projects, however if you plan to use assets that are paid please purchase them for 
your organization from the unity asset store. Developing team of Westdrive does not accept any responsibility regarding this matter and we are strictly against piracy. 

#### announcement:

> We have started to replace most of the 3d model used in the project with those of our own creation. You are free to used assets used by us in any way you desire. However please note 
that we will soon start to delete paid and third party assets from the project as we replace them

## License
All Documentation content that resides under the doc/ directory of this repository is licensed under Creative Commons: [![License: CC BY-NC-SA 4.0](https://licensebuttons.net/l/by-nc-sa/4.0/80x15.png)](https://creativecommons.org/licenses/by-nc-sa/4.0/)
