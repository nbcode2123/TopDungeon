using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private GameObject Player;
    private event Action<GameObject> OnDetectPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Player == null)
        {
            Player = other.gameObject;
            OnDetectPlayer?.Invoke(Player);

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Player == null)
        {
            Player = other.gameObject;
            OnDetectPlayer?.Invoke(Player);
        }
    }
    public void RegisterOnDetectPlayer(Action<GameObject> callback)
    {
        OnDetectPlayer += callback;
    }
    public void UnRegisterOnDetectPlayer(Action<GameObject> callback)
    {
        OnDetectPlayer -= callback;
    }
}
