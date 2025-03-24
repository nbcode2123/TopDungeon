using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRangeTrigger : MonoBehaviour, IColliderTrigger, IColliderDetectObject
{

    public event Action OnEnterTrigger;
    public event Action OnExitTrigger;
    public event Action OnStayTrigger;

    public event Action<GameObject> DectectObject;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnEnterTrigger?.Invoke();
            DectectObject?.Invoke(collision.gameObject);

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnExitTrigger?.Invoke();
        }

    }
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         OnEnterTrigger?.Invoke();
    //         DectectObject?.Invoke(other.gameObject);
    //     }

    // }


}
