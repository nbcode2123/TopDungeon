using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PaintTilemap))]
public class InspectorClearTileMap : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PaintTilemap paintTilemap = (PaintTilemap)target;
        if (GUILayout.Button("Cear Tile Map"))
        {
            paintTilemap.Clear();
        }
    }
}