using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem {

    public Star star;
    public Planet[] planets;

    public void DebugSystem() {
        string v = "Star (" + star.classification + "), Size: " + star.size + ", NumPlanets: " + planets.Length + ", SurfaceTemp: " + star.temp + "K.";
        for (int i = 0; i < planets.Length; i++) {
            v += " Planet " + (i + 1) + " (T" + planets[i].planetType + "), Size: " + planets[i].size + ", Dist: " + planets[i].distFromHost + ", Moons: " + planets[i].numMoons + ", tilt: " + planets[i].axialTilt;
        }
        //Debug.Log(v);
    }

}

public class Star {

    public string name;
    public float size;
    public Color c;
    public char classification;
    public float bloomIntensity;
    public float planet1MinDistance;
    public int temp;

    public Vector3 posInWorldSpace;

    public Star(float s, int seed) {
        size = s;
        GenerateExtraneousDetails(seed);
    }

    public void GenerateExtraneousDetails(int seed) {
        //size is its diameter.
        classification = GetClassification();
        c = GetColor(classification);
        bloomIntensity = GetBloom(classification);
        planet1MinDistance = GetMinPlanetDistance(classification);
        temp = GetSurfaceTemperature(classification, seed);
        
    }

    private Color GetColor(char classification) {

        if (classification == 'M') return new Color(255, 189, 111);
        if (classification == 'K') return new Color(255, 221, 180);
        if (classification == 'G') return new Color(255, 244, 232);
        if(classification == 'F') return new Color(251, 248, 255);
        if(classification == 'A') return new Color(202, 216, 255);
        if (classification == 'B') return new Color(170, 191, 255);
        else return new Color(155, 176, 255); //if (size > 13.2f && size <= 15f), O class

    }

    private char GetClassification() {
        //stars are of size 3 to 15. There are 7 classifications of star, thus each threshold increases by 12/7 or 1.7
        if (size >= 3f && size <= 4.7f) return 'M';
        if (size > 4.7f && size <= 6.4f) return 'K';
        if (size > 6.4f && size <= 8.1f) return 'G';
        if (size > 8.1f && size <= 9.8f) return 'F';
        if (size > 9.8f && size <= 11.5f) return 'A';
        if (size > 11.5f && size <= 13.2f) return 'B';
        else return 'O'; //if (size > 13.2f && size <= 15f)

    }

    private float GetBloom(char classification) {
        if (classification == 'M') return 0.02f;
        if (classification == 'K') return 0.07f;
        if (classification == 'G' || classification == 'F') return 0.25f;
        if (classification == 'A') return 0.4f;
        if (classification == 'B') return 0.5f;
        else return 4f; // O-class star
    }

    private float GetMinPlanetDistance(char classification) {

        if (classification == 'M') return 8f; //increased from 2.31
        if (classification == 'K') return 8.34f;
        if (classification == 'G') return 8.85f;
        if (classification == 'F') return 10.97f;
        if (classification == 'A') return 16.03f;
        if (classification == 'B') return 17.94f;
        else return 18.17f; //O-class

    }

    private int GetSurfaceTemperature(char classification, int seed) {
        System.Random trng = new System.Random(seed);

        //star temperature ranges from wikipedia
        if (classification == 'M') return trng.Next(2600, 3850);
        if (classification == 'K') return trng.Next(4000, 5250);
        if (classification == 'G') return trng.Next(5500, 6000);
        if (classification == 'F') return trng.Next(6000, 7200);
        if (classification == 'A') return trng.Next(7500, 10000);
        if (classification == 'B') return trng.Next(10500, 30000);
        else return trng.Next(30000); //O-class

    }

}

//i could probably create some sort of system where i have Terrestrial and Gas Giant classes that derive from the Planet class
//but nah, thats too much work
public class Planet {
    public string name;
    public float size;
    public float distFromHost;
    public int numMoons;
    //0 ice
    //1 dry
    //2 martian
    //3 rock
    //4 venusian
    //5 volcanic
    //6 gas giant
    //7 ice giant
    public int planetType;
    public float axialTilt;
    public Material mat;

    public Vector3 posInWorldSpace;

    public bool hasRings;
    public float innerRadius;
    public float thickness;

    public Planet(float size, float distFromHost, int numMoons, int type, float tilt, Material mat, bool hasRings, int seed) {
        this.size = size;
        this.distFromHost = distFromHost;
        this.numMoons = numMoons;
        planetType = type;
        axialTilt = tilt;
        this.mat = mat;

        this.hasRings = hasRings;
        if (hasRings)
            GenerateRingValues(seed);
    }

    public void GenerateRingValues(int seed) {
        System.Random rrng = new System.Random(seed);
        //between 0.6 and 1
        innerRadius = rrng.Next(600, 1001) / 1000f;
        //between 0.03 and 0.9
        thickness = rrng.Next(30, 901) / 1000f;
    }

}
