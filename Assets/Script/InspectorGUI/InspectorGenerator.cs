
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MapGenerator_Manager))]

public class InspectorGenerator : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapGenerator_Manager mapGenerator = (MapGenerator_Manager)target;
        if (GUILayout.Button("Generator"))
        {
            mapGenerator.GeneratorMap();


        }
        if (GUILayout.Button("Clear Tile Map"))
        {
            mapGenerator.ClearTileMap();
        }





    }



}


