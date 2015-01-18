# Labyrinth
This program generates randomly an n x m labyrinth with a start and finish point. Then it can find the shortest path.

# Description
No interaction with the user is except for the input of the size of the labyrinth. When the size is chosen and the generation is started the algorithm makes sure that all the paths of the maze are connected to each other.

Then it generates an image (.png) that will be the labyrinth.

Every main algorithm in this program where created by myself without the inspiration or help of already exixting algorithm.

No special library is required to run this program.

# History
This is program is in version 2.1.

The first version was written in Python. The algorithm was using recursive functions to generate and find the shortest path.
Because of this method the program was limited in the size of labyrinth it could generate or solve before running to many recursions and also limited in the speed of generation and solving.

Vesion 2.0 was created in the purpose of avoiding recursive functions so that there is less limitation and faster generation/solving.
Now the program is able to create 10 000 x 10 000 labyrinths in 45 minutes.

Version 2.1 allows now to not be limited in the size of the labyrinth by creating an image instead of just showing the labyrinth on the window.

Futur versions would involve faster and more efficient algorithm. No new features are expected yet to be added.

# How to run the program
You can download all the files then open the Labyrinth2.0.csproj with visual studio, then compile and run it.

# Credit
Thanks to Marc-Antoine for giving me the idea, pleasure and fun of creating this program.

