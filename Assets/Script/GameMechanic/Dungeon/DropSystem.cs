using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DropSystem : MonoBehaviour
{
    public static DropSystem Instance { private set; get; }
    public float DropRate = 30;

    public List<GameObject> ItemDrop = new List<GameObject>();
    public List<GameObject> WeaponDrop = new List<GameObject>();
    void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void DropItemWhenDeath(GameObject objectDropItem)
    {
        var _random = Random.Range(0, 101);
        if (_random <= DropRate)
        {
            GameObject _itemDrop = Instantiate(ItemDrop[Random.Range(0, ItemDrop.Count)], objectDropItem.transform.position, Quaternion.identity);


        }
        // GameObject _itemDrop = Instantiate(ItemDrop[Random.Range(0, ItemDrop.Count)], objectDropItem.transform.position, Quaternion.identity);
        // GameObject _itemDrop = Instantiate(ItemDrop[0], objectDropItem.transform.position, Quaternion.identity);



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
