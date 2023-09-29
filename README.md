- [Procedural Solar System Generator](#procedural-solar-system-generator)
      
     - [Description](#description)
     
     - [Project Files](#project-files)
- [How to Use](#how-to-use)
- [How it Works](#how-it-works)

# Procedural Solar System Generator

#### Description

This program procedurally generates a solar system given a seed. It will also generate descriptions and (mostly) accurate properties of each planet and star

![](https://i.ibb.co/Ms4KpbS/system.gif)

#### Project Files

This project was written in C# in version 2020.3.12f1 of the Unity engine. To run the program, download the project files and run the Solar System Generator shortcut in the `Solar System/` folder. 

# How to Use

When you open the program for the first time, you will be greeted by this screen.

![menu](https://i.imgur.com/lj6vCAy.png)

You can use the scrub bar at the bottom to scroll across the solar system. (Note that the scrubber only appears on solar systems which needs the scrub bar, i.e. systems with more than 1 planet). 

![system scrubber](https://i.ibb.co/vw1D3Pb/system-scrub-gif.gif)

Hovering your mouse cursor over any planet or star will bring up a white circle highlight around it. Left clicking it once it is highlighted will bring up a menu panel providing details about that particular celestial body. 

![planet menu](https://i.imgur.com/k1MbY18.png)

Hitting `back` will bring you back to the overview. The left and right buttons will let you jump to the next and previous planet/star. 



Star properties include its [classification](https://en.wikipedia.org/wiki/Stellar_classification) (which determine color and temperature) and the number of planets. 

The properties of each planet include the distance from its host star, type (icy, dry, Mars-like, rocky, Venus-like, volcanic, gas giant, or ice giant), size, whether it has rings or not, number of moons, and its planetary tilt.

The names of the planets and stars are generated via the algorithm in my [Word Inventor](https://github.com/iconsumeplutonium/word-inventor) program.

When a random seed is generated (or inputted by the user), it is used to seed a pseudorandom number generator. This causes the pseudorandom number generator to produce the same sequence of numbers every time.


Planet ring script and texture by [boardtobits](https://github.com/boardtobits/planet-ring-mesh).
