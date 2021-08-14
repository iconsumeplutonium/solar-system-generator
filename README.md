- [Procedural Solar System Generator](#procedural-solar-system-generator)
      
     - [Description](#description)
     
     - [Project Files](#project-files)
- [How to Use](#how-to-use)
- [How it Works](#how-it-works)

# Procedural Solar System Generator

#### Description

This program procedurally generates a solar system given a seed. It will also generate descriptions and (mostly) accurate properties of each planet and star

![](https://cdn.discordapp.com/attachments/690652979036028929/875859511238328350/ezgif.com-gif-maker.gif)

#### Project Files

This project was written in C# in version 2020.3.12f1 of the Unity engine. To run the program, download the project files and run the Solar System Generator shortcut in the `Solar System/` folder. 

# How to Use

When you open the program for the first time, you will be greeted by this screen.

![menu](https://cdn.discordapp.com/attachments/690652979036028929/875866033641128006/unknown.png)

You can use the scrub bar at the bottom to scroll across the solar system. (Note that the scrubber only appears on solar systems which needs the scrub bar, i.e. systems with more than 1 planet). 

![system scrubber](https://cdn.discordapp.com/attachments/690652979036028929/875867799057231882/system_scrub_gif.gif)

Hovering your mouse cursor over any planet or star will bring up a white circle highlight around it. Left clicking it once it is highlighted will bring up a menu panel providing details about that particular celestial body. 

![planet menu](https://cdn.discordapp.com/attachments/690652979036028929/875866611318399046/unknown.png)

Hitting `back` will bring you back to the overview. The left and right buttons will let you jump to the next and previous planet/star. 


# How it Works

![explanation](https://cdn.discordapp.com/attachments/690652979036028929/875876449981202442/solar_system_explanation.png)

When a random seed is generated (or inputted by the user), it is used to seed a pseudorandom number generator. This causes the pseudorandom number generator to produce the same sequence of numbers every time.

Following this logic, this program works by first using the random seed to seed one instance of the number generator. The first number drawn will the size of the star (between 3 units and 15 units). The second number drawn will be the number of planets (which will be between 0 planets and 10 planets). After this, the number generator will use the size of the star to get its [classification](https://en.wikipedia.org/wiki/Stellar_classification). The classification is then used to determine the color and temperature of the star. 

Once the star's properties have been generated, the algorithm then generates properties for each planet of that star (assuming that the star has planets). A second instance of the random number generator is created and seeded. The first number it generates will be the planet's distance from its host star. Next, it generates a number between 0 and 6 which will be that planet's "type." 

* 0: Icy
* 1: Dry
* 2: Mars-like 
* 3: Rocky
* 4: Venus-like
* 5: Volcanic
* 6: Gas Giant
* 7: Ice Giant

After this, it generates the planet's size (which is then used to determine its texture), followed by the number of moons and the amount to which the planet is tilted. 

A third instance of the pseudorandom number generator is created and seeded and used to generate the names of each planet and star. The algorithm for this is the one I used in my [Word Inventor repository](https://github.com/iconsumeplutonium/word-inventor)

A fourth instance of the pseudorandom number generator is created and seeded, and used to generate the description on each planet's info menu. This can be found in `Assets/Scripts/Sentences.cs` and `Assets/Scripts/ParagraphTextWriter.cs`


The arbitrary Unity transform units used in the generation of the solar system are converted to miles (for size and distance) and Kelvin (for temperature) when the information for each celestial body is displayed on screen. 
