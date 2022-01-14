This is the repository for the Unity implementation of the Body Swap project created by Sebastian Hoppe and Dumitru Racicovschii.

The repository and readme for the Raspberry Pi implementation is located at https://github.com/MrDm1try/BodySwapRaspberry.

# Setup
This readme assumes that the user already has access to a fully built exo-skeleton.

The setup instructions is tested to work on both Windows and Linux. IOS is untested.

## Install

Clone the repository to a location of choice on your drive.

Install [UnityHub](https://unity.com/unity-hub).

When done, open UnityHub install the lastest version of Unity 2020 edition. The last version the project was tested on is 2020.3.7f1.

In UnityHub, click add, and find the cloned repository on your drive.

Select Unity 2020.x.x to use as the Unity Version.

The project can now be opened in Unity.

## Connecting to Photon Fusion
In order to use the networking functionality of Photon Fusion, you need to create an account on the website https://id.photonengine.com/en-US/Account/SignUp. It's free and allows for up to 20 concurrent users on the server at the same time. Any more and a paid plan will be needed.

On the dashboard, create a new App. The Photon Type should be "Photon Fusion". The rest of the options are arbitrary.

On the dashboard, copy the App-Id of the newly created App.

In Unity, navigate to: Assets->Photon->Resources->PhotonAppSettings.

Here replace the App Id Fusion with the id of the App created in the dashboard.

The Unity project should now be connected to the Photon cloud service.

## Connecting to the exo-skeleton
In order to use the Unity project with the exo-skeleton arm, they need to be connected to the same network.

**Important**: For instructions on how to setup the connection for the exo-skeleton, look at the github repository for that implementation [Link](https://github.com/MrDm1try/BodySwapRaspberry).

Locate the local IP adress of the device running the Unity project.  
Locate the local IP adress of the Raspberry Pi on the exo-skeleton.

Open the script UdpHost.cs and edit the two variables \_hostIp and \_clientIp.  
\_hostIp should be the IP adress of the Unity device.  
\_clientIp should be the IP adress of the Raspberry Pi.

Once the project is started and connected to Photon Fusion, it should try to connect to the exo-skeleton.

# Interface
![Fusion Menu](https://github.com/Hoppe2808/BodySwapUnity/blob/main/Pasted%20image%2020220114114804.png?raw=true)  
The image above show the first menu the user is met with, when starting the application. This is the default menu, that comes with a basic setup for Photon Fusion.

The only buttons to know to succesfully run this project is "Start Host (H)" and "Start Client (C)".

"Start Host (H)" will connect to the Fusion cloud as a host. This will enable the user access to all the menus that has been implemented in this project. "Start Client (C)" will connect to the Fusion cloud as a client, this will only be succesful if another user has connected as a host.

