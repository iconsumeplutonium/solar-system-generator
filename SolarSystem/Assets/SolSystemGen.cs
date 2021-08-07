using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolSystemGen : MonoBehaviour {

    public SolarSystem system;
    public int seed;

    public Transform sunPos;

    public Material sunMat;
    public Material planetMat;

    private void Start() {
        system = new SolarSystem();
        CreateSolarSystem();
        system.DebugSystem();
    }

    public void CreateSolarSystem() {
        //Create the solar system
        System.Random prng = new System.Random(seed);

        float size = (prng.Next(1, 100) / 100f) * 5f;
        system.star = new Star(size, Color.yellow);
        system.planets = new Planet[prng.Next(0, 10)];

        System.Random rng = new System.Random(seed);
        for (int i = 0; i < system.planets.Length; i++) {

            float pSize = (rng.Next(1, 100) / 100f) * 2f;
            float dist = (rng.Next(1, 100) / 100f) * 5f;
            int numMoons = rng.Next(1, 3);

            system.planets[i] = new Planet(pSize, dist, numMoons);
        }

        //Spawn it in
        GameObject star1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        star1.transform.position = sunPos.transform.position;
        star1.transform.localScale *= system.star.size;
        star1.transform.localScale = new Vector3(star1.transform.localScale.x, star1.transform.localScale.y + 1, star1.transform.localScale.z);
        sunMat.color = system.star.c;
        star1.GetComponent<MeshRenderer>().material = sunMat;
        star1.name = "Star";

        Vector3 p = sunPos.transform.position;
        float xPos = star1.transform.position.x;
        for (int i = 0; i < system.planets.Length; i++) {
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            p.x -= system.planets[i].distFromHost + 3;

            //p.x -= system.planets[i].distFromHost;
            //p.z = -22.1f;
            o.transform.position = p;

            o.transform.localScale *= system.planets[i].size;
            if(i == system.planets.Length - 1 && p.x < -36.5) {
                o.transform.localScale = new Vector3(o.transform.localScale.x, o.transform.localScale.y + 1, o.transform.localScale.z);
            } //make it so that small sun sizes cant happen
            o.GetComponent<MeshRenderer>().material = planetMat;
            o.name = "Planet " + (i + 1);
        }



    }
 





}
