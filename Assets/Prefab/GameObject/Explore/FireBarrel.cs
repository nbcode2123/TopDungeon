using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrel : MonoBehaviour
{
    public GameObject Explode;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<DamageCalculator>().OnDeath += ExplodeAreaActive;
        Explode.GetComponent<ExplodeArea>().Damage = gameObject.GetComponent<IAttackable>().GetAttackDamage();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExplodeAreaActive()
    {
        Explode.SetActive(true);
        gameObject.SetActive(false);


    }
    private void OnDisable()
    {
        gameObject.GetComponent<DamageCalculator>().OnDeath -= ExplodeAreaActive;

    }
    private void OnDestroy()
    {
        gameObject.GetComponent<DamageCalculator>().OnDeath -= ExplodeAreaActive;

    }
}
