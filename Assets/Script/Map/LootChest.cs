using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootChest : MonoBehaviour
{
    public int RoomChessIndex;
    public int CoinValue;
    public bool isOpen = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isOpen == false)
        {
            gameObject.GetComponent<Animator>().Play("Open");
            isOpen = true;
            Debug.Log(other.name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DropItem()
    {
        DropSystem.Instance.DropWeapon(gameObject.transform.position);
    }

}
