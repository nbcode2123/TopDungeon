using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
    public List<GameObject> CharacterLobby;
    public List<Weapon> WeaponStorage;
    public List<Character> CharacterStorage;


}
[Serializable]
public class Weapon
{
    public int Id;
    public string Name;
    public GameObject Prefab;
}
[Serializable]
public class Character
{
    public int ID;
    public string Name;
    public GameObject Prefab;
}

