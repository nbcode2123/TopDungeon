using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PaintTilemap : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap floormap, walltilemap, corridormap, testMap;
    public TileBase floorcolor, DoorColor;
    public TileBase corridorcolor, wallcolor, left, right, top, bottom;
    public HashSet<Vector2Int> wallPosition_right = new HashSet<Vector2Int>();
    public HashSet<Vector2Int> wallPosition_left = new HashSet<Vector2Int>();
    public HashSet<Vector2Int> wallPosition_top = new HashSet<Vector2Int>();
    public HashSet<Vector2Int> wallPosition_bottom = new HashSet<Vector2Int>();

    public void PaintFloorPosition(HashSet<Vector2Int> floorPositions)
    {
        painttilemap(floorPositions, floormap, floorcolor);

    }
    public void PaintFloorPosition(HashSet<Vector2Int> floorPositions, Tilemap floormap)
    {
        painttilemap(floorPositions, floormap, floorcolor);

    }
    public void PaintDoorPosition(HashSet<Vector2Int> floorPositions, Tilemap floormap)
    {
        painttilemap(floorPositions, floormap, DoorColor);

    }

    public void painttilemap(HashSet<Vector2Int> floorPositions, Tilemap floormap, TileBase floorcolor)
    {
        foreach (var floorPositon in floorPositions)
        {
            paintSingleFloor(floorPositon, floormap, floorcolor);
        }
    }

    public void PaintCorridor(HashSet<Vector2Int> floorPositions)
    {
        painttilemap(floorPositions, corridormap, corridorcolor);

    }



    public void paintSingleFloor(Vector2Int floorPositon, Tilemap floormap, TileBase floorcolor)
    {
        var tilePosition = floormap.WorldToCell((Vector3Int)floorPositon);
        floormap.SetTile(tilePosition, floorcolor);
    }

    public void Clear()
    {
        floormap.ClearAllTiles();
        walltilemap.ClearAllTiles();
        corridormap.ClearAllTiles();

    }

    internal void PaintSingleWallRight(Vector2Int wall)
    {
        paintSingleFloor(wall, walltilemap, right);
    }

    internal void PaintSingleWallLeft(Vector2Int wall)
    {
        paintSingleFloor(wall, walltilemap, left);
    }

    internal void PaintSingleWallTop(Vector2Int wall)
    {
        paintSingleFloor(wall, walltilemap, top);
    }

    internal void PaintSingleWallBottom(Vector2Int wall)
    {
        paintSingleFloor(wall, walltilemap, bottom);
    }
    public void PaintWall()
    {

        foreach (var wallRight in wallPosition_right)
        {
            PaintSingleWallRight(wallRight);
        }

        foreach (var wallLeft in wallPosition_left)
        {
            PaintSingleWallLeft(wallLeft);
        }
        foreach (var wallTop in wallPosition_top)
        {
            PaintSingleWallTop(wallTop);
        }

        foreach (var wallBottom in wallPosition_bottom)
        {
            PaintSingleWallBottom(wallBottom);
        }
    }
}
