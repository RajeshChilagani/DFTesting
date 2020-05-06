# DFTesting
Interpreting User mood based on the controller positions and speed. To Keep things simple all the emotes(moods) are represented by colors (green, blue, yellow, red). 
All the moods are interpreted by two things Zone and Speed. A Zone is determined by the distance between the controller and the user. There are 3 zones currently based on the distance, {Near, Middle, Far}. Each Zone can have different number of emotes(moods). For example, in this project Near Zone only has two {green & red}, but Middle zone has three and Far Zone four. So, we can customize the number of emotes in a zone giving freedom. Once the zone is determined we determine the mood of the user based on the speed of the controller. Here currently speed is only the factor but various other factors can used in determining the correct mood in a particular zone.
Controls for Testing
- Use Q/E to move the spheres attached to the player which represent the controllers
- Use Keys 1-Near Zone, 2- Middle Zone, 3 - Far Zone to change the positions of spheres from Near - Far from the player
Overlap the spheres with cube in scene to see differnt Colors(Moods) based on the Zone.
