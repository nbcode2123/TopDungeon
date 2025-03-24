using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapProcesser : MonoBehaviour
{
  public static TileMapProcesser Instance { get; private set; }


  public void Start()
  {

  }
  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
    }
    else
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  public void PaintTileMap(List<Vector2Int> tilePosition, TileBase tileBase, Tilemap tilemap)
  { // truyen vao danh sach cac tile map de paint
    foreach (var position in tilePosition)
    {
      tilemap.SetTile(new Vector3Int(position.x, position.y, 0), tileBase);
    }
  }
  public void PaintSinglePosition(Vector2Int tilePosition, TileBase tileBase, Tilemap tilemap) // truyen vao vi tri cua tilemap de paint
  {
    tilemap.SetTile(new Vector3Int(tilePosition.x, tilePosition.y, 0), tileBase);

  }
  public void DeleteTileMap(Tilemap tilemap)
  {
    tilemap.ClearAllTiles();
  }
  public void ClearAllTileMap()
  {
    DungeonConcept.Instance.FloorTileMap.ClearAllTiles();
    DungeonConcept.Instance.WallTileMapDungeon.ClearAllTiles();
  }
  public void PaintTileMapWithConcept()
  {

  }
  public void PaintTileMapWithMultipleTileBase(List<Vector2Int> tilePosition, List<TileBase> listTileBase, Tilemap tilemap)
  {
    foreach (var position in tilePosition)
    {

      tilemap.SetTile(new Vector3Int(position.x, position.y, 0), listTileBase[Random.Range(0, listTileBase.Count)]);
    }
  }
}
