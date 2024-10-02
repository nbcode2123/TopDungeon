
using System.Collections.Generic;
using UnityEngine;
public class Generation_algorithms
{
    public static HashSet<Vector2Int> RoomGenerator(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> floorDungeon = new HashSet<Vector2Int>(); // tạo 1 tập hợp của floor
        HashSet<Vector2Int> listStartPosition = new HashSet<Vector2Int>();
        var previousPosition2 = startPosition;
        var previousPosition1 = startPosition;
        floorDungeon.Add(startPosition);
        listStartPosition.Add(startPosition);
        for (int i = 0; i < walkLength / 2; i++)
        {
            var newPosition2 = previousPosition1 + Direction2D.cardinalDirection[2];
            floorDungeon.Add(newPosition2);
            listStartPosition.Add(newPosition2);
            previousPosition1 = newPosition2;
        }
        for (int i = 0; i < walkLength / 2; i++)
        {
            var newPosition2 = previousPosition2 + Direction2D.cardinalDirection[0];
            floorDungeon.Add(newPosition2);
            listStartPosition.Add(newPosition2);
            previousPosition2 = newPosition2;
        }
        foreach (var position in listStartPosition)
        {
            // var previousPositionAxis = position;
            var previousPositionAxis1 = position;
            var previousPositionAxis2 = position;
            for (int i = 0; i < walkLength / 2; i++) // lặp để lấy số floor bằng số bước đi 
            {
                var newPosition3 = previousPositionAxis1 + Direction2D.cardinalDirection[1];// vị trí mới bằng vị trí hiện tại công với hướng 
                floorDungeon.Add(newPosition3);// thêm vị trí mới vào tập hợp
                previousPositionAxis1 = newPosition3;// gán vị trí hiện tại bằng vị trí mới
            }
            for (int i = 0; i < walkLength / 2; i++) // lặp để lấy số floor bằng số bước đi 
            {
                var newPosition4 = previousPositionAxis2 + Direction2D.cardinalDirection[3];// vị trí mới bằng vị trí hiện tại công với hướng 
                floorDungeon.Add(newPosition4);// thêm vị trí mới vào tập hợp
                previousPositionAxis2 = newPosition4;// gán vị trí hiện tại bằng vị trí mới
            }
        }

        return floorDungeon; // trả lại tập hợp các vị trí là floor
    }
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength, Vector2Int direction) // random hành lang
    {

        List<Vector2Int> corridor = new List<Vector2Int>(); // vị trí floor hành lang
        // var direction = Direction2D.GetRandomDirection(); // lấy 1 vị trí bất kì
        HashSet<Vector2Int> corridorStartPosition = new HashSet<Vector2Int>(); // tập hợp các vị trí bắt đầu của corridor
        var currentStartPosition = startPosition;
        corridorStartPosition.Add(currentStartPosition);
        foreach (var StartPosition in corridorStartPosition)
        {
            var currenposition = StartPosition; // gán vị trị hiện tại bằng bị trí bắt đầu
            corridor.Add(currenposition);
            for (int j = 0; j < corridorLength; j++) // vẽ 1 hành lang theo length
            {
                currenposition += direction; // vị trí hiện tại cộng  thêm 1 ô theo hướng
                corridor.Add(currenposition);// thêm vị trí hiện tại vào hành lang
            }
        }
        return corridor;
    }
}
public static class Direction2D // hướng 2d
{
    public static List<Vector2Int> cardinalDirection = new List<Vector2Int>(){ // list hướng 4 chiều 
        new Vector2Int(0,1),//UP
        new Vector2Int(1,0),// right
        new Vector2Int(0,-1),//down
        new Vector2Int(-1,0)//left
    };
    public static List<Vector2Int> eightcompassdirections = new List<Vector2Int>(){
        new Vector2Int(0,1),//UP
        new Vector2Int(1,1),
        new Vector2Int(1,0),// right
        new Vector2Int(1,-1),
        new Vector2Int(0,-1),//down
        new Vector2Int(-1,-1),
        new Vector2Int(-1,0),//left
        new Vector2Int(-1,1)
    };
    public static Vector2Int GetRandomDirection()
    {
        return cardinalDirection[Random.Range(0, cardinalDirection.Count)]; // lấy 1 hướng bất kì
    }
    public static Vector2Int GetRandomDirectionExcept(Vector2Int directions)
    {

        List<Vector2Int> tempListDirection = new List<Vector2Int>(cardinalDirection);

        tempListDirection.Remove(directions);

        return tempListDirection[Random.Range(0, tempListDirection.Count)];

    }


}
