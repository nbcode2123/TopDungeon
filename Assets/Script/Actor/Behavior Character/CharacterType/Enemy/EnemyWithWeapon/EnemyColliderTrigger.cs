using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderTrigger : MonoBehaviour
{
    private Action<GameObject> OnEnterCollider;
    private Action OnExitCollider;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnEnterCollider?.Invoke(other.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnExitCollider?.Invoke();
        }
    }
    public void RegisOnEnterCollider(Action<GameObject> callback)
    {
        OnEnterCollider += callback;

    }
    public void UnRegisOnEnterCollider(Action<GameObject> callback)
    {
        OnEnterCollider -= callback;

    }
    public void RegisOnExitCollider(Action callback)
    {
        OnExitCollider += callback;

    }
    public void UnRegisOnExitCollider(Action callback)
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
