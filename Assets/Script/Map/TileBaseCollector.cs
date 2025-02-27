using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapCollector : MonoBehaviour
{
    public Tilemap FloorTileMap;
    public Tilemap WallTileMapDungeon;
    public TileBase TopTileMap;
    public TileBase DownTileMap;
    public TileBase RightTileMap;
    public TileBase LeftTileMap;
    public TileBase TopLeftTileMap;
    public TileBase TopRightTileMap;
    public TileBase BotLeftTileMap;
    public TileBase BotRightTileMap;
    public TileBase Testting;
    public List<TileBase> FloorTileBase;

    public static TileMapCollector Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public List<TileMapAssetConcept> TilebaseCollector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChosingTileBaseConcept(TileMapAssetConcept tilebase)
    {
        FloorTileBase = tilebase.FloorTileMap;
        TopTileMap = tilebase.TopWallTileMap;
        DownTileMap = tilebase.DownWallTileMap;
        RightTileMap = tilebase.RightWallTileMap;
        LeftTileMap = tilebase.LeftWallTileMap;

        TopLeftTileMap = tilebase.TopLeftWallTileMap;
        TopRightTileMap = tilebase.TopRightWallTileMap;
        BotRightTileMap = tilebase.BotRightWallTileMap;
        BotLeftTileMap = tilebase.BotLeftWallTileMap;
    }
}
