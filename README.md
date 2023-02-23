# **VERSATILE PROTOTYPE OF 2D SHMUP GAME** *(in progress)*
<br><br>

## **DESCRIPTION**


This prototype can be used for building any type of 2D shmup game. Also (after adding some mechanics) for 2D platformer.<br>
It was developed on **Unity**.
<br><br>

## **INTRODUCED MECHANICS**
### **Movement**
Player movment with keyboard (WASD - Arrows) and has 5 different types:  
1. Horizontal - *lock verticaly movement*
2. Vertical - *lock horizontaly movement*
3. Toward - *Auto move with selected axis*
4. Free Roam - *Free movement*
5. Astroid - *Player moves forward/back in the direction they are facing and rotates with horizontal input*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MovePlayer.jpg)

Enemy moves automatically and has 3 types of movement. 
1. No Movement - *No moving*
2. Follow Target - *Follow attached target (usually Player)*
3. Scroll - *Enemy will move in one direction only*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MoveEn.png)

### **Aim**
Player has 2 types of aiming:
1. Aim Toward Mouse - *Look at mouse cursor*
2. Aim Fowards - *In one derection*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/AimPlayer.jpg)

Enemy has 2 types of aiming:
1. Aim To Player - *If follow target*
2. Aim Forwards - *In one derection*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/AimEnem.jpg)

### **Shooting**
Player has 2 types of shooting: 
1. Controling.
2. Automatic.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/ShootPlayer.jpg)
   
Enemy has 2 types of shooting:
1. None shoot.
2. Shoot All - *From all weapons that it has*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/ShootEnemy.jpg)

### **Weapons**
There are 3 types of weapon:
1. Machinegun. 
2. Fireball.
3. Laser.

### **Weapon Switching**
Player switchs weapons after picking up appropriate drop.

### **Health and Damage**
Lose and recieve health.

### **Buffs**
1. Buff for weapon - *Level 1, Level 2, Level 3*
2. Health - *Increases in Small or Large amount*
3. Shield - *Player gains shield*

### **Drops (From enemies)**
1. Weapons - *Machinegun, Fireball, Laser*
2. Buff for weapons - *Level 1, Level 2, Level 3*
3. Health - *Small, Large*
4. Shield.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Drop.jpg)

### **Camera's borders checking**
While using static camera if you need Player not to go out of camera vision use border checking.

### **Effects**
1. Projectiles - *Machinegun, Fireball*
2. Laser.
3. Laser's Shoot and Damage.
4. Projectiles' *(Machinegun, Fireball)* Shoot and Damage.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MachinegunEffectsDamageAndShoot.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/FireballShootEffect.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/FireballDamageEffect.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Laser.jpg)

### **Pause**
With keyboard - *"esc"* and with button - *"touch"*

### **UI**
1. Main menu panel of Start page - *Play, Settings, About, Quit*
2. Map Selection page.
3. Level Selection page.
4. Pause panel.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MainMenu.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/pause.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Map%20selection.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Level%20selection.jpg)

## **PACKAGES USED**
1. For InputReading - Input System v1.4.3
2. For effecs - Universal RP v12.1.7
3. For comfortable work with camera - Cinemachine v2.8.9
4. For text - TextMeshPro v3.0.6
<br><br>

## **SCREENSHOTS**

Laser Shader:
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Laser%20shader.jpg)
