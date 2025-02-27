using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProcesser : MonoBehaviour
{

    public static Vector2Int[] Direction2D = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
    public (List<Vector2Int> topWall, List<Vector2Int> botWall, List<Vector2Int> leftWall, List<Vector2Int> rightWall, List<Vector2Int> topleftWall, List<Vector2Int> toprightWall, List<Vector2Int> botrightWall, List<Vector2Int> botleftWall) WallDirectionGenerator(List<Vector2Int> floorPositions)
    {
        List<Vector2Int> top = new List<Vector2Int>();
        List<Vector2Int> bot = new List<Vector2Int>();
        List<Vector2Int> left = new List<Vector2Int>();
        List<Vector2Int> right = new List<Vector2Int>();
        List<Vector2Int> topleft = new List<Vector2Int>();
        List<Vector2Int> topright = new List<Vector2Int>();
        List<Vector2Int> botright = new List<Vector2Int>();
        List<Vector2Int> botleft = new List<Vector2Int>();

        foreach (var position in floorPositions)
        {
            for (int i = 0; i < Direction2D.Length; i++)
            {
                Vector2Int _isWallPosition = position + Direction2D[i];
                if (!floorPositions.Contains(_isWallPosition))
                {
                    // switch (i){
                    //     case 0:  top.Add(_isWallPosition); break;
                    //     case 1:  bot.Add(_isWallPosition); break;
                    //     case 2:  left.Add(_isWallPosition); break;
                    //     case 3:  right.Add(_isWallPosition); break;
                    // }

                    if (i == 2)
                    {
                        left.Add(_isWallPosition);

                    }
                    if (i == 3)
                    {
                        right.Add(_isWallPosition);

                    }
                    if (i == 0)
                    {
                        top.Add(_isWallPosition);

                    }
                    if (i == 1)
                    {
                        bot.Add(_isWallPosition);

                    }
                }
            }
        }

        for (int i = 0; i < right.Count; i++)
        {
            if (top.Contains(right[i]))
            {
                topright.Add(right[i]);

            }
            if (bot.Contains(right[i]))
            {
                botright.Add(right[i]);

            }

        }
        for (int i = 0; i < left.Count; i++)
        {
            if (top.Contains(left[i]))
            {
                topleft.Add(left[i]);


            }
            if (bot.Contains(left[i]))
            {
                botleft.Add(left[i]);

            }
        }
        return (top, bot, left, right, topleft, topright, botright, botleft);
    }
    public List<Vector2Int> WallGenerator(List<Vector2Int> floorPosition)
    {
        var _tempListWallPosition = new List<Vector2Int>();
        foreach (var position in floorPosition)
        {
            for (int i = 0; i < Direction2D.Length; i++)
            {
                Vector2Int _isWallPosition = position + Direction2D[i];
                if (!floorPosition.Contains(_isWallPosition))
                {
                    _tempListWallPosition.Add(_isWallPosition);

                }

            }
        }
        return _tempListWallPosition;

    }



}
