using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendingMachineEvent : MonoBehaviour
{
    public GameObject DropPosition;
    public GameObject ConfirmDialog;
    public bool isActive = true;
    public int Price;


    // Start is called before the first frame update
    void Start()
    {
        // gameObject.SetActive(false);
        isActive = false;
        ConfirmDialog.SetActive(false);




    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        ObserverManager.AddListener("Map Generator Complete", StartDungeon);
        ObserverManager.AddListener("Stage Complete", StartDungeon);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isActive == true)
        {
            ConfirmDialog.SetActive(true);
            ConfirmDialog.GetComponent<TextMeshProUGUI>().text = $"Nhấn [E] để mua với giá {Price}";

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isActive == true)
        {
            ConfirmDialog.SetActive(false);
        }

    }
    public void BuyingItem()
    {
        DungeonController.Instance.DecreaseGoldCounter(Price);
        DropSystem.Instance.VendingMachineDropItem(DropPosition.transform.position);
        ConfirmDialog.SetActive(false);
        isActive = false;
    }
    public void StartDungeon()
    {
        isActive = true;
        Price = Random.Range(20, 40);


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyUp(KeyCode.E) && DungeonController.Instance.GoldCounter >= Price && isActive == true)
        {
            BuyingItem();
        }
    }
}
