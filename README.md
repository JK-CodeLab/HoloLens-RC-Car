# README.md

## Introduction

This repository contains the source code for the HoloLens 2 application developed for the [HoloLens 2](https://www.microsoft.com/en-us/hololens/buy). This application allows a user to map their surroundings and drive a holographic remote controlled car. The application uses the HoloLens 2's spatial mapping capabilities to create a 3D mesh of the environment. The user can then place the car on the mesh and drive it around using a holographic remote control.

## Users

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
