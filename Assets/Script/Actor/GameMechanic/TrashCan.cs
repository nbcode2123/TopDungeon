using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public static TrashCan Instance { private set; get; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
        }
    }
    public List<GameObject> TrashObj = new List<GameObject>();
    public void ClearTrashCan()
    {
        foreach (var item in TrashObj)
        {
            Destroy(item);
        }
    }
}
