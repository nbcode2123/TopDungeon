using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour, IColliderTrigger
{
    public Action AttackAreaTrigger;

    public event Action OnEnterTrigger;
    public event Action OnExitTrigger;
    public event Action OnStayTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnEnterTrigger?.Invoke();
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
