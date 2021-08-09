using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SolSystemGen))]
public class AutoGenerate : Editor
{

	public override void OnInspectorGUI() {
		SolSystemGen s = (SolSystemGen)target;

		if (DrawDefaultInspector()) {
			if (s.autoUpdate) {
				s.system = new SolarSystem();
				s.CreateSolarSystem();
				s.system.DebugSystem();
			}
		}

		if (GUILayout.Button("Generate")) {
			GameObject[] bodies = GameObject.FindGameObjectsWithTag("Celestial");
            for (int i = 0; i < bodies.Length; i++) {
				DestroyImmediate(bodies[i]);
            }
			
			s.seed = Random.Range(int.MinValue, int.MaxValue);
			s.system = new SolarSystem();
			s.CreateSolarSystem();
			s.system.DebugSystem();
		}
	}
}