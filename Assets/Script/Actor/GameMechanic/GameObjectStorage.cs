using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectStorage : MonoBehaviour
{
    public static GameObjectStorage Instance { private set; get; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public GameObject ChestPrefab;
    public GameObject TransferGate;

}
