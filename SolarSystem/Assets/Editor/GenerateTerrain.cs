using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class GenerateTerrain : Editor
{

	public override void OnInspectorGUI() {
		MapGenerator s = (MapGenerator)target;

		if (DrawDefaultInspector()) { 
			if (s.autoUpdate) {
				s.GenerateMap();
			}
		}

        if (GUILayout.Button("Generate")) {
            s.seed = Random.Range(int.MinValue, int.MaxValue);
            s.GenerateMap();
        }
    }
}