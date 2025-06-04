using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTurretRangeAttackTrigger : MonoBehaviour
{
    private GameObject Target;

    public event Action<GameObject> OnEnterCollider;
    public event Action OnExitCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Target = other.gameObject;
            OnEnterCollider?.Invoke(Target);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Target = null;
            OnExitCollider?.Invoke();
        }

    }
    public void RegisterOnEnterCollider(Action<GameObject> callback)
    {
        OnEnterCollider += callback;
    }
    public void UnRegisterOnEnterCollider(Action<GameObject> callback)
    {
        OnEnterCollider -= callback;
    }
    public void RegisterOnExitCollider(Action callback)
    {
        OnExitCollider += callback;
    }
    public void UnRegisterOnExitCollider(Action callback)
    {
        OnExitCollider -= callback;
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
