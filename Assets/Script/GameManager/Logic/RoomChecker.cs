using UnityEngine;

namespace Script.GameManager.Logic
{
    public class RoomChecker : MonoBehaviour
    {
        public int RoomIndex;
        public void OnDisable()
        {
            ObserverManager.Notify("Enemy Die", RoomIndex, gameObject);

        }

    }
}
