using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour {
    public RoomGenerator roomGenerator;  // chua cac phuong thuc tao ra cac thanh phan cua 1 room bao gom floor, wall
    public TileMapProcesser tileMapProcesser;  // chua cac phuong thuc de paint tile map 
    /// <summary>
    /// //////////////////////////////
    /// </summary>
    public TileBase tileBaseTest; // test
    public List<RoomScriptObject> testingroom; //test
    public TileBase tileBaseTop;
    public TileBase tileBaseDown;

    public TileBase tileBaseRight;

    public TileBase tileBaseLeft;

    
    public void Start()
    {
        Testting();
    }
    public void Testting (){
        foreach (var itemt in testingroom)
        {
            HashSet<Vector2Int> test = roomGenerator.FloorGenerator( Vector2Int.zero,  itemt);
            tileMapProcesser.PaintTileMap(test,tileBaseTest);
            var floorTest = roomGenerator.WallGenerator(test);
            tileMapProcesser.PaintTileMap(floorTest.topWall,tileBaseTop);
            tileMapProcesser.PaintTileMap(floorTest.leftWall,tileBaseLeft);
            tileMapProcesser.PaintTileMap(floorTest.rightWall,tileBaseRight);
            tileMapProcesser.PaintTileMap(floorTest.botWall,tileBaseDown);



            

        }
      
    }
}
