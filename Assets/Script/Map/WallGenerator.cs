using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    public HashSet<Vector2Int> wallPosition_right;
    public HashSet<Vector2Int> wallPosition_left;
    public HashSet<Vector2Int> wallPosition_top;
    public HashSet<Vector2Int> wallPosition_bottom;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ClearWallMap()
    {
        wallPosition_right = new HashSet<Vector2Int>();
        wallPosition_left = new HashSet<Vector2Int>();
        wallPosition_bottom = new HashSet<Vector2Int>();
        wallPosition_top = new HashSet<Vector2Int>();


    }
    public void CreateWall(HashSet<Vector2Int> floorPosition) // từ vị trí của floor lấy ra vị trí wall
    {
        ClearWallMap();
        HashSet<Vector2Int> wallPosition = new HashSet<Vector2Int>(); // hashset chứa vị trí của tường 
        foreach (var floor in floorPosition)// với mỗi vị tri floor
        {
            foreach (var randomdirection in Direction2D.cardinalDirection)// xét  từng hướng trong 4 hướng trên dưới trái phải
            {
                var neighbourPosition = floor + randomdirection; // vị trí bên cạnh bằng vị trí floor + hướng
                if (floorPosition.Contains(neighbourPosition) == false) // nếu vi trí bên cạnh không nằm trong floor => wall
                {
                    wallPosition.Add(neighbourPosition); // them wall vao hashset
                    if (randomdirection == Direction2D.cardinalDirection[1]) // nếu mà vị trí tường là bên phải
                    {
                        wallPosition_right.Add(neighbourPosition);
                    }
                    if (randomdirection == Direction2D.cardinalDirection[3])//nếu mà vị trí tường là bên trái
                    {
                        wallPosition_left.Add(neighbourPosition);
                    }
                    if (randomdirection == Direction2D.cardinalDirection[0])//nếu mà vị trí tường là bên trên
                    {
                        wallPosition_top.Add(neighbourPosition);
                    }
                    if (randomdirection == Direction2D.cardinalDirection[2])//nếu mà vị trí tường là bên dưới
                    {
                        wallPosition_bottom.Add(neighbourPosition);
                    }

                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
