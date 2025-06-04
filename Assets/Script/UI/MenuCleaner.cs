using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ObserverManager.AddListener("InMenuScene", DestroyThisGameobj);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyThisGameobj()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        // ObserverManager.AddListener("InMenuScene", DestroyThisGameobj);

    }

}
