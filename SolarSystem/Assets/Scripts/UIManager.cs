using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SolSystemGen ssg;
    public Slider scrubber;

    public GameObject systemInfo;
    public TMP_Text starInfoText;

    public GameObject planetInfoObj;
    public TMP_Text planetInfoHeader;
    public TMP_Text planetInfo;
    public TMP_Text infoParagraph;

    public GameObject overviewUIObj;

    [HideInInspector]
    public Vector2 mousePos;
    GameObject previousSelection;

    public bool hasSelectedPlanet;
    bool transitionCoroutineIsActive = false;

    public Vector3 previousCamPos;

    private void Start() {
        //DisplaySystemInfo();
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
    }

    #region button press functions
    public void OnSystemInfoPressed() {
        systemInfo.SetActive(true);
    }

    public void OnSystemInfoClose() {
        systemInfo.SetActive(false);
    }

    public void OnNextPlanetButtonPressed() {
        float camPos = Camera.main.transform.position.x;
        int closestIndex = -1;
        float minDistance = float.MaxValue;
        for (int i = 0; i < ssg.system.planets.Length; i++) {
            if (Mathf.Abs(camPos - ssg.system.planets[i].distFromHost) < minDistance)
                closestIndex = i;
        }

        float endVal = ssg.system.planets[ssg.system.planets.Length - 1].distFromHost;
        scrubber.value = ssg.system.planets[closestIndex].distFromHost / (-10 - endVal);
    }

    public void OnPlanetInfoMenuBackButtonPressed() {
        if (!transitionCoroutineIsActive) { //only let the button be pressed if we're not in the middle of a transition
            Vector3 newCamPos = new Vector3(Mathf.Max(-10, Camera.main.transform.position.x - 1.181f), Camera.main.transform.position.y, Camera.main.transform.position.z);
            //Camera.main.transform.position = newCamPos;
            StartCoroutine(ZoomToLocation(previousCamPos));
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
        ssg.system = new SolarSystem();
        ssg.CreateSolarSystem();
    }


    #endregion

    #region get information
    public string DisplaySystemInfo() {
        string s = "Name: " + ssg.system.star.name;
        s += "\nClassification: " + ssg.system.star.classification + "-class Star";

        int starClass = 0;
        if (ssg.system.star.classification == 'B')
            starClass = 1;
        else if (ssg.system.star.classification == 'O')
            starClass = 2;

        long size = UIUtilities.ConvertStarSizeToMiles(ssg.system.star.size, starClass);
        s += "\nDiameter: " + size.ToString("N0");
        s += "\nNumber of Planets: " + ssg.system.planets.Length;
        s += "\nSurface Temperature: " + ssg.system.star.temp + "K";

        return s;
    }

    public string DisplayPlanetInfo(int index) {
        string s = "Name: " + ssg.system.planets[index].name;

        bool isGasGiant = ssg.system.planets[index].planetType == 6;
        long size = UIUtilities.ConvertSizeToMiles(ssg.system.planets[index].size, isGasGiant);
        s += "\nSize: " + size.ToString("N0");

        long miles = UIUtilities.ConvertDistanceToMiles(Mathf.Abs(ssg.system.planets[index].distFromHost));
        s += "\nDistance from Host Star: " + miles.ToString("N0");

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
                int index = UIUtilities.GetPlanetIndexOnRayCast(hit.transform.name) - 1;
                //7.71 is the furthest away the camera can be from a planet, or at Z = -14.36
                //set it to perspective and change FOV to 34
                //camera should be 1.818 less on the X axis than the planet
                hasSelectedPlanet = true;
                UIUtilities.SetSelectionCircle(false);
                planetInfoObj.SetActive(true);
                overviewUIObj.SetActive(false);
                previousCamPos = Camera.main.transform.position;

                if (index >= 0) { //if planet
                    Vector3 target = new Vector3(hit.transform.position.x + 1.818f, hit.transform.position.y, hit.transform.position.z + 14.36f);
                    //Camera.main.transform.position = 
                    Camera.main.fieldOfView = 34;
                    Camera.main.orthographic = false;
                    StartCoroutine(ZoomToLocation(target));

                    planetInfoHeader.text = "Planet " + (index + 1);
                    planetInfo.text = DisplayPlanetInfo(index);
                } else { // if sun
                    Vector3 target = new Vector3(hit.transform.position.x + 6.92f, hit.transform.position.y, hit.transform.position.z + 14.36f);
                    StartCoroutine(ZoomToLocation(target));
                    //Camera.main.transform.position = 

                    planetInfoHeader.text = "Star";
                    planetInfo.text = DisplaySystemInfo();
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

    public IEnumerator ZoomToLocation(Vector3 targetLocation) {
        transitionCoroutineIsActive = true;
        while (Camera.main.transform.position != targetLocation) {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetLocation, 1f);
            yield return new WaitForSeconds(0.05f);
        }
        transitionCoroutineIsActive = false;
    }

}
