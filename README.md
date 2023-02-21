# **VERSATILE PROTOTYPE OF 2D SCHMUP GAME** *(in progress)*
<br><br>

## **DESCRIPTION**


This prototype can be used for build any type of 2D schmup game. Also (after adding some mechanics) for 2D platformer.<br>
Was developed on **Unity**.
<br><br>

## **INTRODUCED MECHANICS**
### **Movement**
Player movment with keyboard (WASD - Arrows). Have 5 different types:  
1. Horizontal - *lock verticaly movement*
2. Vertical - *lock horizontaly movement*
3. Toward - *Auto move with selected axis*
4. Free Roam - *Free movement*
5. Astroid - *Player moves forward/back in the direction they are facing and rotates with horizontal input*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MovePlayer.jpg)

Enemy automaticly movment. Have 3 different types: 
1. No Movement - *No moving*
2. Follow Target - *Follow to attached target (usually Player)*
3. Scroll - *Enemy will move in one direction only*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MoveEn.png)

### **Aim**
Player have 2 types:
1. Aim Toward Mouse - *Look at mouse cursor*
2. Aim Fowards - *In one derection*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/AimPlayer.jpg)

Enemy have 2 types:
1. Aim To Player - *If follow target*
2. Aim Forwards - *In one derection*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/AimEnem.jpg)

### **Shooting**
Player have 2 types: 
1. Controling.
2. Automatic.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/ShootPlayer.jpg)
   
Enemy have 2 types:
1. None shoot.
2. Shoot All - *From all weapons what it have*

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/ShootEnemy.jpg)

### **Weapons**
Have 3 types:
1. Machinegun. 
2. Fireball.
3. Laser.

### **Weapons Switching**
Switch weapon after pick up appropriate drop.

### **Health and Damage**
Lose and recieve health.

### **Buffs**
1. Buff for weapon - *Level 1, Level 2, Level 3*
2. Health - *Small, Large*
3. Shield.

### **Drops (From enemies)**
1. Weapon - *Machinegun, Fireball, Laser*
2. Buff for weapon - *Level 1, Level 2, Level 3*
3. Health - *Small, Large*
4. Shield.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Drop.jpg)

### **Camera's boards checking**
If use static camera and need to Player no move out of camera vision, used board checking.

### **Effects**
1. Projetiles - *Machinegun, Fireball*
2. Laser.
3. Laser's Shoot and Damage.
4. Projetiles's *(Machinegun, Fireball)* Shoot and Damage.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Laser.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MachinegunEffectsDamageAndShoot.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/FireballShootEffect.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/FireballDamageEffect.jpg)

### **Pause**
With keyboard *esc* and with button *for touch*

### **UI**
1. Main menu panel of Start page - *Play, Settings, About, Quit*
2. Map Selection page.
3. Level Selection page.
4. Pause panel.

![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/MainMenu.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Map%20selection.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Level%20selection.jpg)
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/pause.jpg)

## **PACKAGES**
1. For InputReading used Input System package v1.4.3
2. For effecs used Universal RP v12.1.7
3. For comfortable work with camera used Cinemachine v2.8.9
4. For text used TextMeshPro v3.0.6
<br><br>

## **SCREENSHOTS**

Laser Shader:
![](https://github.com/shakur-farit/Schmup-Prototype/blob/main/Screenshots/Laser%20shader.jpg)
