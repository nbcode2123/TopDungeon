using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class DungeonConcept : MonoBehaviour
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
    public TileBase WallRoomTileBase;
    public TileBase FloorRoomTileBase;
    public List<TileBase> FloorTileBase;
    public List<GameObject> Enemy;
    public List<GameObject> Boss;
    public List<TileMapAssetConcept> _tempTileBasCollection;

    public static DungeonConcept Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public List<TileMapAssetConcept> TilebaseCollection;
    public TileMapAssetConcept CurrentTileMapAsset;


    // Start is called before the first frame update
    void Start()
    {
        _tempTileBasCollection = new List<TileMapAssetConcept>(TilebaseCollection);

    }

    // Update is called once per frame
    void Update()
    {

    }
    // public TileMapAssetConcept SetUpTileMapConcept()
    // {

    // }
    public void ChoosingRandomTileBaseConcept()
    {
        if (CurrentTileMapAsset == null)
        {
            CurrentTileMapAsset = TilebaseCollection[Random.Range(0, TilebaseCollection.Count)];
            _tempTileBasCollection.Remove(CurrentTileMapAsset);



            // CurrentTileMapAsset = TilebaseCollection[0];

        }
        else if (CurrentTileMapAsset != null && DungeonController.Instance.Stage == 1)
        {
            // for (int i = 0; i < _tempTileBasCollection.Count; i++)
            // {
            //     if (CurrentTileMapAsset != TilebaseCollection[i])
            //     {
            //         CurrentTileMapAsset = TilebaseCollection[i];
            //         break;
            //     }
            // }
            CurrentTileMapAsset = _tempTileBasCollection[Random.Range(0, _tempTileBasCollection.Count)];

            _tempTileBasCollection.Remove(CurrentTileMapAsset);

            // CurrentTileMapAsset = TilebaseCollection[0];


        }
        // else if (CurrentTileMapAsset != null && DungeonController.Instance.Stage > 1)
        // {
        //     return;
        // }


        ChoosingTileBaseConcept(CurrentTileMapAsset);

    }
    public void ChoosingRandomTileBaseConceptBegin()
    {

        CurrentTileMapAsset = TilebaseCollection[Random.Range(0, TilebaseCollection.Count)];

        // CurrentTileMapAsset = TilebaseCollection[0];




        ChoosingTileBaseConcept(CurrentTileMapAsset);
    }
    public void ChooseTilebaseConceptWithId(int id)
    {
        for (int i = 0; i < TilebaseCollection.Count; i++)
        {
            if (TilebaseCollection[i].ConceptId == id)
            {
                CurrentTileMapAsset = TilebaseCollection[i];
                break;
            }
        }
        ChoosingTileBaseConcept(CurrentTileMapAsset);


    }
    public void ChoosingTileBaseConcept(TileMapAssetConcept tilebase)
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
        WallRoomTileBase = tilebase.WallTileBase;
        FloorRoomTileBase = tilebase.FloorTileBase;
        Enemy = new List<GameObject>(tilebase.Enemy);
        Boss = tilebase.Boss;
        CreateBulletPoolingForBulletEnemy();
    }
    public void CreateBulletPoolingForBulletEnemy()
    {

        foreach (var obj in Enemy)
        {
            var _tempBulletObj = obj.GetComponent<RangeAttack>()?.Bullet;
            if (_tempBulletObj != null)
            {
                ObjectPoolManager.Instance.CreatePoolForDuplicateObject(_tempBulletObj);
                ObjectPoolManager.Instance.SpawnThePool(_tempBulletObj.name, 200);
            }

        }


    }
}
