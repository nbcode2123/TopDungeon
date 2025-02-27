using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ColiderGenerator : MonoBehaviour
{
    public List<Vector2Int> ColiderDirection;
    public int ColiderExpandSize = 2;
    public void ColiderDirectionGenerator(int NumberRoom)
    {
        ColiderDirection.Clear();
        Vector2Int _tempDirection;
        for (int i = 0; i < NumberRoom; i++)
        {
            if (i == 0)
            {
                ColiderDirection.Add(Direction2d.ListDirection[Random.Range(0, 4)]);
            }
            else
            {
                _tempDirection = ColiderDirection[i - 1];
                ColiderDirection.Add(Direction2d.RandomExceptionDirection(_tempDirection * -1));
            }
        }

    }
    public (List<Vector2Int> WalkPosition, Vector2Int EndPosition) WalkColider(Vector2Int startPosition, int step, Vector2Int direction)
    {
        List<Vector2Int> _tempListPosition = new List<Vector2Int>();
        Vector2Int _currentPosition;
        _currentPosition = startPosition;
        _tempListPosition.Add(_currentPosition);
        for (int i = 0; i < step; i++)
        {
            _currentPosition = _currentPosition + direction;
            _tempListPosition.Add(_currentPosition);
        }
        _tempListPosition.AddRange(ColiderExpand(_tempListPosition, direction));
        return (_tempListPosition, _tempListPosition[step - 1]);

    }
    public List<Vector2Int> ColiderExpand(List<Vector2Int> coliderPosition, Vector2Int direction)
    {
        var _tempColiderExpand = new List<Vector2Int>();
        var _tempDirection1 = new Vector2Int(direction.y, direction.x); // vector vuong goc voi huong di 
        Vector2Int _tempDirection2 = new Vector2Int();
        if (direction.x != 0)
        {
            _tempDirection2 = new Vector2Int(direction.y, direction.x * -1);
        }
        if (direction.y != 0)
        {
            _tempDirection2 = new Vector2Int(direction.y * -1, direction.x);
        }
        var _currentPositionExpand = new Vector2Int();

        for (int i = 0; i < coliderPosition.Count; i++)
        {
            _currentPositionExpand = coliderPosition[i];
            for (int j = 1; j <= ColiderExpandSize; j++)
            {
                _tempColiderExpand.Add(_currentPositionExpand + (_tempDirection1 * j));
                _tempColiderExpand.Add(_currentPositionExpand + (_tempDirection2 * j));
            }


        }

        return _tempColiderExpand;


    }

}
public class Direction2d
{
    public Vector2Int Up = Vector2Int.up;
    public Vector2Int Down = Vector2Int.down;
    public Vector2Int Right = Vector2Int.right;
    public Vector2Int Left = Vector2Int.left;
    public static List<Vector2Int> ListDirection = new List<Vector2Int>(){
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };
    public static Vector2Int RandomExceptionDirection(Vector2Int blackSheepDirection)
    {
        List<Vector2Int> _tempDirection = new List<Vector2Int>(ListDirection);
        _tempDirection.Remove(blackSheepDirection);
        return _tempDirection[Random.Range(0, _tempDirection.Count)];
    }
}
