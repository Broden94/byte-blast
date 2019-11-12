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

## Initial Unity Project Setup

* Pull origin/master
* Go to Build Settings and set Build Platform to Android

## Useful Links

* [GitHub Formatting](https://help.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax)