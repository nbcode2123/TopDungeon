using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeArea : MonoBehaviour, IColliderTrigger, IColliderDetectObject
{
    public bool isRight = true;
    public Action EyeAreaOnTriggerStay;

    public event Action OnEnterTrigger;
    public event Action OnExitTrigger;
    public event Action OnStayTrigger;
    public event Action<GameObject> DetectObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LookingAtPlayer(other.gameObject);
            DetectObject?.Invoke(other.gameObject);
            OnEnterTrigger?.Invoke();

        }
    }
    private void LookingAtPlayer(GameObject player)
    {
        if (gameObject.transform.parent.position.x < player.transform.position.x && isRight == false)
        {

            gameObject.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
            isRight = true;
        }
        else if (gameObject.transform.parent.position.x > player.transform.position.x && isRight == true)
        {
            gameObject.transform.parent.rotation = Quaternion.Euler(0, 180, 0);
            isRight = false;
        }

    }
}
