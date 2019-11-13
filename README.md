# byte-blast

This repo is for the game Byte Blast!

## Software/Tools

* Engine: Unity 2019.1.14f1
* IDE: Visual Studio Code
* VCS: Git, GitHub
* Project Management Tool: Trello
* Team Chat: Discord
* 3D Modeling: Blender
* Image Editing: Photoshop

## Git

Git is fun, except when it's not.

### Git-related Terms

* Local master branch = master
* Remote master branch = origin/master
* PR = "pull request"

### Git Workflow

1. Start from your master via GitHub Desktop
2. Pull the latest from origin/master
3. Create a new branch
4. Commit as many changes as you'd like on your new local branch
5. While on your new local branch, pull the latest from origin/master whenever new changes are made
6. Before pushing your new local branch to origin/master for a PR submission, be sure to pull the latest from origin/master
7. Push your new local branch to origin/master
8. Submit a PR via browser of your choice (most likely Chrome)
9. Repeat steps 4 to 7 as much as you'd like; the PR will automatically be updated with any commits pushed to origin/master
10. Once your PR is approved, merge your branch into origin/master
11. Do a happy dance!

More reading on the Gitflow workflow: https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow

### Git Branch Naming Convention

* Name your branch as new-branch, i.e. game-saves, player-jitter, enemy-teleportation, environment-textures, etc. This is called kabob case, meaning words are separated by dashes. Looks like one big kabob, mmm.
* If your branch is part of a specific feature, name your branch as feature/new-branch, i.e. feature/game-saves, bug/player-jitter, feature/enemy-teleportation, art-assets/environment-textures, etc.

## Building for Mobile (Android)

The following steps were taking from https://learn.unity.com/tutorial/building-for-mobile#5c7f8528edbc2a002053b4a2. Please note that your build device must run the latest version of Android for the below steps to work. If not, refer to the steps provided in the link.

### JDK (Java Development Kit) Installation

* Go to the Java website at https://www.oracle.com/technetwork/java/javase/downloads/index.html
* Download and install the most recent version of the Java Platform JDK

### Android SDK (Software Development Kit) Installation

* Go to the Android Developer website at https://developer.android.com/studio
* Navigate to the second half of the Android Developer website and locate the section called 'Command line tools only'
* Download the SDK tools package for your platform
* Unzip the downloaded file
* Store the directory in a memorable and accessible location on your computer. You will refer to the directory's path later (this will be mentioned under the 'Linking Android SDK Tools section).
* Open the directory that contains the Android SDK Tools and navigate to tools
* Double-click on the file 'android' to run

### Switching the Build Platform in Unity

* Open the Build Settings (File > Build Settings)
* Highlight 'Android' in the list of platforms
* Select Switch Platform at the bottom left-hand corner of the Build Settings window

### Configuring Player Settings in Unity

* Open the Player Settings (Edit > Project Settings > Player)
* Expand the section called 'Other Settings' and enter your bundle identifier. Use title casing format for the naming convention (ie: com.BriannaRodenborn.ByteBlast).

### Linking Android SDK Tools

* Open Preferences (Windows: Edit > Preferences, OSX: Unity > Preferences)
* Navigate to 'External Tools'
* For the Android SDK field, click Browse, navigate to where you put the directory containing Android SDK Tool, and click Choose.

### Prepping Your Android Device

This will enable Developer mode on an Android device.

* On your Android device, navigate to Settings > About phone (or About tablet if building on a tablet).
* Scroll to the bottom and tap Build number seven times. A popup will appear, confirming that you are now a developer.
* Navigate to Settings > Developer options > Debugging and enable USB debugging.

### Build an Android Project Using Unity

* Connect your Android device to your computer with a USB cable
* You may see a prompt asking to confirm to enable uSB debugging on the device. If so, select OK.
* In Unity, open the Build Settings (File > Build Settings)
* Click Build And Run
* Select the location you wish to save your build. If in the local repo, save the build in the Builds folder.
* When naming builds, use a mix of title casing and snake casing for the naming convention (ie: ByteBlast_Build_01).

## Useful Links

* [GitHub Formatting](https://help.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax)
* [Unity - Building for Mobile](https://learn.unity.com/tutorial/building-for-mobile#5c7f8528edbc2a002053b4a2)