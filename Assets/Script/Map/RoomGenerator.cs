using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

public class RoomGenerator : MonoBehaviour
{
   public static Vector2Int[] Direction2D = {Vector2Int.up, Vector2Int.down,Vector2Int.left,Vector2Int.right};


    public HashSet<Vector2Int> FloorGenerator(Vector2Int RoomCenterPosition, RoomScriptObject RoomPrototype ){  
        // tu vi tri trung tam di chuyen tren duoi bang 1/2 kich thuoc roi dua het vao 1 tempList
        int RoomSize = RoomPrototype.Size;
        HashSet<Vector2Int> _floorPosition = new HashSet<Vector2Int>();
        _floorPosition.Add(RoomCenterPosition);
        int size = RoomSize /2;
        int  x = RoomCenterPosition.x;
        int y = RoomCenterPosition.y;
        HashSet<Vector2Int> _tempCenterRoom  = new HashSet<Vector2Int>();
        _tempCenterRoom.Add(RoomCenterPosition);
        Vector2Int _currentPosition,_nextPosition  ;
        _currentPosition = RoomCenterPosition  ; 
        for (int i = 0; i < size; i++)
        {
            _nextPosition = _currentPosition + Vector2Int.up;
            _floorPosition.Add(_nextPosition);
            _tempCenterRoom.Add(_nextPosition);
            _currentPosition =  _nextPosition;
        }
        _currentPosition = RoomCenterPosition;
          for (int i = 0; i < size; i++)
        {
            _nextPosition = _currentPosition + Vector2Int.down;
            _floorPosition.Add(_nextPosition);
            _tempCenterRoom.Add(_nextPosition);
            _currentPosition =  _nextPosition;
        }
        // voi moi vi tri trong tempList do thi di chuyen sang trai phai 1/2 kich thuoc
        foreach( var position in _tempCenterRoom){
            _currentPosition = position;
            for (int i = 0; i < size; i++)
        {
            _nextPosition = _currentPosition + Vector2Int.left;
            _floorPosition.Add(_nextPosition);
            _currentPosition =  _nextPosition;
        }
            _currentPosition = position;
            for (int i = 0; i < size; i++)
        {
            _nextPosition = _currentPosition + Vector2Int.right;
            _floorPosition.Add(_nextPosition);
            _currentPosition =  _nextPosition;
        }
        }       
        return _floorPosition;
        
    }
    public (HashSet<Vector2Int> topWall, HashSet<Vector2Int> botWall,HashSet<Vector2Int> leftWall,HashSet<Vector2Int> rightWall)WallGenerator (HashSet<Vector2Int> floorPositions){
        HashSet<Vector2Int> top = new HashSet<Vector2Int>();
        HashSet<Vector2Int> bot = new HashSet<Vector2Int>();
        HashSet<Vector2Int> left = new HashSet<Vector2Int>();
        HashSet<Vector2Int> right = new HashSet<Vector2Int>();
        
        foreach( var position in floorPositions){
            for(int i =0;i < Direction2D.Length;i++){
                Vector2Int _isWallPosition =  position + Direction2D[i];
                if (!floorPositions.Contains(_isWallPosition))
                {
                    switch (i){
                        case 0:  top.Add(_isWallPosition); break ;
                        case 1:  bot.Add(_isWallPosition); break;
                        case 2:  left.Add(_isWallPosition); break;
                        case 3:  right.Add(_isWallPosition); break;
                    }
                }
            }
        }
        return (top,bot,left,right);
    }
    
}

