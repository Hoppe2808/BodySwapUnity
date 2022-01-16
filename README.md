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
![[Pasted image 20220114114804.png]]
The image above show the first menu the user is met with when starting the application. This is the default menu that comes with a basic setup for Photon Fusion.

The only buttons to know to succesfully run this project is "Start Host (H)" and "Start Client (C)".

"Start Host (H)" will connect to the Fusion cloud as a host. This will enable the user access to all the menus that has been implemented in this project. "Start Client (C)" will connect to the Fusion cloud as a client, this will only be succesful if another user has connected as a host.

All the functionality implemented in this project is designed with the idea that exactly one Host and one Client is connected at all times.

## Main menu

![[Pasted image 20220114124853.png]]
When starting as a host, the menu shown above appears. This is the main menu of the application, where a user can navigate to the different functionality.

**Mirror**: Navigates to the menus needed for conducting the Mirror experiment.  
**Finding Borders**: Navigates to the menus needed for conducting the Border experiment.  
**Record Sequence**: Navigates to the menus needed for conducting Record Sequence experiment.

All of the buttons described above disables the menu, which means the application needs to be restarted in order to select another option.

![[Pasted image 20220114130015.png]]
This button, found in the upper left corner of the screen, releases the control the exo-skeletons have of each other. This means that the master exo-skeleton will no longer be able to control the follower exo-skeleton. A second click of the button reactivates the control.

## Mirror

![[Pasted image 20220114125335.png]]

The image above shows the menu a user is met with, when selecting the Mirror experiment.

**Switch Host**: Changes which of the exoskeletons are considered the master, and which is considered the follower.  

### Modes
The modes only functionality is logging. Clicking either of the buttons **Baseline 1**, **Mirror**, **Remote**, **Baseline 2** and **Start Sequence**, simply sends a message to the exo-skeletons to easier naivgate the logs.  
Read more about logging on the repository for the Raspberry Pi implementation [Link](https://github.com/MrDm1try/BodySwapRaspberry).

## Border
![[Pasted image 20220114130211.png]]
The menu for the Border experiment is very similar to that of the Mirror experiment. **Switch Host** is the same as in Mirror.

### Set Bounds
**Upper**: Stores the current rotation of the motors of the elbow joint of the hosts exo-skeleton as the upper boundary.
**Lower**: Stores the current rotation of the motors of the elbow joint of the hosts exo-skeleton as the lower boundary.
**Enable**: Enables the physical border functionality. This physically stops the rotation of the motors when the user tries to bend the exo-skeleton beyond the borders set by **Upper** and **Lower**. A second click will disable the physical border.
**Alert Start**: Enables the visual alert for crossing the border. When enabled the screen will turn red, when the border is crossed, to inform the user that it is crossed. A second click will disable the alert.
**Start Sequence**: Like with Mirror, this button is only used for logging, and sends a message to the exo-skeleton to navigate the logs.

## Record Sequence
![[Pasted image 20220114131112.png]]
![[Pasted image 20220114131356.png]]
![[Pasted image 20220114131427.png]]