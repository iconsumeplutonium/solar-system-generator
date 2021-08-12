using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentences {

    #region Star sentences
    //Star stuff
    //%%NAME%%
    //%%CLASS%%
    //%%SIZE%%
    //%%TEMP%%
    //%%NUMPLANETS%%

    public static string[] starNameAndClass = new string[] {
        "This solar system is home to a %%CLASS%%-class star named %%NAME%%.",
        "This system's main resident is a %%CLASS%%-class star named %%NAME%%. ",
        "At the center of this system is a star called %%NAME%%, with a stellar classification of %%CLASS%%. ",
        "An %%CLASS%%-class star named %%NAME%% has taken up residence in this star system. ",

    };

    #region Stellar Classification descriptions

    public static string[] MClassStarDescription = new string[] {
        "M-class stars like %%NAME%% are some of the smallest types of star in the universe. ",
        "M-class stars, aka 'Red Dwarfs', are the smallest classification of star. ",
        "%%NAME%%, like other M-class stars, has such a low luminosity that it cannot be seen in the night sky with an unaided eye. ",
        "Red Dwarfs like %%NAME%% are some of the most common types of star in the Milky Way. "
    };

    public static string[] KClassStarDescription = new string[] {
        "K-Class stars like %%NAME%% are slightly cooler than our own sun. ",
        "K-type main sequence stars like %%NAME%% are slightly bigger than M-class stars. ",
        "%%NAME%% and other K-class stars are smaller than G-class stars like our own sun. ",
        "%%NAME%% and its K-class brethren are good candidates in the search for alien life due to the amount of time they are stable. "
    };

    public static string[] GClassStarDescription = new string[] {
        "%%NAME%% is a sibling to our own Sun, as they are both G-class stars. ",
        "Our own sun and %%NAME%% both share the same classification of G-class stars. ",
        "Our sun and %%NAME% are both G-class stars. For more information on G-class stars, stare directly into the sun.",
        "G-class stars, like %%NAME%%, will undergo fusion for about 10 billion years before collapsing into itself and forming a supernova. "
    };

    public static string[] FClassStarDescription = new string[] {
        "Slightly larger than our own sun, F-class stars like %%NAME%% are generally a shade of yellow-white.",
        "F-class stars are generally 1 to 1.4 times the mass of our sun, and %%NAME%% is no exception. "
    };

    public static string[] AClassStarDescription = new string[] {
        "A-class stars like %%NAME%% are perhaps the most common type of star visible in the night sky with the naked eye. ",
        "%%NAME%%, due to being an A-class star, interestingly lacks strong stellar winds. "
    };

    public static string[] BClassStarDescription = new string[] {
        "The second largest class of star, %%NAME%% is large and bright enough to be seen in the night sky with a naked eye. ",
        "%%NAME%%, due to being a B-class main sequence star is so big that it will die pretty young. Rest in Piece %%NAME%%, you probably won't be missed. "
    };

    public static string[] OClassStarDescription = new string[] {
        "%%NAME%%, like the O-class star it is, will end up killing itself and forming a black hole or neutron star due to its exceptionally large mass. ",
        "Among the brightest stars in the night sky, %%NAME%% and other O-class stars will end up dying in a fiery collapse due to its immense mass. "
    };

    #endregion

    #region Star sizes and temperatures

    public static string[] starSizeAndTemp_MandK = new string[] {
        "%%NAME%% is one of the cooler and smaller stars, at %%SIZE%% in diameter and a surface temperature of %%TEMP%%. ",
        "This star has a surface temperature of %%TEMP%% and has a diameter of %%SIZE%%. "
    };
    
    public static string[] starSizeAndTemp_GFandA = new string[] {
        "This star has a surface temperature of %%TEMP%% and has a diameter of %%SIZE%%. ",
    };

    public static string[] starSizeAndTemp_OandB = new string[] {
        "This star is one of the larger stars with a diameter of %%SIZE%% and temperature of %%TEMP%%. ",
        "%%NAME%%'s diameter of %%SIZE%% and surface temperature of %%TEMP%% guarantees that it will shine bright in the night sky. ",
        "With a diameter of %%SIZE%% and surface temperature of %%TEMP%%, this star would definitely give our own sun a run for its money. "
    };

    #endregion

    #region Number of Planets

    public static string[] starWithNoPlanets = new string[] {
        "This star has no planets orbiting it. How boring.",
        "This lonely star has nothing orbiting around it. ",
        "Zero planets orbit this star. ",
        "Nothing orbits this star. ",
        "This star has the rare property of not having any planets orbiting it. "
    };

    public static string[] starWithPlanets = new string[] { 
        "%%NAME%% has a total of %%NUMPLANETS%% planets orbiting it. ",
        "%%NUMPLANETS%% planets orbit %%NAME%%. ", 
        "A handful of planets orbit this star. "
    };

    public static string[] starWithManyPlanets = new string[] {
        "A lot of planets orbit this star. ",
        "%%NUMPLANETS%% planets orbit %%NAME%%. Quite a handful. ",
        "%%NAME%% has quite a number of planets surrounding it at %%NUMPLANETS%% planets. "
    };
    #endregion

    #endregion

    //%NAME%
    //%I%
    //%TYPE%
    //%TILT%
    //%MOONS%

    public static string[] planetNameAndIndex = new string[] {
        "%NAME% is the %I% planet from the its host star. ",
        "The %I% planet from its host star is known as %NAME%. ",
        "The %I% planet in this particular solar system is %NAME%. "
    };

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

    public static string[] MartialPlanet = new string[] {
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
        ""
    };

    public static string[] RockPlanet = new string[] {
                "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };

    public static string[] VenusianPlanet = new string[] {
                "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };

    public static string[] VolcanicPlanet = new string[] {
                "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };

    public static string[] GasGiant = new string[] {
                "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""
    };  
}
