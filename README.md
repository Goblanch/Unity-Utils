# Unity-Utility-Classes
Utility classes for Unity Game Engine

This repository contains some utility classes for game development in Unity. They are meant to be used and configured in Unity's inspector without having
to code it every time you want a feature that can be in this repository.

# FDPlayerMovent

FD stands for "Four Directions". All the classes whith this pre-title are for four directions 2D games.

FDPlayerMovement is a utility class to control players movement. This scripts allow to move, sprint and dash.

USAGE

In order to propoerly use this class, you have to follow this steps:
  1.- Download the script and import it to your Unity proyect.
  2.- Create a game object to add this script (this game object should be player's)
  3.- Add a RigidBody2D component (It's body type must be dynamic)
  4.- Set rigidbody's gravity scale to zero.
  5.- Add the script component to the game object.
  6.- In the script component (inspector), add a reference in "Rb 2d" of the rigidbody previously created.
  7.- Set the values as you want. Remember if you want to use dash or sprint, the checkboxes "sprint enabled" and "dash enabled" must
      be active in order to use it.
