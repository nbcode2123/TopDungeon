using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapProcessor))]

public class TestButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapProcessor script = (MapProcessor)target;
        if (GUILayout.Button("Nhấn để tạo ra các phòng "))
        {
        }
        if (GUILayout.Button("Generate Map Seed "))
        {
            // script.InitializeGeneration();
            script.StartMapProcess();

        }

    }

}