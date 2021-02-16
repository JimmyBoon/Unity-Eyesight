# Unity-Eyesight
Simple Eyesight script for AI characters in Unity3d. 

This script can be used for AI Characters to sense when tagged objects are within a sight range and angle. This script also makes sure that the tagged object is not obstructed by other objects (wall or building for example). The tagged objects or obstruction objects require a collider (box colliders work well).


Set up:
Place the script onto Game Objects that you would like to have the ability to see.

Eyes: You will need to choose where the eyes of the object will be. This is where the object will look from.
Set the eyes in the inspector.

Seeing Range: This is how far the object will be able to see.

Sight Angle: This is from 0 to 180 degrees. With 0 beinging only able to look directly infront, 90 looking completely left or right, and 180 will be able to see in all directions.

Object Tag: Set the tag of objects you would like your AI to see.

