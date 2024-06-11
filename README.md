# horrorgame
Start Scene File
MainMenuScene
How to Play
It must be a 3D Game Feel game!

The goal is to traverse around the map and collect 5 keys to unlock the map and escape, while also avoiding the ai controlled enemy. 
Supports a start menu, pause menu, win and lose scenes
Player loses when the enemy (a zombie) reaches the player
After pressing the Start Game button on the main menu, the player starts in a room with two doors with interactive buttons
The door on the right leads to the main area of the map where you can find all of the keys
The door on the left can be unlocked after collecting all 5 keys
Once the player opens the door on the left and enters, the player wins

Precursors to Fun Gameplay 

Locked doors indicate to the player that they should move around the environment and find something
The player’s flashlight will dim over time so batteries must be found around the map to keep vision clear
Starting area is a safe zone where the enemy can’t reach

3D Character/Vehicle with Real-Time Control

Humanoid main character uses root motion to avoid glitchy rotations
WASD for character turning and movement
Humanoid character is rigged with Ybot animations and blend tree is reconfigured to fit the movement for the game 

3D World with Physics and Spatial Simulation

Environment created with boundaries for the characters
Audio for player and enemy footsteps is included
Audio cues for when enemy begins to chase player
Keys are able to be picked up by the player and buttons can be interacted with to open doors

Real-time NPC Steering Behaviors / Artificial Intelligence

Humanoid characters have root motion
Zombie and spiders are AI controlled
Fluid animation

Polish

Start menu GUI
Pause menu to quit game

Known Problem Areas

Character movement and turning can be slow
UI elements shrink occasionally on build
Occasional clipping through walls/door
Character special animation when picking up key freezes movement

File Contributions

Nicole
The Adventurer Blake Character Asset
Character blendtree and animations
Battery Prefab
Flashlight Pointlight
Starting room props
Battery tutorial pop-up
Inventory
Scripts
ThirdPersonCamera.cs
FlashlightContoller.cs
BatteryPickup.cs
BatteryButton.cs
BatteryTutorial.cs
PlayerInventory.cs

Evan
Outer wall Game objects
Inner wall game objects
Outer and Inner wall materials
Game Lighting
Door Gameobject
Door open animation
Scripts
PlayerCasting.cs
DoorCellOpen.cs
DoorUnlock.cs
FlickLight.cs
DoorAnimation.cs
Updated BatteryPickup.cs
Torch Lighting
Horror School Prop Assets
Battery Objects
Key Objects

Brandon
KeyCollectible Prefab
EventManager and AudioEventManager
Audio - Player and enemy footsteps, ambient music, etc.
Various bug fixes
Scripts
KeyPickup.cs
PlayerInventory.cs
EventManager.cs
AudioEventManager.cs
playerFootstepEmitter.cs
zombieFootstepEmitter.cs
BatteryPickup.cs
DoorCellOpen.cs

Mitchell
Zombie game object
ZombieController animation controller
Zombie waypoint game objects
Spider game objects
SpiderController animation controller
SpiderKey object
Navmesh configuration
Scripts
EnemyAI.cs
SpiderSeek.cs
SpiderKey.cs
MannequinAI.cs

Andy
Win scene + door trigger
Lose scene + zombie attack trigger
Pause menu
HUD and updating HUD for key count
Horror School Props assets
Barrel assets
Scripts
edited DoorUnlock.cs
edited PlayerInventory.cs
GameStarter.cs
PauseMenuToggle.cs
WinTriggerScript.cs
edited ThirdPersonCamera.cs
