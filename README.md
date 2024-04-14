# README.md

## Introduction

In this project, we are developing a Mixed Reality (MR) Remote-Control (RC) car for Microsoft's HoloLens 2. The RC car and its controls are holographic, providing users
with an immersive and interactive experience within their physical environment. The user will be able to control the car with a holographic remote control.

The application utilizes spatial mapping to map the user's physical environment and
interact with real-world objects, showcasing realistic collision detection and environmental
interaction. For example, the virtual holographic car in the user's view will not be able to pass
through walls or other objects in their real world. Instead, it would cause the RC car to stop or
bounce upon impact.

## Features

The project includes the following features:

1. **Spatial Mapping**: The application uses spatial mapping to map the user's physical environment and interact with real-world objects.
2. **Hand Tracking**: The user can control the RC car using a holographic remote visualized by the HoloLens 2.
3. **Collision Detection**: The RC car will stop or bounce upon impact with real-world objects in the user's environment.
4. **Environmental Interaction**: The user can interact with the RC car using pinch gestures.

## Setting up the Application on the HoloLens 2

### 1. Enable Developer Mode on HoloLens 2

- Go to **Settings**.
- Navigate to **Update & Security**.
- Select **For Developers**.
- Turn on the following options:
  - **Developer Mode**
  - **Device Portal**

### 2. Unity Setup

- Open Unity.
- Go to **File** > **Build Settings**.
- Choose **Universal Windows Platform (UWP)** and make sure the settings are the same as shown below:

  <img src="./images/image1.png" width="500">

### 3. Build the Project

- Click build and select a folder to save the project.
- Locate the generated `.sln` file.
- Click the `.sln` file to open the project in Visual Studio 2022.

  <img src="./images/image2.png" width="500">

### 4. Connect HoloLens 2 to Computer

- Connect the HoloLens 2 device to your computer via USB.

### 5. Configure Visual Studio

- In Visual Studio, select **Master**, **ARM64**, and **Device** as the build target.

  <img src="./images/image3.png" width="500">

### 6. Pair HoloLens with Visual Studio

- Run the project in Visual Studio.
- Visual Studio will prompt for a pairing code.
- Go back to HoloLens **Settings** > **Update & Security** > **For Developers** > **Pair**.
- Enter the pairing code displayed in Visual Studio (case-sensitive).

  <img src="./images/image4.png" width="500">

### 7. Build and Deploy the App

- Once paired, build the app in Visual Studio.
- Wait for the app to launch on the HoloLens 2.

### Troubleshooting

Error messages and possible solutions:

1. **Error**: `DEP6957: Failed to connect to device`

   - Ensure the correct remote authentication mode is specified in the project debug settings.
   - Verify that the USB device connectivity is enabled on your development machine.
   - Ensure that all the necessary development tools are installed on your development machine.
   - [Microsoft Mixed Reality Tools Installation Guide](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/install-the-tools)

## Usage and Controls

### Using the Menu

When you first start the application, you must remap the room. To do this, hold your left or right palm out in front of the HoloLens. A menu will appear with several buttons. Press the "Remap Room" button to remap the room. Once the room is remapped, you can press the "Reset Car" button to reset the car's position.
<img src="./images/image5.png" width="500">

### Controlling the Car

The car is controlled by the remote’s sliders. You can either pinch the sliders or push the sliders with your fingers.
<img src="./images/remote.png" width="500">

### Manipulating the car model

The car model can be grabbed similar to how you would grab an object in real life. You can
resize the car by pinching two corners of the object and moving your hands together or apart.
Resizing can be done like the image below but with two hands.

<img src="./images/image7.png" width="500">

## Video Demo
Youtube Link: https://youtu.be/1Fcv7xE1fmE
## Intended Users

### 1. Students and Educators

Students (ages 13 or older) and educators can use the project as an educational tool to learn about augmented reality, spatial computing, and robotics.

### 2. General Consumers

General consumers who are interested in exploring new and immersive experiences offered by mixed reality technology can benefit from the project.

### 3. Unity Developers

Developers interested in learning Unity development for mixed reality applications may find value in the project's codebase, experimenting with new features, or contributing to its development.

### 4. HoloLens Developers

HoloLens developers may see the project as a source of inspiration or reference for incorporating spatial mapping, hand tracking, and other HoloLens features into their own projects.

### Warning

Potential HoloLens users should cross-reference Microsoft’s Product Safety Warnings and Instructions to ensure that they are safely using the product. The list of product safety warnings can be found [here](https://support.microsoft.com/en-gb/topic/product-safety-warnings-and-instructions-726eab87-f471-4ad8-48e5-9c25f68927ba).

## Asset Sources

### Car Model

- [ARCADE: FREE Racing Car](https://assetstore.unity.com/packages/3d/vehicles/land/arcade-free-racing-car-161085)
