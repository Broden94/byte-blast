# Byte Blast - Technical Design

## Code Style

### Naming Conventions for Variables and Methods

* Public variables - PublicVariable
* Private variables - _privateVariable
* Local parameter - localParameter
* Public method - PublicMethod()
* Private method - PrivateMethod()

### Whitespaces

* Use spaces instead of tabs (configure your IDE accordingly)
* Use two spaces for indentations

## State Machines

State machines are used to track particular aspects of the app/game. They may contain methods and properties to set and return states, but actual implementation is controlled by an event handler, meaning use of a state machine is indirect.

Currently contemplating whether or not there should be a StateManager base class that the below state machines will derived from.

### AppStateManager

Controls the state of the app as a whole. The AppStateManager will be present in all scenes of the app.

* Title
* Loading (?)
* Tutorial
* Game
* Ad

### GameStateManager

Controls the state of the game session. The GameStateManager will be present only in the game scene.

* Countdown
* Playing
* Paused
* Ended

### PlayerState

Controls the state of the player. 

* Movement
  * Moving
  * Stopped
  * Dead

* Action (move this to joystick?)
  * Shooting
  * Throwing

## Event Handling

Events will control the flow of the app. Methods that are subscribed to certain events will be notified/broadcasted to when that event is triggered.

For example, say there are two methods: ShowPauseMenu() and HidePauseMenu(). ShowPauseMenu() is subscribed to the event OnPause while HidePauseMenu() is subscribed to the event OnPlay. The pause button triggers the OnPause event, which will then broadcast it to the class that handles the ShowPauseMenu() method as well as any other classes that have methods subscribed to the OnPause event. In the same way, the exit button in the pause menu triggers the OnPlay event, which will then broadcast it to the class that handles the HidePauseMenu() method and any other classes whose methods are subscribed to the OnPlay event.

Handling events this way will execute multiple methods from a variety of classes, thus allowing ease of tracking. Using an event handler also helps with controlling state machines.

As of 11/17, the project will implement the observer design pattern. If time allows it, shifting to a pub-sub event bus is desirable.

## Character Classes

### Main Character

#### Controls

##### Movement

The main character is controlled via virutal joystick (imported asset Joystick Pack) for movement placed at the lower lefthand corner of the screen. The input from the joystick allows the main character to move forward; if there is no input (aka the player lifted their finger off the joystick) the main character's rotation is left off where the joystick input was last detected.

##### Shooting

A shooting button is placed at the lower righthand corner of the screen. Its y-position matches that of the virtual joystick. Tapping on the shooting button activates bullets to fire in the main character's forward direction. Holding down the shooting button shoots bullets at a constant pace slightly slower than the speed of repeatedly tapping on the shooting button. Each bullet will last for three seconds

#### Properties

  * public bool IsAlive - Returns the health of the player. If above 0, return true; otherwise, return false.

### Enemies

This serves as a base class. Each derived Enemy class has their own, distinct behavior

#### Properties

  * static int EnemyCount - Returns the number of current instantiated enemies

## User Interfaces

### Pause Menu

* Available when the game state is playing
* Accessible by pause button in the top corner of the screen
* Contents
  * Resume
  * Restart
    * Confirmation screen - Sets the game state back to countdown
  * Settings (optional)
    * Volume
  * Return to main
    * Confirmation screen

### End Screen

* Automatically appears when the game session is over
* Contents
  * Player stats (non-interactive)
  * Replay - Sets the game state back to countdown
  * Return to main
    * Confirmation screen

### Main Menu

* Play
* Settings (optional)
* Leaderboard (optional)