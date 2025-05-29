using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dracular : PlayerStats
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // gameObject.GetComponent<PlayerDamageCalculator>().OnDeath += NotifyPlayerDie;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
    public void NotifyPlayerDie()
    {
        // ObserverManager.Notify("Game Complete");
    }
    private void OnDestroy()
    {
        // gameObject.GetComponent<PlayerDamageCalculator>().OnDeath -= NotifyPlayerDie;

    }
    public void OnDisable()
    {
        // gameObject.GetComponent<PlayerDamageCalculator>().OnDeath -= NotifyPlayerDie;

    }
}
