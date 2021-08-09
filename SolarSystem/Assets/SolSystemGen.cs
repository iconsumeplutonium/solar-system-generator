using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SolSystemGen : MonoBehaviour {

    public SolarSystem system;
    public UIManager uiManager;
    public int seed;
    public float planetaryOffset;

    public Transform sunPos;

    public Material sunMat;
    public Material planetMat_terrestrial;

    public Material[] GasGiantTextures;

    public PostProcessVolume ppv;

    public bool autoUpdate;

    //private void OnValidate() {
    //    GameObject[] bodies = GameObject.FindGameObjectsWithTag("Celestial");
    //    for (int i = 0; i < bodies.Length; i++) {
    //        Destroy(bodies[i]);
    //    }
    //    system = new SolarSystem();
    //    CreateSolarSystem();
    //    system.DebugSystem();
    //}


    private void Awake() {
        system = new SolarSystem();
        CreateSolarSystem();
        system.DebugSystem();
    }

    public void CreateSolarSystem() {
        //Create the solar system
        System.Random prng = new System.Random(seed);
        Bloom bloom;
        ppv.profile.TryGetSettings(out bloom);
        Debug.Log(bloom.intensity.value)    ;
        
        //stars are of size 3 to 15
        float size = (prng.Next(60, 300) / 100f) * 5f;
        system.star = new Star(size, seed);
        system.planets = new Planet[prng.Next(0, 10)];

        System.Random rng = new System.Random(seed);
        for (int i = 0; i < system.planets.Length; i++) {

            int type = rng.Next(0, 2);
            //terrestrial size 0.02 to 2, gas giant size 2.02 to 3;
            float pSize = (type == 0) ? (rng.Next(1, 100) / 100f) * 2f : (rng.Next(101, 150) / 100f) * 2f;

            //the first planet from the sun is going to be the point at the edge of the star minus the planets size, minus a specified minimum distance away from that class of star
            //every other planet will be the previous planet's position minus the previous planet's size, minus a random distance between 5 and 25;
            //once text system is made, it might be obvious that the first planets are all the same distances. might need to add a bit of randomness to it
            float dist = (i == 0) ? 8.54f - (system.star.size / 2f) - pSize - system.star.planet1MinDistance : system.planets[i - 1].distFromHost - system.planets[i - 1].size - ((rng.Next(100, 500) / 100f) * 5f) - planetaryOffset;
            int numMoons = rng.Next(1, 3);

            float axialTilt = rng.Next(1, 360);

            system.planets[i] = new Planet(pSize, dist, numMoons, type, axialTilt);
        }

        //Spawn it in
        GameObject star1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        star1.transform.position = sunPos.transform.position;
        star1.transform.localScale *= system.star.size;
        //star1.transform.localScale = new Vector3(star1.transform.localScale.x, star1.transform.localScale.y + 1, star1.transform.localScale.z);
        sunMat.color = system.star.c;
        sunMat.SetColor("_EmissionColor", system.star.c);
        star1.GetComponent<MeshRenderer>().material = sunMat;
        star1.name = "Star (" + system.star.classification + ")";
        star1.isStatic = true;
        star1.tag = "Celestial";
        bloom.intensity.value = system.star.bloomIntensity;

        Vector3 p = sunPos.transform.position;
        float xPos = star1.transform.position.x;
        for (int i = 0; i < system.planets.Length; i++) {
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            p.x = system.planets[i].distFromHost;
            o.transform.position = p;

            o.transform.localScale *= system.planets[i].size;
            o.GetComponent<MeshRenderer>().material = (system.planets[i].planetType == 0) ? planetMat_terrestrial : GasGiantTextures[rng.Next(0, GasGiantTextures.Length -1)];

            o.transform.eulerAngles = new Vector3(0, 0, system.planets[i].axialTilt);

            string t = (system.planets[i].planetType == 0) ? " (Terrestrial)" : " (Gas Giant)";
            o.name = "Planet " + (i + 1) + t;
            o.isStatic = true;
            o.tag = "Celestial";
        }



    }
 





}
