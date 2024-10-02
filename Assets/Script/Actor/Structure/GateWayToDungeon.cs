using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneManager))]
public class GateWayToDungeon : MonoBehaviour
{
    public GameObject UI_GateWayBegin;
    // Start is called before the first frame update
    void Start()
    {
        UI_GateWayBegin.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        UI_GateWayBegin.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (UI_GateWayBegin != null)
        {
            UI_GateWayBegin.SetActive(false);

        }
        else return;


    }
}

