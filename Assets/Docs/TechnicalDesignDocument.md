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

### AppStateManager
* Title
* Loading (?)
* Tutorial
* Game

### GameManager/GameStateManager

Controls the state of the game.

* Countdown
* InSession
* Paused
* Ended

### PlayerState
* Alive
* Dead

## Event Handling

Events will control the flow of the app. Methods that are subscribed to certain events will be notified/broadcasted to when that event is triggered.

For example, say there are two methods: ShowPauseMenu() and HidePauseMenu(). ShowPauseMenu() is subscribed to the event OnPause while HidePauseMenu() is subscribed to the event OnPlay. The pause button triggers the OnPause event, which will then broadcast it to the class that handles the ShowPauseMenu() method as well as any other classes that have methods subscribed to the OnPause event. In the same way, the exit button in the pause menu triggers the OnPlay event, which will then broadcast it to the class that handles the HidePauseMenu() method and any other classes whose methods are subscribed to the OnPlay event.

Handling events this way will execute multiple methods from a variety of classes, thus allowing ease of tracking. Using an event handler also helps with controlling state machines.

## Character Classes

### Player

#### 

#### Properties
  * public bool IsAlive - Returns the health of the player. If above 0, return true; otherwise, return false.



### Enemy
This serves as a base class. Each derived Enemy class has their own, distinct behavior

#### Properties
  * static int EnemyCount - Returns the number of current instantiated enemies