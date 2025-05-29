using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeTrigger : MonoBehaviour, IColliderTrigger
{

    public event Action OnEnterTrigger;
    public event Action OnExitTrigger;
    public event Action OnStayTrigger;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnEnterTrigger?.Invoke();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnExitTrigger?.Invoke();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnStayTrigger?.Invoke();
        }

    }
}
