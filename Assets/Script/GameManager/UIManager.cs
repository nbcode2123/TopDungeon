using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        ObserverManager.AddListener("EnterNewRoom ", AlertWhenEnterNewRoom);
    }


    void OnDestroy()
    {
        ObserverManager.RemoveListener("EnterNewRoom ", AlertWhenEnterNewRoom);
    }
    public void AlertWhenEnterNewRoom()
    {
        Debug.Log("Enter new  Room");
    }



}
