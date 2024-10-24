using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    void Awake()
    {
        Listeners.Clear();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Observer Subject  
    public static Dictionary<string, List<Action<object[]>>> Listeners = new Dictionary<string, List<Action<object[]>>>();
    public static void AddListener(string name, Action<object[]> callback)
    {
        if (!Listeners.ContainsKey(name))
        {
            Listeners.Add(name, new List<Action<object[]>>());
            Listeners[name].Add(callback);
        }
        else if (Listeners.ContainsKey(name))
        {
            Listeners[name].Add(callback);

        }
    }
    public static void RemoveListener(string name, Action<object[]> callback)
    {
        if (!Listeners.ContainsKey(name))
            return;
        if (Listeners.ContainsKey(name))
        {
            Listeners[name].Remove(callback);

        }
        if (Listeners[name].Count == 0)
        {
            Listeners.Remove(name);
        }

    }
    public static void Notify(string name, params object[] data)
    {
        if (!Listeners.ContainsKey(name))
        {
            return;

        }
        foreach (var ListenerName in Listeners[name])
        {
            try
            {
                ListenerName?.Invoke(data);

            }
            catch (Exception e)
            {

                Debug.LogError("Observer problem " + e + ListenerName);
            }



        }
    }
    #endregion
}
