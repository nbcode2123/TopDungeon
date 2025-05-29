using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public int Damage;
    public float TimeDelay;
    public Dictionary<GameObject, Coroutine> activeCoroutine = new Dictionary<GameObject, Coroutine>();
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
        if (other.CompareTag("Enemy") && !activeCoroutine.ContainsKey(other.gameObject))
        {
            Coroutine coroutine = StartCoroutine(DealDamageEachSecond(Damage, other.gameObject));
            activeCoroutine.Add(other.gameObject, coroutine);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && activeCoroutine.ContainsKey(other.gameObject))
        {
            StopCoroutine(activeCoroutine[other.gameObject]);
            activeCoroutine.Remove(other.gameObject);
        }
    }
    IEnumerator DealDamageEachSecond(int damage, GameObject enemyObject)
    {
        while (true)
        {
            enemyObject.GetComponent<IDamageable>().TakeDamage(damage);
            Debug.Log(enemyObject.name + "bi " + Damage + " damage moi giay ");
            yield return new WaitForSeconds(TimeDelay);
        }


    }


}
