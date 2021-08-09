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

    private void Start() {
        DisplaySystemInfo();
    }

    private void Update() {
        float endVal = ssg.system.planets[ssg.system.planets.Length - 1].distFromHost;
        Vector3 newCamPos = Camera.main.transform.position;
        newCamPos.x = -10f - scrubber.value * (-10 - endVal);

        Camera.main.transform.position = newCamPos;
    }

    public void OnSystemInfoPressed() {
        systemInfo.SetActive(true);
    }

    public void OnSystemInfoClose() {
        systemInfo.SetActive(false);
    }

    public void DisplaySystemInfo() {
        string s = "Name: \nClassification: " + ssg.system.star.classification + "\nDiameter: " + ssg.system.star.size + "\nNumber of Planets: " + ssg.system.planets.Length + "\nSurface Temperature: " + ssg.system.star.temp + "K";
        starInfoText.text = s;
    }
}