This is the repository for the Unity implementation of the Body Swap project created by Sebastian Hoppe and Dumitru INSERT NAME.

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

## Connecting to the exo-skeleton
In order to use the Unity project with the exo-skeleton arm, they need to be connected to the same network.

**Important**: For instructions on how to setup the connection for the exo-skeleton, look at the github repository for that implementation [Link](https://github.com/MrDm1try/BodySwapRaspberry).

Locate the local IP adress of the device running the Unity project.
Locate the local IP adress of the Raspberry Pi on the exo-skeleton.

Open the script UdpHost.cs and edit the two variables \_hostIp and \_clientIp.
\_hostIp should be the IP adress of the Unity device.
\_clientIp should be the IP adress of the Raspberry Pi.



## Connecting to Photon Fusion

# Interface