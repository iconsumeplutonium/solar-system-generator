using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIUtilities {
    public static GameObject GetChildObject(Transform parent, string _tag) {
        for (int i = 0; i < parent.childCount; i++) {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
                return child.gameObject;
        }
        return null;
    }

    public static int GetPlanetIndexOnRayCast(string name) {
        char[] nameInChars = name.ToCharArray();
        for (int i = 0; i < nameInChars.Length; i++) {
            if (char.IsDigit(nameInChars[i]))
                return int.Parse(nameInChars[i].ToString());
        }
        return 0;

    }


    public static void SetSelectionCircle(bool val) {
        GameObject[] obj1 = GameObject.FindGameObjectsWithTag("SelectionCircle");
        for (int i = 0; i < obj1.Length; i++) {
            obj1[i].SetActive(val);
        }
    }

    //ratio of the minimum distance of a G-class star and the distance between the Sun and Mercury
    public static long ConvertDistanceToMiles(float units) {
        return (long)((units * 35412000) /  4.85f);
    }
    
    //largest discovered gas giant is 2.5 times jupiters radius. 
    //it *should* be ratio between that planet's size and the largest possible planet (gas giant of size 5)
    //but math is dumb so im using these wierd formulas with no correlation to irl planets now
    //they just work
    public static long ConvertSizeToMiles(float units, bool isGasGiant) {
        if (isGasGiant)
            return (long)(units * 108602 / 5f);
        else
            return (long)((units * 108602) / 50f);
    }

    //0: normal
    //1: B class
    //2: O class
    public static long ConvertStarSizeToMiles(float units, int starClass) {

        return starClass switch {
            0 => (long)((units * 497593) / 8.1f),
            1 => (long)((units * 497593) / 2.5f),
            _ => (long)((units * 497593) / 2f),
        };
    }

}
