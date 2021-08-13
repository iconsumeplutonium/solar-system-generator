using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentences {

    #region Star sentences
    //Star stuff
    //%NAME%
    //%CLASS%
    //%SIZE%
    //%TEMP%
    //%NUMPLANETS%

    public static string[] starNameAndClass = new string[] {
        "This solar system is home to a %CLASS%-class star named %NAME%. ",
        "This system's main resident is a %CLASS%-class star named %NAME%. ",
        "At the center of this system is a star called %NAME%, with a stellar classification of %CLASS%. ",
        "An %CLASS%-class star named %NAME% has taken up residence in this star system. ",

    };

    #region Stellar Classification descriptions

    public static string[] MClassStarDescription = new string[] {
        "M-class stars like %NAME% are some of the smallest types of star in the universe. ",
        "M-class stars, aka 'Red Dwarfs', are the smallest classification of star. ",
        "%NAME%, like other M-class stars, has such a low luminosity that it cannot be seen in the night sky with an unaided eye. ",
        "Red Dwarfs like %NAME% are some of the most common types of star in the Milky Way. "
    };

    public static string[] KClassStarDescription = new string[] {
        "K-Class stars like %NAME% are slightly cooler than our own sun. ",
        "K-type main sequence stars like %NAME% are slightly bigger than M-class stars. ",
        "%NAME% and other K-class stars are smaller than G-class stars like our own sun. ",
        "%NAME% and its K-class brethren are good candidates in the search for alien life due to the amount of time they are stable. "
    };

    public static string[] GClassStarDescription = new string[] {
        "%NAME% is a sibling to our own Sun, as they are both G-class stars. ",
        "Our own sun and %NAME% both share the same classification of G-class stars. ",
        "Our sun and %%NAME% are both G-class stars. For more information on G-class stars, stare directly into the sun.",
        "G-class stars, like %NAME%, will undergo fusion for about 10 billion years before collapsing into itself and forming a supernova. "
    };

    public static string[] FClassStarDescription = new string[] {
        "Slightly larger than our own sun, F-class stars like %NAME% are generally a shade of yellow-white.",
        "F-class stars are generally 1 to 1.4 times the mass of our sun, and %NAME% is no exception. "
    };

    public static string[] AClassStarDescription = new string[] {
        "A-class stars like %NAME% are perhaps the most common type of star visible in the night sky with the naked eye. ",
        "%NAME%, due to being an A-class star, interestingly lacks strong stellar winds. "
    };

    public static string[] BClassStarDescription = new string[] {
        "The second largest class of star, %NAME% is large and bright enough to be seen in the night sky with a naked eye. ",
        "Because %NAME% is a B-class star, it will die pretty young due to its very large mass. "
    };

    public static string[] OClassStarDescription = new string[] {
        "%NAME%, like the O-class star it is, will end up killing itself and forming a black hole or neutron star due to its exceptionally large mass. ",
        "Among the brightest stars in the night sky, %NAME% and other O-class stars will end up dying in a fiery collapse due to its immense mass. "
    };

    #endregion

    #region Star sizes and temperatures

    public static string[] starSizeAndTemp_MandK = new string[] {
        "%NAME% is one of the cooler and smaller stars, at %SIZE% in diameter and a surface temperature of %TEMP%. ",
        "This star has a surface temperature of %TEMP% and has a diameter of %SIZE%. "
    };
    
    public static string[] starSizeAndTemp_GFandA = new string[] {
        "This star has a surface temperature of %TEMP% and has a diameter of %SIZE%. ",
    };

    public static string[] starSizeAndTemp_OandB = new string[] {
        "This star is one of the larger stars with a diameter of %SIZE% and temperature of %TEMP%. ",
        "%NAME%'s diameter of %SIZE% and surface temperature of %TEMP% guarantees that it will shine bright in the night sky. ",
        "With a diameter of %SIZE% and surface temperature of %TEMP%, this star would definitely give our own sun a run for its money. "
    };

    #endregion

    #region Number of Planets

    public static string[] starWithNoPlanets = new string[] {
        "This star has no planets orbiting it. How boring.",
        "This lonely star has nothing orbiting around it. ",
        "Zero planets orbit this star. ",
        "Nothing orbits this star. "
    };

    public static string[] starWithPlanets = new string[] { 
        "%NAME% has a total of %NUMPLANETS% planets orbiting it. ",
        "%NUMPLANETS% planets orbit %NAME%. ", 
        "A handful of planets orbit this star. "
    };

    public static string[] starWithManyPlanets = new string[] {
        "A lot of planets orbit this star. ",
        "%NUMPLANETS% planets orbit %NAME%. Quite a handful. ",
        "%NAME% has quite a number of planets surrounding it at %NUMPLANETS% planets. "
    };
    #endregion

    #endregion

    #region Planet sentences
    //%NAME%
    //%I%
    //%TYPE%
    //%TILT%
    //%MOONS%
    //%SIZE%
    //%DIST%

    public static string[] planetNameAndIndex = new string[] {
        "%NAME% is the %I% planet from its host star. ",
        "The %I% planet from its host star is known as %NAME%. ",
        "The %I% planet in this particular solar system is %NAME%. "
    };

    public static string[] planetSizeAndDistance = new string[] {
        "This planet is of size %SIZE% and is %DIST% away from its host star. ",
        "%NAME% currently resides %DIST% away from the sun, with a diameter of %SIZE%. ",
        "%NAME% is %SIZE% in diameter and is %DIST% away from the star it orbits. "
    };

    #region Descriptions of the types of planets
    public static string[] IcePlanet = new string[] {
        "This is an icy planet, with near constant sub-zero temperatures. ",
        "%NAME% is not much more than an uninteresting lump of ice. ",
        "%NAME% is almost entirely covered with ice. ",
        "This planet might be covered with ice, but don't let that fool you. Its is very geologically active under the ice. ",
        "The surface of %NAME% is convered by ice, but underneath that is a reactive world of geological activity. ",
        "%NAME% is comprised of a very thin atmosphere surrounding a frozen ball of ice. ",
        "Temperatures on %NAME% are routinely colder than the coldest places on Earth, with ice and rock comprising most of its surface. ",
        "%NAME% is of not much interest to anyone except those who wish to study the raging geological activity hidden under its ice sheets. ",
        "This planet is a useless lump of ice that nobody cares about. ",
        "%NAME% is an icy wonderland: the places penguins dream of, provided they also dream of being boiled to death in the near vacuum of %NAME%'s atmosphere. ", 
        "%NAME% is a pretty useless planet. The entire planet is composed of ice, has no geological activity whatsoever, and an atmosphere so thin it practically doesn't exist. "
    };

    public static string[] DryPlanet = new string[] {
        "This scorching desert planet regularly reaches temperatures higher than that ever recorded on Earth. ",
        "%NAME%'s surface is entirely marred by deserts, with temperatures hot enough to cause you to erupt into flames if you ever set foot on it. ",
        "Due to its surface being entirely comprised of deserts, %NAME% has no water on its surface, though it may have hidden underground aquifers. ",
        "%NAME% may have no water on its hot surface, but there are plenty of underground water resevoirs deep beneath its crust. ", 
        "%NAME% contains abundant amounts of silicon and magnesium buried deep underneath the arid deserts of its surface. ",
        "%NAME% has an atmosphere far thinner than Earth's, clocking in at around 9 millibars of surface pressure. ",
        "The sand on its arid surface is constantly being blown about by its humid winds. ",
        "It's possible that %NAME% used to be a lot cooler than it is now, but nobody knows for sure how it became what it is today. ",
        "If you were to walk on %NAME%'s surface without a suit, assuming you don't spontaneously burst into flames your skin would be ripped to shreds by the sand being blown around at ferocious speeds. ",
        "Sandstorms on %NAME% are big enough to blot out entire hemispheres. ",
        "Winter and summers on this planet can be differentiated by whether you suffer a heatstroke and die in a few minutes or sponteously combust into flames. "
    };

    public static string[] MartianPlanet = new string[] {
        "%NAME% is quite similar to Mars: a red planet with a thin atmosphere and a surface rich in iron. ",
        "The resemblance %NAME% has to Mars is uncanny, with its bright red, iron-rich surface and thin atmosphere. ",
        "The bright red coloring of this planet can be attributed to the high amounts of iron embedded in its surface. ",
        "%NAME%'s atmosphere is quite thin, with a surface pressure of only 7 to 8 millibars, compared to Earth's 1013 millibars. ",
        "The blood red surface of %NAME% is reminiscient of the 4th planet in our own solar system, Mars. ",
        "Its possible that %NAME% may have had liquid water at some point, as evidenced by what appears to be dried up riverbeds and canyons that can only have been carved by water. ",
        "Duststorms on this planet are not that frequent, but when they do occur they can last for months on end. ",
        "The wind storms that occur on this planet are very weak, to the point where the only thing they can blow over is the dust on the surface. ",
        "Temperatures on %NAME% during the night drop far below zero, with the daytime temperatures reaching high triple digit numbers. ",
        "%NAME% is the perfect planet for you if you like Mars-like planets. ",
        "With its thin atmosphere and iron-rich surface, %NAME% is practically Mars's long lost twin. "
    };

    public static string[] RockPlanet = new string[] {
        "This planet is a spherical ball of rock, not unlike our own Moon.  ",
        "%NAME% is almost entirely comprised of rock, with its crater-ridden surface resembling the topology of our own Moon. ",
        "The atmosphere of %NAME% is practically nonexistant, making it unlikely that anything ever lived here. ",
        "Underneath the crater-ridden, rocky surface of %NAME% is a dormant mantle and core, indicating that geological activity has been nonexistant for quite some time. ",
        "%NAME%'s mantle and core have completely cooled, an indicator that this planet has not had any geological activity for millions of years. ",
        "During the early formation of this system, thousands upon thousands of asteroids and planetoids collided with %NAME%, leaving its surface a crater-ridden wasteland. ",
        "%NAME% is a fairly boring planet, boasting no atmosphere or interesting terrain features besides thousands of craters. ",
        "%NAME%'s crust is fairly rich in titanium oxides, making it the dream planet of those whose hobbies include manufacturing paint and sunscreen. ",
        "%NAME% is a planet so useless it has nothing of interest to speak of. ",
        "Due to a lack of atmosphere, %NAME%'s surface is perpetually exposed to the cold vacuum of space. ",
        "Though its inhospitable surface may boast no water, %NAME%'s poles are both homes to underground sources of water ice. "
    };

    public static string[] VenusianPlanet = new string[] {
        "With its incredibly thick atmosphere, the surface of %NAME% is a blisteringly hot hellhole. ",
        "The greenhouse effect caused by %NAME%'s thick atmosphere makes this planet one of the hottest in this solar system. ",
        "The hot temperatures on the surface caused by %NAME%'s thick atmosphere can reach thousands of degrees. ",
        "The toxic hellscape of the surface of %NAME% ensures that no life can or will ever thrive here. ",
        "%NAME%'s thick atmosphere is responsible for a greenhouse effect which causes its average temperature to reach triple digit temperatures. ",
        "Most probes sent to %NAME% would not survive for long on the surface. ",
        "There are quite a lot of volcanic plains on %NAME%, complimenting the hundreds of volcanoes dotting its surface. ",
        "Despite having a very active and volcanic surface, %NAME% perplexingly cannot support tectonic activities, meaning that it will have a static surface for millions of years. ",
        "Complimenting its active volcanoes are its even more active tectonic plates, causing frequent earthquakes of very high magnitudes. ",
        "If you were to stand on %NAME%'s surface, you would probably either burn up in its high temperatures, suffocate by breating in carbon dioxide, or be crushed by its heavy atmosphere. ",
        "The atmospheric pressure of %NAME% is several orders of magnitude larger than Earth's atmospheric pressure. "
    };

    public static string[] VolcanicPlanet = new string[] {
        "%NAME% is one of the most geologically active planets in this system, with its surface peppered with volcanoes. ",
        "The volcanoes literring %NAME%'s surface can spew high quantaties of sulfur and sulfur dioxide hundreds of feet into the air. ",
        "%NAME%'s crust and mantle are rich in silicates, contrasting with its iron-rich core. ",
        "Intense lava flows on its surface are the product of %NAME%'s hundreds of volcanoes dotting its surface. ",
        "Thousands of tons of molten lava are spewed up by %NAME%'s volcanoes, resulting in large swaths of lava fields. ",
        "Seas of lava created by %NAME%'s hundreds of volcanoes are so large that they are visible from space. ",
        "Curiously, despite %NAME% having hundreds of volcanoes, most of its mountains are caused by plate tectonics rather than volcanism. ",
        "Almost all of the mountains on %NAME%'s surface were formed by the extensive volcanism present on its surface. ",
        "Boasting a thin atmosphere and hundreds of volcanoes, %NAME%'s surface maintains temperatures of hundreds of degrees. ",
        "The extensive volcanism boasted by %NAME% seems to imply that it was formed relatively recently: only a few hundred million years ago. ",
        "The geologically active crust and mantle of %NAME% seems to indicate that it is a relatively young planet compared to others within this system. "
    };

    public static string[] GasGiant = new string[] {
        "Larger than most other planets, %NAME% is a gas giant with a very strong gravitational pull. ",
        "Due to being a gas giant, %NAME% is almost entirely comprised of gas, having no solid surface at all. ",
        "Though %NAME% may be a gas giant, it actually posesses a solid core due to the immense weight of the atmosphere. ",
        "The immense pressure of the gasses in %NAME's upper atmosphere compresses its core into a solid state. ",
        "The gasses in %NAME% are largely comprised of lighter elements such as hydrogen and helium. ",
        "The outermost sections of %NAME%'s atmosphere is contains some visible clouds, composed of water and ammonia. ",
        "%NAME% spins rapidly on its axis, causing its shape to slightly resemble an oblong spheroid. ",
        "Large storms sometimes form in the atmosphere of %NAME%, which can last for hundreds of years. ",
        "%NAME% has more mass than almost every other body in this solar system. ",
        "%NAME% has a very large magnetosphere, which is responsible for intense radio emission from its poles. ",
        "The intense pressure of its atmosphere causes its temperature to reach thousands of degrees the closer you get to its core. "
    };
    #endregion

    public static string[] planetTiltAndMoons = new string[] {
        "%NAME% sits at a tilt of %TILT%, with %MOONS% orbiting it. ",
        "It is tilted at an angle of %TILT%, and is surrounded by %MOONS%. ",
        "Currently, %MOONS% orbit %NAME%, and it is tilted at an angle of %TILT%. ",
        "%MOONS% orbit %NAME%, which has an axial tilt of %TILT%. "
    };
    
    #endregion
}
