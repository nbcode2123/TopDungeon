using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    // Noi quan ly moi truong 
    public static EnvironmentManager Instance { get; private set; }
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
    public List<GameObject> ListRoom;
    public TileMapAssetConcept TilemapAssetConcept; //! về sau quản lý lại concept 

}
