using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootItemController : MonoBehaviour
{
    public float DropRate;
    public int Value;
    public float MoveSpeed;
    public float Threshold = 0.5f;
    public bool isGold;
    void Update()
    {

    }
    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FlyToPlayer(other.gameObject);
        }

    }
    public virtual void FlyToPlayer(GameObject Player)
    {
        var _direction = new Vector3(Player.transform.position.x - gameObject.transform.position.x, Player.transform.position.y - gameObject.transform.position.y, 0);
        gameObject.transform.position += _direction.normalized * MoveSpeed * Time.deltaTime;
        if (Vector2.Distance(new Vector2(Player.transform.position.x, Player.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <= Threshold)
        {
            CalculatorLootItem();
        }
    }
    public virtual void CalculatorLootItem()
    {

        DungeonController.Instance.IncreaseGoldCounter(Value);
        ObserverManager.Notify("Audio", "CoinLoot");


        Destroy(gameObject);

    }
}

