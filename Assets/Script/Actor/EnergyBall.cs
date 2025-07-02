using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : LootItemController
{
    private GameObject Player;

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FlyToPlayer(other.gameObject);
            Player = other.gameObject;
        }

    }
    public override void FlyToPlayer(GameObject Player)
    {
        var _direction = new Vector3(Player.transform.position.x - gameObject.transform.position.x, Player.transform.position.y - gameObject.transform.position.y, 0);
        gameObject.transform.position += _direction.normalized * MoveSpeed * Time.deltaTime;
        if (Vector2.Distance(new Vector2(Player.transform.position.x, Player.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <= Threshold)
        {
            CalculatorLootItem();
        }
    }
    public override void CalculatorLootItem()
    {
        Player.GetComponent<PlayerStats>().IncreaseCurrentEnergy(Value);
        ObserverManager.Notify("Audio", "CoinLoot");
        Destroy(gameObject);

    }
}
