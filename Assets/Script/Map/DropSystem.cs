using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class DropSystem : MonoBehaviour
{
    public static DropSystem Instance { private set; get; }
    public float DropRate = 30;
    public List<GameObject> ItemDrop = new List<GameObject>();
    // public List<GameObject> ChestDrop = new List<GameObject>();
    public List<GameObject> VendingMachineStorage = new List<GameObject>();

    public WeaponStorage WeaponStorage;


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
            TrashCan.Instance.TrashObj.Add(_itemDrop);
        }




    }
    public void DropItem(Vector3 dropPosition, GameObject dropObject)
    {
        GameObject _tempItem = Instantiate(dropObject, dropPosition, Quaternion.identity);
        TrashCan.Instance.TrashObj.Add(_tempItem);
    }
    public void VendingMachineDropItem(Vector3 dropPosition)
    {
        GameObject _tempItem = Instantiate(VendingMachineStorage[Random.Range(0, VendingMachineStorage.Count)], dropPosition, Quaternion.identity);
        TrashCan.Instance.TrashObj.Add(_tempItem);

    }

    public void DropWeapon(Vector3 dropPosition)
    {
        var _random = Random.Range(0, 101);
        GameObject _tempWeapon;
        if (_random <= WeaponStorage.CommonRate)
        {
            int _index = Random.Range(0, WeaponStorage.CommonWeapon.Count);
            _tempWeapon = WeaponStorage.CommonWeapon[_index];
            DropItem(dropPosition, _tempWeapon);


        }
        else if (_random > WeaponStorage.CommonRate && _random <= WeaponStorage.CommonRate + WeaponStorage.RareRate)
        {
            int _index = Random.Range(0, WeaponStorage.RareWeapon.Count);
            _tempWeapon = WeaponStorage.RareWeapon[_index];
            DropItem(dropPosition, _tempWeapon);

        }
        else if (_random > WeaponStorage.CommonRate + WeaponStorage.RareRate && _random <= 100)
        {
            int _index = Random.Range(0, WeaponStorage.EpicWeapon.Count);
            _tempWeapon = WeaponStorage.EpicWeapon[_index];
            DropItem(dropPosition, _tempWeapon);
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
}
