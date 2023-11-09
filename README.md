# unity-tower-defense
 A PvZ like tower defense game practice project

![Image Sequence_001_0000](https://github.com/sinamhdn/unity-tower-defense/assets/34884156/3833ed03-0147-49f6-86e6-a6b31431548f)

## Unity Version
2022.3.2f1 LTS

## Assets Used
Free assets of discontinued glitch game https://www.glitchthegame.com/ \
Fx Explosion Pack from unity assets store \
Font are from https://www.dafont.com/ 

## Concepts Used
- Loading Scenes based on build index and name
- Using coroutine
- Using canvas as the game area
- Calculating safe zone of the game area for mobile
- Using world space canvas mode
- Aligning game area sprite units with the world unit of unity
- Spritesheet animation
- keyframe based animation
- Bone based animation
- Animation Events
- Animation States
- Animation transitions
- Putting animator and scripts on parent to be able to edit caracte position after animation created
- Instantiating prefabs from the location of a game object
- Spawning an object as a child of another object
- Moving objects via code or with animation
- Spawn particle effects at position of a game object
- Converting world space and local space
- Converting screen point to world point
- Detect mouse down using a collider
- Spawn prefabs in random intervals
- Detect objects based on the script attached to them
- Use kinematic RigidBody2D
- Use UI slider
- Store game settings data in computer using player prefs
- Play a pesistent music through scenes
- Using singleton pattern
- Using static variables to preserve data between scenes
- Using a trigger collider to destroy game objects no longer in use
- Working with material assets
- Applying materials to 3d objects

**NOTE: REMEMBER TO ADD SCENES TO BUILD SETTINGS IN THIS ORDER "SplashScreen" > "WinScreen" > "LoseScreen" > "OptionsScreen" > "StartScreen" > "Level1" > "Level2" > "Level3" > "Level4" > "Level5"**
