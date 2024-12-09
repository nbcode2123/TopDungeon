using UnityEngine;

namespace Script.Map
{
    [CreateAssetMenu(fileName = "RoomPrefab", menuName = "Data/RoomPrefab")]

    public class RoomPrefab : ScriptableObject
    {
        // Start is called before the first frame update
        public int RoomSize = 10;


    }
}
