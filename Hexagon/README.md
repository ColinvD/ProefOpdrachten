# HexagonMeshGeneration

I needed to make a hexagon mesh since not every game engine has a hexagon mesh. So I needed to make one from the basics with code. When I'm done with that I must make a tilemap with hexagons as tiles. In the game / demo I needed to have a simple interface so the player can put their own values for: the size of each hexagon, the width of the tilemap and the height of the tilemap.

## Features

- [Make a mesh](https://github.com/ColinvD/ProefOpdrachten/blob/master/Hexagon/Assets/Scripts/MakeMesh.cs)
- [Grid generator for a hexagon tile shape](https://github.com/ColinvD/ProefOpdrachten/blob/master/Hexagon/Assets/Scripts/GridMaker.cs)
- [Outline shader](https://github.com/ColinvD/ProefOpdrachten/blob/master/Hexagon/Assets/Shaders/Outline.shader)

## Software Analysis
Unity has a specific mesh object where you need to make vertices and triangles. Unity can give directly errors if something isn't right and unity has a easy layout so you can change something very quickly to see how it works.
ThreeJS also has a specific mesh object where you need to make vertices and triangles. Your more freely to make it your own way but if you type something wrong than it's hard to find that error or to fix the error.
Gamemaker studio doesn't really have meshes but you can make shapes very easy.

## Learning Goals
What do i want to reach with this project:
- Understand how you make a mesh in unity
- Getting some idea on how to make a outline shader

## Planning

| | Monday | Tuesday | Wednesday | Thursday | Friday |
| --- | --- | --- | --- | --- | --- |
|week 1 | Research engine for making a mesh | Research how to make a mesh | Making a mesh(hexagon) generator | Hexagon tile map generator | Making a outline shader |
|week 2 | Making a outline shader | UI Input to generate field | UI Input to generate field | | |

## Sources

- [Tutorial how to make a mesh from code](https://www.youtube.com/watch?v=IYMQ2ErFz0s)
- [Tutorial on how to make a outline shader](https://www.youtube.com/watch?v=SlTkBe4YNbo)
