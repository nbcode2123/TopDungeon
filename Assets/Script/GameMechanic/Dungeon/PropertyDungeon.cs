using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyDungeon : MonoBehaviour
{
    public static PropertyDungeon Instance { get; private set; }
    public Camera Camera;
    public GameObject CinemaCamera;
    void Awake()
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
