
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CorridorGenerator : MonoBehaviour
{
    private Vector2Int StartPosition = Vector2Int.zero; // vị trí đầu tiên 
    // public RoomPrefab data;
    [SerializeField]
    public int corridorLength, corridorcount;
    public List<Vector2Int> Direction() // tạo ra 1 list direction làm sao để các room không quay đầu lại 
    {
        List<Vector2Int> _ListDirection = new List<Vector2Int>();
        Vector2Int _temporaryDirection;
        _ListDirection.Add(Direction2D.GetRandomDirection());
        List<Vector2Int> _ListPosition = new List<Vector2Int>();
        Vector2Int _tempPosition;
        _ListPosition.Add(Vector2Int.zero);
        _ListPosition.Add(_ListPosition[0] + _ListDirection[0]);
        for (int i = 1; i < corridorcount; i++)
        {
            List<Vector2Int> _tempListDirection = new List<Vector2Int>();
            foreach (var item in Direction2D.cardinalDirection)
            {
                _tempListDirection.Add(item);

            }
            bool _tempExit;
            do
            {
                _tempListDirection.Remove(_ListDirection[i - 1] * -1);
                int random = Random.Range(0, _tempListDirection.Count);
                _temporaryDirection = _tempListDirection[random];
                _tempListDirection.Remove(_temporaryDirection);

                _tempPosition = _ListPosition[i] + _temporaryDirection;

                if (!_ListPosition.Contains(_tempPosition))
                {
                    _ListPosition.Add(_tempPosition);

                    _tempExit = false;
                }
                else _tempExit = true;
            }
            while (_tempExit);
            _ListDirection.Add(_temporaryDirection);

        }
        return _ListDirection;
    }

    public HashSet<Vector2Int> CreateCorridor(List<Vector2Int> roomPositionStart)

    {
        List<Vector2Int> ListDirection = Direction();
        roomPositionStart.Add(Vector2Int.zero);// them vi tri dau tien vao vi tri cua phong
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>(); // tập hợp tất cả các vị trí hành lang dây là list trả về để sử dụng 
        var currentPosition = Vector2Int.zero; // gán vt hiện tại bằng vị trí bắt đầu
        for (int i = 0; i < corridorcount; i++) // lặp bằng số hành lang
        {
            Vector2Int direction = ListDirection[i];
            int index = Direction2D.cardinalDirection.IndexOf(direction);
            var corridor = Generation_algorithms.RandomWalkCorridor(currentPosition, corridorLength, direction);
            currentPosition = corridor[corridor.Count - 1]; // vị trí cuối cùng của mỗi hành lang vừa tạo ở dòng trên

            CorridorExpand(corridor, index); // mở rộng chiều rông của hành lang 
            corridors.UnionWith(corridor);
            roomPositionStart.Add(currentPosition);


        }


        // to phan corridor bi thieu chi mang tinh chat trang tri
        foreach (var position in roomPositionStart)
        {
            var corridorwidth = GameManager.Instance.CorridorWidth;
            var tempValue = corridorwidth / 2;

            for (int i = -tempValue; i <= tempValue; i++)
            {
                for (int j = -tempValue; j <= tempValue; j++)
                {
                    corridors.Add(new Vector2Int(position.x + i, position.y + j));
                }


            }
        }



        return corridors;
    }
    private void CorridorExpand(List<Vector2Int> corridors, int positioninDirection2d)
    {
        // int corridorwidth = GameController.instance.CorridorWidth;
        int corridorwidth = GameManager.Instance.CorridorWidth;
        Vector2Int direction1 = new Vector2Int();
        Vector2Int direction2 = new Vector2Int();
        if (positioninDirection2d == 0 || positioninDirection2d == 2)
        {
            direction1 = Direction2D.cardinalDirection[1];
            direction2 = Direction2D.cardinalDirection[3];
        }
        else if (positioninDirection2d == 1 || positioninDirection2d == 3)
        {
            direction1 = Direction2D.cardinalDirection[0];
            direction2 = Direction2D.cardinalDirection[2];
        }
        List<Vector2Int> tempCorridorExpand = new List<Vector2Int>();
        foreach (var position in corridors)
        {
            var currentPosition1 = position;
            var currentPosition2 = position;
            for (int i = 0; i < corridorwidth / 2; i++)
            {
                var tempPosition1 = currentPosition1 + direction1;
                tempCorridorExpand.Add(tempPosition1);
                currentPosition1 = tempPosition1;

            }
            for (int i = 0; i < corridorwidth / 2; i++)
            {
                var tempPosition2 = currentPosition2 + direction2;
                tempCorridorExpand.Add(tempPosition2);
                currentPosition2 = tempPosition2;

            }
        }
        foreach (var position in tempCorridorExpand)
        {
            corridors.Add(position);

        }
    }



}