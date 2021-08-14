using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParagraphTextWriter {

    public static string PlanetParagraphWriter(Planet planet, int seed, int index) {
        string description = "";
        System.Random prng = new System.Random(seed);

        /*
        FORMAT: 
        1) name/planet index
        2) size/distance from host
        3) planet type
        4) axial tilt/number of moons
        
        */

        description += Sentences.planetNameAndIndex[prng.Next(0, Sentences.planetNameAndIndex.Length)];
        description += Sentences.planetSizeAndDistance[prng.Next(0, Sentences.planetSizeAndDistance.Length)];

        description += planet.planetType switch {
            0 => Sentences.IcePlanet[prng.Next(0, Sentences.IcePlanet.Length)],
            1 => Sentences.DryPlanet[prng.Next(0, Sentences.DryPlanet.Length)],
            2 => Sentences.MartianPlanet[prng.Next(0, Sentences.MartianPlanet.Length)],
            3 => Sentences.RockPlanet[prng.Next(0, Sentences.RockPlanet.Length)],
            4 => Sentences.VenusianPlanet[prng.Next(0, Sentences.VenusianPlanet.Length)],
            5 => Sentences.VolcanicPlanet[prng.Next(0, Sentences.VolcanicPlanet.Length)],
            6 => Sentences.GasGiant[prng.Next(0, Sentences.GasGiant.Length)],
            _ => Sentences.IceGiant[prng.Next(0, Sentences.IceGiant.Length)],
        };
        description += Sentences.planetTiltAndMoons[prng.Next(0, Sentences.planetTiltAndMoons.Length)];

        bool isGasGiant = (planet.planetType == 6);
        string iThPlace = IndexToIthPlace(index);
        string degrees = planet.axialTilt + " degrees";
        string moons = planet.numMoons.ToString() + ((planet.numMoons != 1) ? " moons" : " moon");
        string size = UIUtilities.ConvertSizeToMiles(planet.size, isGasGiant).ToString("N0") + " miles";
        string dist = UIUtilities.ConvertDistanceToMiles(Mathf.Abs(planet.distFromHost)).ToString("N0") + " miles";

        string s = description.Replace("%NAME%", planet.name).Replace("%I%", iThPlace).Replace("%TILT%", degrees).Replace("%MOONS%", moons).Replace("%SIZE%", size).Replace("%DIST%", dist);

        return s;
    }

    public static string StarParagraphWriter(SolarSystem system, int seed) {
        string description = "";
        System.Random prng = new System.Random(seed);

        /*
        FORMAT:
        1) name/class
        2) size/tempreature
        3) planets
        
        */

        description += Sentences.starNameAndClass[prng.Next(0, Sentences.starNameAndClass.Length)];


        if (system.star.classification == 'M') description += Sentences.MClassStarDescription[prng.Next(0, Sentences.MClassStarDescription.Length)];
        else if (system.star.classification == 'K') description += Sentences.KClassStarDescription[prng.Next(0, Sentences.KClassStarDescription.Length)];
        else if(system.star.classification == 'G') description += Sentences.GClassStarDescription[prng.Next(0, Sentences.GClassStarDescription.Length)];
        else if (system.star.classification == 'F') description += Sentences.FClassStarDescription[prng.Next(0, Sentences.FClassStarDescription.Length)];
        else if (system.star.classification == 'A') description += Sentences.AClassStarDescription[prng.Next(0, Sentences.AClassStarDescription.Length)];
        else if (system.star.classification == 'B') description += Sentences.BClassStarDescription[prng.Next(0, Sentences.BClassStarDescription.Length)];
        else description += Sentences.OClassStarDescription[prng.Next(0, Sentences.OClassStarDescription.Length)];


        if (system.star.classification == 'M' || system.star.classification == 'K') 
            description += Sentences.starSizeAndTemp_MandK[prng.Next(0, Sentences.starSizeAndTemp_MandK.Length)];
        else if (system.star.classification == 'G' || system.star.classification == 'F' || system.star.classification == 'A') 
            description += Sentences.starSizeAndTemp_GFandA[prng.Next(0, Sentences.starSizeAndTemp_GFandA.Length)];
        else 
            description += Sentences.starSizeAndTemp_OandB[prng.Next(0, Sentences.starSizeAndTemp_OandB.Length)];


        if (system.planets.Length == 0) 
            description += Sentences.starWithNoPlanets[prng.Next(0, Sentences.starWithNoPlanets.Length)];
        else if (system.planets.Length >= 8) 
            description += Sentences.starWithManyPlanets[prng.Next(0, Sentences.starWithManyPlanets.Length)];
        else 
            description += Sentences.starWithPlanets[prng.Next(0, Sentences.starWithPlanets.Length)];



        int starClass = 0;
        if (system.star.classification == 'B')
            starClass = 1;
        else if (system.star.classification == 'O')
            starClass = 2;

        string class1 = system.star.classification.ToString();
        string size = UIUtilities.ConvertStarSizeToMiles(system.star.size, starClass).ToString("N0") + " miles";
        string temp = system.star.temp + "K";
        string numberOfPlanets = system.planets.Length.ToString();


        //because theres no better way to replace all the the placeholders. thanks c#, very cool. 
        string s1 = description.Replace("%NAME%", system.star.name).Replace("%CLASS%", class1).Replace("%SIZE%", size).Replace("%TEMP%", temp).Replace("%NUMPLANETS%", numberOfPlanets);

        return s1;
    }

    private static string IndexToIthPlace(int index) {
        return index switch {
            1 => "1st",
            2 => "2nd",
            3 => "3rd",
            _ => index.ToString() + "th"
        };
    }

}
