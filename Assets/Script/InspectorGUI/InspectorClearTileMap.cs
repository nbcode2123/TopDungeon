using Script.Map;
using UnityEditor;
using UnityEngine;

namespace Script.InspectorGUI
{
    [CustomEditor(typeof(PaintTilemap))]
    public class InspectorClearTileMap : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            PaintTilemap paintTilemap = (PaintTilemap)target;
            if (GUILayout.Button("Clear Tile Map"))
            {
                paintTilemap.Clear();
            }
        }
    }
}