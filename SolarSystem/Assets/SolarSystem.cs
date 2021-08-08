using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem {

    public Star star;
    public Planet[] planets;

    public void DebugSystem() {
        string v = "Star () is of size " + star.size + ". It has " + planets.Length + " planets.";
        for (int i = 0; i < planets.Length; i++) {
            v += " Planet " + (i + 1) + " is of size " + planets[i].size + ", is " + planets[i].distFromHost + " away from the sun, and has " + planets[i].numMoons + " moons.";
        }
        Debug.Log(v);

    }

}

public class Star {

    public float size;
    public Color c;
    public char classification;

    public Star(float s) {
        size = s;
        //this.c = c;
    }

    public void GenerateExtraneousDetails() {
        //size is its diameter.
        //stars are of size 3 to 5. There are 7 classifications of star, thus each threshold increases by 2/7 or 0.28
        c = GetColor();
        Debug.Log(classification);
    }

    private Color GetColor() {
        Color c = Color.white;

        if (size > 3f && size <= 3.28f) {
            c = new Color(255, 189, 111);
            classification = 'M';
        }
        else if (size > 3.28f && size <= 3.56f) {
            c = new Color(255, 221, 180);
            classification = 'K';
        } 
        else if(size > 3.56f && size <= 3.84f) {
            c = new Color(255, 244, 232);
            classification = 'G';
        } 
        else if(size > 3.84f && size <= 4.12f) {
            c = new Color(251, 248, 255);
            classification = 'F';
        }
        else if(size > 4.12f && size <= 4.4f) {
            c = new Color(202, 216, 255);
            classification = 'A';
        }
        else if (size > 4.12f && size <= 4.4f) {
            c = new Color(170, 191, 255);
            classification = 'B';
        }
        else if (size > 4.12f && size <= 4.4f) { //this doesnt go all the way up to 5, check on that
            c = new Color(155, 176, 255);
            classification = 'O';
        }

        return c;
    }
}

public class Planet {
    public float size;
    public float distFromHost;
    public int numMoons;
    public int planetType; //0 for terrestrial, 1 for gas giant

    public Planet(float size, float distFromHost, int numMoons, int type) {
        this.size = size;
        this.distFromHost = distFromHost;
        this.numMoons = numMoons;
        this.planetType = type;
    }
}
