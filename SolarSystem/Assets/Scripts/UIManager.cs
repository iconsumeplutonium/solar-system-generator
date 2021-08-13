using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SolSystemGen ssg;
    public Slider scrubber;

    public GameObject planetInfoObj;
    public TMP_Text planetInfoHeader;
    public TMP_Text planetInfo;
    public TMP_Text infoParagraph;

    public Button nextPlanetButton;
    public Button previousPlanetButton;

    public GameObject overviewUIObj;

    public TMP_InputField seedInputField;

    public TMP_Text seed_error;

    [HideInInspector]
    public Vector2 mousePos;
    GameObject previousSelection;

    public bool hasSelectedPlanet;
    bool transitionCoroutineIsActive = false;

    public Vector3 previousCamPos;

    int currentPlanetIndex;

    private void Start() {
        seedInputField.text = ssg.seed.ToString();
        //DisplayStarInfo();
    }

    private void Update() {
        if (!hasSelectedPlanet) {
            if (ssg.system.planets.Length > 0) {
                float endVal = ssg.system.planets[ssg.system.planets.Length - 1].distFromHost;
                Vector3 newCamPos = Camera.main.transform.position;
                newCamPos.x = -10f - scrubber.value * (-10 - endVal);

                Camera.main.transform.position = newCamPos;
            }
            MousePlanetHighlight();
        }
        if (currentPlanetIndex == -1)
            previousPlanetButton.gameObject.SetActive(false);
        else if(!previousPlanetButton.gameObject.activeInHierarchy)
            previousPlanetButton.gameObject.SetActive(true);

        if (currentPlanetIndex == ssg.system.planets.Length - 1)
            nextPlanetButton.gameObject.SetActive(false);
        else if (!nextPlanetButton.gameObject.activeInHierarchy)
            nextPlanetButton.gameObject.SetActive(true);


    }

    #region button press functions

    public void OnNextPlanetButtonPressed() {
        if(currentPlanetIndex + 1 <= ssg.system.planets.Length - 1) {
            currentPlanetIndex++;


            Vector3 planetPos = ssg.system.planets[currentPlanetIndex].posInWorldSpace;
            Vector3 target = new Vector3(planetPos.x + 1.818f, planetPos.y, planetPos.z + 14.36f);

            Camera.main.fieldOfView = 34;
            Camera.main.orthographic = false;
            StartCoroutine(ZoomToLocation(target, 5f));

            planetInfoHeader.text = "Planet " + (currentPlanetIndex + 1);
            planetInfo.text = DisplayPlanetInfo(currentPlanetIndex);
            infoParagraph.text = ParagraphTextWriter.PlanetParagraphWriter(ssg.system.planets[currentPlanetIndex], ssg.seed, currentPlanetIndex + 1);

        }
    }

    public void OnPreviousPlanetButtonPressed() {
        if (currentPlanetIndex - 1 >= -1) {
            currentPlanetIndex--;

            if (currentPlanetIndex >= 0) { //if planet
                Vector3 planetPos = ssg.system.planets[currentPlanetIndex].posInWorldSpace;
                Vector3 target = new Vector3(planetPos.x + 1.818f, planetPos.y, planetPos.z + 14.36f);

                Camera.main.fieldOfView = 34;
                Camera.main.orthographic = false;
                StartCoroutine(ZoomToLocation(target, 5f));

                planetInfoHeader.text = "Planet " + (currentPlanetIndex + 1);
                planetInfo.text = DisplayPlanetInfo(currentPlanetIndex);
                infoParagraph.text = ParagraphTextWriter.PlanetParagraphWriter(ssg.system.planets[currentPlanetIndex], ssg.seed, currentPlanetIndex + 1);
            }
            else { // if sun
                Vector3 target = new Vector3(19.02f, 1, 20.1f);
                StartCoroutine(ZoomToLocation(target, 5f));

                planetInfoHeader.text = "Star";
                planetInfo.text = DisplayStarInfo();
                infoParagraph.text = ParagraphTextWriter.StarParagraphWriter(ssg.system, ssg.seed);
            }

        }
    }

    public void OnPlanetInfoMenuBackButtonPressed() {
        if (!transitionCoroutineIsActive) { //only let the button be pressed if we're not in the middle of a transition
            Vector3 newCamPos = new Vector3(Mathf.Max(-10, Camera.main.transform.position.x - 1.181f), Camera.main.transform.position.y, Camera.main.transform.position.z);
            //Camera.main.transform.position = newCamPos;
            StartCoroutine(ZoomToLocation(previousCamPos, 1f));
            Camera.main.orthographic = true;
            Camera.main.fieldOfView = 70;
            hasSelectedPlanet = false;
            UIUtilities.SetSelectionCircle(true);
            overviewUIObj.SetActive(true);
            planetInfoObj.SetActive(false);
        }
    }

    public void OnNewSystem() {
        GameObject[] bodies = GameObject.FindGameObjectsWithTag("Celestial");
        for (int i = 0; i < bodies.Length; i++) {
            DestroyImmediate(bodies[i]);
        }
        scrubber.value = 0f;

        ssg.seed = Random.Range(int.MinValue, int.MaxValue);
        seedInputField.text = ssg.seed.ToString();
        ssg.system = new SolarSystem();
        ssg.CreateSolarSystem();
    }

    public void OnUserInputNewSeed() {
        GameObject[] bodies = GameObject.FindGameObjectsWithTag("Celestial");
        for (int i = 0; i < bodies.Length; i++) {
            DestroyImmediate(bodies[i]);
        }
        scrubber.value = 0f;

        if (!int.TryParse(seedInputField.text, out _)) {
            seed_error.gameObject.SetActive(true);
        } else {
            ssg.seed = int.Parse(seedInputField.text);

            seedInputField.text = ssg.seed.ToString();

            if (seed_error.gameObject.activeInHierarchy)
                seed_error.gameObject.SetActive(false);

            ssg.system = new SolarSystem();
            ssg.CreateSolarSystem();
        }
    }

    #endregion

    #region get information
    public string DisplayStarInfo() {
        string s = "Name: " + ssg.system.star.name;
        s += "\nClassification: " + ssg.system.star.classification + "-class Star";

        int starClass = 0;
        if (ssg.system.star.classification == 'B')
            starClass = 1;
        else if (ssg.system.star.classification == 'O')
            starClass = 2;

        long size = UIUtilities.ConvertStarSizeToMiles(ssg.system.star.size, starClass);
        s += "\nDiameter: " + size.ToString("N0") + " miles";
        s += "\nNumber of Planets: " + ssg.system.planets.Length;
        s += "\nSurface Temperature: " + ssg.system.star.temp + "K";

        return s;
    }

    public string DisplayPlanetInfo(int index) {
        string s = "Name: " + ssg.system.planets[index].name;

        bool isGasGiant = ssg.system.planets[index].planetType == 6;
        long size = UIUtilities.ConvertSizeToMiles(ssg.system.planets[index].size, isGasGiant);
        s += "\nSize: " + size.ToString("N0") + " miles";

        long miles = UIUtilities.ConvertDistanceToMiles(Mathf.Abs(ssg.system.planets[index].distFromHost));
        s += "\nDistance from Host Star: " + miles.ToString("N0") + " miles";

        s += "\nNumber of Moons: " + ssg.system.planets[index].numMoons;
        s += "\nPlanet Type: " + ssg.system.planets[index].planetType;
        s += "\nTilt: " + ssg.system.planets[index].axialTilt;
        return s;
    }
    #endregion

    public void OnLeftClick(Vector2 mousePos) {
        if (!hasSelectedPlanet) {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
                currentPlanetIndex = UIUtilities.GetPlanetIndexOnRayCast(hit.transform.name) - 1;
                //7.71 is the furthest away the camera can be from a planet, or at Z = -14.36
                //set it to perspective and change FOV to 34
                //camera should be 1.818 less on the X axis than the planet
                hasSelectedPlanet = true;
                UIUtilities.SetSelectionCircle(false);
                planetInfoObj.SetActive(true);
                overviewUIObj.SetActive(false);
                previousCamPos = Camera.main.transform.position;

                if (currentPlanetIndex >= 0) { //if planet
                    Vector3 target = new Vector3(hit.transform.position.x + 1.818f, hit.transform.position.y, hit.transform.position.z + 14.36f);
                    //Camera.main.transform.position = 
                    Camera.main.fieldOfView = 34;
                    Camera.main.orthographic = false;
                    StartCoroutine(ZoomToLocation(target, 1f));

                    planetInfoHeader.text = "Planet " + (currentPlanetIndex + 1);
                    planetInfo.text = DisplayPlanetInfo(currentPlanetIndex);
                    infoParagraph.text = ParagraphTextWriter.PlanetParagraphWriter(ssg.system.planets[currentPlanetIndex], ssg.seed, currentPlanetIndex + 1);
                } else { // if sun
                    Vector3 target = new Vector3(hit.transform.position.x + 6.92f, hit.transform.position.y, hit.transform.position.z + 14.36f);
                    StartCoroutine(ZoomToLocation(target, 1f));
                    //Camera.main.transform.position = 

                    planetInfoHeader.text = "Star";
                    planetInfo.text = DisplayStarInfo();
                    infoParagraph.text = ParagraphTextWriter.StarParagraphWriter(ssg.system, ssg.seed);
                }
            };
        }
    }

    public void MousePlanetHighlight() {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
            GameObject selectionCircle = UIUtilities.GetChildObject(hit.transform, "SelectionCircle");
            selectionCircle.SetActive(true);
            previousSelection = selectionCircle;
        } else {
            if (previousSelection != null)
                previousSelection.SetActive(false);
        }
    }

    public IEnumerator ZoomToLocation(Vector3 targetLocation, float dist) {
        transitionCoroutineIsActive = true;
        while (Camera.main.transform.position != targetLocation) {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetLocation, dist);
            yield return new WaitForSeconds(0.05f);
        }
        transitionCoroutineIsActive = false;
    }

}
