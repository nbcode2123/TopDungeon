using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMarkRoomIndex : MonoBehaviour
{
    public int RoomIndex;
    public int EnemyIndex;
    public void OnDeath()
    {
        ObserverManager.Notify("EnemyDie", gameObject);
        DungeonController.Instance.EnemyCounter++;
    }


    void OnDisable()
    {
        // ObserverManager.Notify("EnemyDie", gameObject);


    }
    void OnDestroy()
    {
        // ObserverManager.Notify("EnemyDie", gameObject);

    }



}
