using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem {

    public Star star;
    public Planet[] planets;

    public void DebugSystem() {
        string v = "Star is of size " + star.size + ". It has " + planets.Length + " planets.";
        for (int i = 0; i < planets.Length; i++) {
            v += " Planet " + i + " is of size " + planets[i].size + ", is " + planets[i].distFromHost + " away from the sun, and has " + planets[i].numMoons + " moons.";
        }
        Debug.Log(v);

    }

}

public class Star {

    public float size;
    public Color c;

    public Star(float s, Color c) {
        size = s;
        this.c = c;
    }
}

public class Planet {
    public float size;
    public float distFromHost;
    public int numMoons;

    public Planet(float size, float distFromHost, int numMoons)
    {
        this.size = size;
        this.distFromHost = distFromHost;
        this.numMoons = numMoons;
    }
}
