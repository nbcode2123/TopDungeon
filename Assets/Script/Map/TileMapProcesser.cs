using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapProcesser : MonoBehaviour
{
  public Tilemap DungeonTileMap; // grid tile map
  
  public void PaintTileMap (HashSet<Vector2Int> tilePosition, TileBase tileBase ){ // truyen vao danh sach cac tile map de paint
    foreach( var position in tilePosition){
      DungeonTileMap.SetTile(new Vector3Int(position.x, position.y, 0 ),tileBase);
    }
  }
  public void PaintSinglePosition (Vector2Int tilePosition, TileBase tileBase ) // truyen vao vi tri cua tilemap de paint
  {
    DungeonTileMap.SetTile(new Vector3Int(tilePosition.x,tilePosition.y,0),tileBase);

  } 
}
