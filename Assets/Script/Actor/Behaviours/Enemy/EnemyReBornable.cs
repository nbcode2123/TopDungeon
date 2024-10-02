using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReBornable : MonoBehaviour
{
    public IActorStats ActorStats;
    void Start()
    {
        ActorStats = GetComponent<IActorStats>();


    }
    public void ReBornActor()
    {
        ActorStats.currentHeath = ActorStats.currentHeath;

    }
}
