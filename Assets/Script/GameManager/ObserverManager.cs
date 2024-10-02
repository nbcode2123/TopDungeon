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
    public static Dictionary<string, List<Action>> Listeners = new Dictionary<string, List<Action>>();
    public static void AddListener(string name, Action callback)
    {
        if (!Listeners.ContainsKey(name))
        {
            Listeners.Add(name, new List<Action>());
            Listeners[name].Add(callback);
        }
        else if (Listeners.ContainsKey(name))
        {
            Listeners[name].Add(callback);

        }
    }
    public static void RemoveListener(string name, Action callback)
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
    public static void Notify(string name)
    {
        if (!Listeners.ContainsKey(name))
        {
            return;

        }
        foreach (var ListenerName in Listeners[name])
        {
            try
            {
                ListenerName?.Invoke();

            }
            catch (Exception e)
            {

                Debug.LogError("Observer problem " + e + ListenerName);
            }



        }
    }
    #endregion
}
