using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject Component;

    // Start is called before the first frame update
    void Start()
    {
        Component.SetActive(false);
        ObserverManager.AddListener("Start Dungeon", TurnOnVendingMachine);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnOnVendingMachine()
    {
        Component.SetActive(true);
    }
}
