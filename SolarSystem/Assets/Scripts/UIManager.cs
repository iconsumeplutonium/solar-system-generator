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

    public GameObject overviewUIObj;

    [HideInInspector]
    public Vector2 mousePos;
    GameObject previousSelection;

    public bool hasSelectedPlanet;

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
        Vector3 newCamPos = new Vector3(Mathf.Max(-10, Camera.main.transform.position.x - 1.181f), Camera.main.transform.position.y, Camera.main.transform.position.z);
        //Camera.main.transform.position = newCamPos;
        StartCoroutine(ZoomToLocation(previousCamPos));
        Camera.main.orthographic = true;
        Camera.main.fieldOfView = 70;
        hasSelectedPlanet = false;
        SetSelectionCircle(true);
        overviewUIObj.SetActive(true);
        planetInfoObj.SetActive(false);
    }


    #endregion

    #region get information
    public string DisplaySystemInfo() {
        string s = "Name: \nClassification: " + ssg.system.star.classification + "\nDiameter: " + ssg.system.star.size + "\nNumber of Planets: " + ssg.system.planets.Length + "\nSurface Temperature: " + ssg.system.star.temp + "K";
        return s;
    }

    public string DisplayPlanetInfo(int index) {
        string s = "Name: \nSize: " + ssg.system.planets[index].size + "\nDistance from Host Star: " + ssg.system.planets[index].distFromHost + "\nNumber of Moons: " + ssg.system.planets[index].numMoons + "\nPlanet Type: " + ssg.system.planets[index].planetType + "\nTilt: " + ssg.system.planets[index].axialTilt;
        return s;
    }
    #endregion

    public void OnLeftClick(Vector2 mousePos) {
        if (!hasSelectedPlanet) {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
                int index = GetPlanetIndexOnRayCast(hit.transform.name) - 1;
                //7.71 is the furthest away the camera can be from a planet, or at Z = -14.36
                //set it to perspective and change FOV to 34
                //camera should be 1.818 less on the X axis than the planet
                hasSelectedPlanet = true;
                SetSelectionCircle(false);
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
                }
            };
        }
    }

    public void MousePlanetHighlight() {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f)) {
            GameObject selectionCircle = GetChildObject(hit.transform, "SelectionCircle");
            selectionCircle.SetActive(true);
            previousSelection = selectionCircle;
        } else {
            if (previousSelection != null)
                previousSelection.SetActive(false);
        }
    }

    #region utility functions
    private GameObject GetChildObject(Transform parent, string _tag) {
        for (int i = 0; i < parent.childCount; i++) {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
                return child.gameObject;
        }
        return null;
    }

    private int GetPlanetIndexOnRayCast(string name) {
        char[] nameInChars = name.ToCharArray();
        for (int i = 0; i < nameInChars.Length; i++) {
            if (char.IsDigit(nameInChars[i]))
                return int.Parse(nameInChars[i].ToString());
        }
        return 0;

    }


    private void SetSelectionCircle(bool val) {
        GameObject[] obj1 = GameObject.FindGameObjectsWithTag("SelectionCircle");
        for (int i = 0; i < obj1.Length; i++) {
            obj1[i].SetActive(val);
        }
    }

    #endregion

    public IEnumerator ZoomToLocation(Vector3 targetLocation) {
        while (Camera.main.transform.position != targetLocation) {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetLocation, 1f);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
