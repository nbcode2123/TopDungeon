using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        // for (int i = 0; i < TrashObj.Count; i++)
        // {
        //     if (TrashObj[i] == null)
        //     {
        //         TrashObj.Remove(TrashObj[i]);
        //         Destroy(TrashObj[i]);
        //     }
        //     else if (TrashObj[i] != null)
        //     {
        //         if (TrashObj[i].CompareTag("WeaponPlayer") == false)
        //         {
        //             TrashObj.Remove(TrashObj[i]);
        //             Destroy(TrashObj[i]);

        //         }
        //         else
        //         {
        //             TrashObj.Remove(TrashObj[i]);

        //         }
        //     }
        // }
        List<GameObject> toRemove = new List<GameObject>();
        for (int i = TrashObj.Count - 1; i >= 0; i--)
        {
            if (TrashObj[i] == null)
            {
                toRemove.Add(TrashObj[i]);
                TrashObj.RemoveAt(i); // Dùng RemoveAt cho nhanh hơn
            }
            else if (TrashObj[i] != null && TrashObj[i].CompareTag("WeaponPlayer") == false)
            {
                toRemove.Add(TrashObj[i]);
                TrashObj.RemoveAt(i); // Dùng RemoveAt cho nhanh hơn
            }


        }
        foreach (var obj in toRemove)
        {
            Destroy(obj);
        }
        TrashObj.Clear();

    }
}
