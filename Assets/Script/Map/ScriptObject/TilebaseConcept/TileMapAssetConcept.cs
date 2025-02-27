using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileMapAssetConcept", menuName = "TileMapAssetConcept")]

public class TileMapAssetConcept : ScriptableObject
{
    public List<TileBase> FloorTileMap;
    public TileBase TopWallTileMap;
    public TileBase DownWallTileMap;
    public TileBase RightWallTileMap;
    public TileBase LeftWallTileMap;

    public TileBase TopLeftWallTileMap;
    public TileBase TopRightWallTileMap;
    public TileBase BotLeftWallTileMap;
    public TileBase BotRightWallTileMap;
    public List<GameObject> Architecture;
    public GameObject RandomArchitecture()
    {
        return Architecture[Random.Range(0, Architecture.Count)];
    }


}
