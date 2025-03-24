using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }
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
    public List<GameObject> Room;
    public TileMapAssetConcept TilemapAssetConcept; //! về sau quản lý lại concept 

}
