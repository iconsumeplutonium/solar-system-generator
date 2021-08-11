using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SolSystemGen : MonoBehaviour {

    public SolarSystem system;
    public UIManager uiManager;
    public TextureManager textureManager;

    public int seed;
    public float planetaryOffset;

    public Transform sunPos;

    public GameObject selectCanvas;

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
        //system.DebugSystem();
    }

    public void CreateSolarSystem() {
        //Create the solar system
        System.Random prng = new System.Random(seed);
        Bloom bloom;
        ppv.profile.TryGetSettings(out bloom);
        
        //stars are of size 3 to 15
        float size = (prng.Next(60, 300) / 100f) * 5f;
        system.star = new Star(size, seed);
        system.planets = new Planet[prng.Next(0, 10)];

        System.Random rng = new System.Random(seed);
        System.Random offset_rng = new System.Random(seed);
        for (int i = 0; i < system.planets.Length; i++) {

            //the first planet from the sun is going to be the point at the edge of the star minus the planets size, minus a specified minimum distance away from that class of star
            //every other planet will be the previous planet's position minus the previous planet's size, minus a random distance between 5 and 25;
            //TODO: once text system is made, it might be obvious that the first planets are all the same distances. might need to add a bit of randomness to it
            float dist = (i == 0) ? 8.54f - (system.star.size / 2f) /*- pSize*/ - system.star.planet1MinDistance : system.planets[i - 1].distFromHost - system.planets[i - 1].size - ((rng.Next(100, 500) / 100f) * 5f) - planetaryOffset;

            // to prevent ice planets from existing near the sun
            int type = (dist <= -885.512f) ? rng.Next(0, 7) : rng.Next(1, 7);
            //terrestrial size 1 to 3, gas giant size 3 to 5
            float pSize = (type == 6) ? (rng.Next(150, 251) / 100f) * 2f : ((rng.Next(50, 151) / 100f) * 2f) + (offset_rng.Next(-10000, 5001) / 10000f);


            int numMoons = rng.Next(1, 4);
            float axialTilt = rng.Next(1, 360);
            Material m = GetMaterial(type, seed);

            system.planets[i] = new Planet(pSize, dist, numMoons, type, axialTilt, m);
        }

        //Spawn the star
        GameObject star1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //transform
        star1.transform.position = sunPos.transform.position;
        star1.transform.localScale *= system.star.size;

        //color and bloom
        sunMat.color = system.star.c;
        sunMat.SetColor("_EmissionColor", system.star.c);
        star1.GetComponent<MeshRenderer>().material = sunMat;
        bloom.intensity.value = system.star.bloomIntensity;

        //inspector
        star1.name = "Star (" + system.star.classification + ")";
        star1.isStatic = true;
        star1.tag = "Celestial";
        star1.layer = 6;

        //selection circle
        GameObject starSelection = Instantiate(selectCanvas, star1.transform);
        Vector3 starSelectionScale = star1.transform.localPosition / 15f;
        starSelection.transform.localScale = (starSelectionScale.x < 0.7) ? Vector3.one * 0.7f : starSelectionScale;
        starSelection.SetActive(false);

        //Spawn the planets
        Vector3 p = sunPos.transform.position;
        for (int i = 0; i < system.planets.Length; i++) {
            GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            //transform
            p.x = system.planets[i].distFromHost;
            o.transform.position = p;
            o.transform.localScale *= system.planets[i].size;

            //looks
            o.GetComponent<MeshRenderer>().material = system.planets[i].mat;

            //axial tilt
            o.transform.eulerAngles = new Vector3(0, 0, system.planets[i].axialTilt);

            //inspector stuff
            string t = (system.planets[i].planetType == 6) ? " (Gas Giant)" : " (Terrestrial)";
            o.name = "Planet " + (i + 1) + t;
            o.isStatic = true;
            o.tag = "Celestial"; 
            o.layer = 6;

            //selection circle 
            GameObject selection = Instantiate(selectCanvas, o.transform);
            float scale = (system.planets[i].planetType == 6) ? 6f : 3f;
            Vector3 newLocalScale = o.transform.localScale / scale;
            selection.transform.localScale = (newLocalScale.x < 1) ? Vector3.one : newLocalScale;
            selection.SetActive(false);
        }



    }

    public Material GetMaterial(int type, int seed) {
        System.Random mrng = new System.Random(seed);
        return type switch {
            0 => textureManager.IceMaterial[mrng.Next(0, textureManager.IceMaterial.Length)],
            1 => textureManager.DryMaterial[mrng.Next(0, textureManager.DryMaterial.Length)],
            2 => textureManager.MartianMaterial[mrng.Next(0, textureManager.MartianMaterial.Length)],
            3 => textureManager.RockMaterial[mrng.Next(0, textureManager.RockMaterial.Length)],
            4 => textureManager.VenusianMaterial[mrng.Next(0, textureManager.VenusianMaterial.Length)],
            5 => textureManager.VolcanicMaterial[mrng.Next(0, textureManager.VolcanicMaterial.Length)],
            _ => textureManager.GasGiantMaterial[mrng.Next(0, textureManager.GasGiantMaterial.Length)],
        };
    }






}
