using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapProcesser))]

public class TestButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapProcesser script = (MapProcesser)target;
        if (GUILayout.Button("Nhấn để tạo ra các phòng "))
        {
        }
        if (GUILayout.Button("Generate Map Seed "))
        {
            script.InitializeGeneration();
            script.MapGenerator();

        }

    }
}