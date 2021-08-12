using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParagraphTextWriter {

    public static string PlanetParagraphWriter(Planet planet, int seed, int index) {
        string s = "";
        System.Random prng = new System.Random(seed);

        /*
        FORMAT: 
        1) name/planet index
        2) planet type
        3) axial tilt/number of moons
        
        */


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

        //because theres no better way to replace all the the placeholders. thanks c#, very cool. 
        string s1 = description.Replace("%%NAME%%", system.star.name).Replace("%%CLASS%%", system.star.classification.ToString()).Replace("%%SIZE%%", UIUtilities.ConvertStarSizeToMiles(system.star.size, starClass).ToString() + " miles").Replace("%%TEMP%%", system.star.temp + "K").Replace("%%NUMPLANETS%%", system.planets.Length.ToString());

        return s1;
    }

}
