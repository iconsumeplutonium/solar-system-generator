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
    public Material ringMat;

    public PostProcessVolume ppv;

    public bool autoUpdate;



    private void Awake() {
        seed = Random.Range(int.MinValue, int.MaxValue);
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
        float size = (prng.Next(60, 301) / 100f) * 5f;
        system.star = new Star(size, seed);
        system.planets = new Planet[prng.Next(0, 10)];

        System.Random rng = new System.Random(seed);
        System.Random offset_rng = new System.Random(seed);
        for (int i = 0; i < system.planets.Length; i++) {

            //the first planet from the sun is going to be the point at the edge of the star minus the planets size, minus a specified minimum distance away from that class of star
            //every other planet will be the previous planet's position minus the previous planet's size, minus a random distance between 5 and 25 (36.5 million and 182.5 million miles);
            float dist = (i == 0) ? 8.54f - (system.star.size / 2f) /*- pSize*/ - system.star.planet1MinDistance : system.planets[i - 1].distFromHost - system.planets[i - 1].size - ((rng.Next(100, 501) / 100f) * 5f) - planetaryOffset;

            // to prevent ice planets from existing near the sun
            int type = (dist <= -100f) ? rng.Next(0, 8) : rng.Next(1, 8);

            //if a terrestrial planet is more than 3.2 billion miles away from its star, it will always be an icy planet.
            //exception: the planet is smaller than 2823.652 miles in diameter (size 1.3 in unity's arbitrary measurements), see the line where the planet's material is assigned
            if (dist <= -438.26f && (type != 6 && type != 7))
                type = 0;


            //terrestrial size 1 to 3 (plus variation), gas/ice giant size 3 to 5
            float pSize = (type >= 6) ? (rng.Next(150, 251) / 100f) * 2f : ((rng.Next(50, 151) / 100f) * 2f) + (offset_rng.Next(-10000, 5001) / 10000f);

            //gas giants and ice giants can have more moons
            int numMoons = (type >= 6) ? rng.Next(0, 71) : rng.Next(0, 5);
            float axialTilt = rng.Next(1, 360);

            //if the planet is smaller than a certain size, it should always be rock
            Material m = (pSize <= 1.3f) ? textureManager.RockMaterial[1] : GetMaterial(type, seed);

            bool hasRings = false;
            if (type >= 6)
                hasRings = rng.Next(0, 2) == 0;

            system.planets[i] = new Planet(pSize, dist, numMoons, type, axialTilt, m, hasRings, seed);
        }

        //create star and planet names
        //given a seed, the word inventor will always give you the same name, which becomes a problem as you dont want every celestial body to have the same name
        //thus, the seed is used to create a list of new seeds, where each one corresponds to the star and planets
        //that list of seeds is then used to generate a list of names for each celestial body
        System.Random nrng = new System.Random(seed);
        for (int i = 0; i < system.planets.Length + 1; i++) {
            int newSeed = nrng.Next(int.MinValue, int.MaxValue);
            if (i == 0)
                system.star.name = WordInventor.InventCelestialName(newSeed);
            else
                system.planets[i - 1].name = WordInventor.InventCelestialName(newSeed);
        }



        //Spawn the star
        GameObject star1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //transform
        star1.transform.position = sunPos.transform.position;
        star1.transform.localScale *= system.star.size;
        system.star.posInWorldSpace = sunPos.transform.position;

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
            system.planets[i].posInWorldSpace = p;
            o.transform.localScale *= system.planets[i].size;

            //looks
            o.GetComponent<MeshRenderer>().material = system.planets[i].mat;

            //axial tilt
            o.transform.eulerAngles = new Vector3(0, 0, system.planets[i].axialTilt);

            //inspector stuff
            string t = " (Terrestrial)";
            if (system.planets[i].planetType == 6)
                t = " (Gas Giant)";
            if (system.planets[i].planetType == 7)
                t = " (Ice Giant)";
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

            //rings
            if(system.planets[i].hasRings) {
                PlanetRing ring =  o.AddComponent<PlanetRing>();
                ring.segments = 100;
                ring.ringMat = ringMat;
                ring.SetUpRing();
                ring.BuildRingMesh(system.planets[i].innerRadius, system.planets[i].thickness);
            }
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
            6 => textureManager.GasGiantMaterial[mrng.Next(0, textureManager.GasGiantMaterial.Length)],
            _ => textureManager.IceGiantMaterial[mrng.Next(0, textureManager.IceGiantMaterial.Length)],
        };
    }






}
