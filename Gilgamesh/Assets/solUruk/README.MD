# Uruk
> The concept for my game is based around the city of Uruk. Where, Gilgamesh and Enkidu spend a day in Uruk (before the citizens know of Enkidu, or Enkidu has met Gilgamesh). You get to play the same scenes as either character and carry out the day by performing simple tasks. 

## Visuals
 - Monochrome colour palette using dark brown on beige-yellow for G and dark green foreground for E.
 - Sprites/assets will be hand-drawn and are generally static with some animation (limited to 2 alternating frames)

## Logic/Concept
### Title Screen:
0. The title screen will be designed so u can press press left for G or right for E. After the last sheperd's sheep scene you loop back to the start screen with the leftover character focused on to play. 

### Towncenter
1. Walking through the gate into the towncenter where people are working. As G the people all notice you, and try to work even harder. They try not to disturb their king. As Enkidu the people begin to recognize that you are king material, and they stop what they are doing to praise you. press left and right arrows or A and D as if you were taking footsteps.

### Tavern
2. Accepting drinks at the tavern, you get wine as E and beer as G. The task is to drink without choking on it. Press down or S to drink and up or W to rest and breathe. You wont complete the task without breathing. 

### Sheep Pasture
3. Help the shepereds protect their sheep. Use left right and up and down or WASD to scare away predators. As E you are able to protect a field of sheep, and as G you try to protect the sheep but get angry and scare them. Not exactly in tune with nature but fending off wolves and wildlife as best you can.

## Code Procedure/Tasks
0. Load different areas based on left or right selection
1. Include people looking scared and superfically happy when G approaches but when E does make them stop working and genuinine praise him as a new king-of-sorts.
2. Make the eyebrows of the bartender raise the more you are able to properlly drink. Wine for G and Beer for E, though as G the eybrows stay raised to whole time.
3. Allow for 2D movement and unaffected beasts to scutter around just outside of the sheep's home. As G the sheep are scared, and as G they roam normally and may follow him.
 - detect keys being pressed like ping pong, detect 2D movement with WASD, detect proximity to other things and change animations, set a cap on how long down can he pressed before you need air which resets with the amount that you press up, *drunken effect changes, 
