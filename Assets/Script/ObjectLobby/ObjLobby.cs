using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLobby : MonoBehaviour
{
    public List<GameObject> ListLobbyObj = new List<GameObject>();
    public List<GameObject> CharacterLobby = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Start Dungeon", DisableObj);
        ObserverManager.AddListener("Continues", DisableObj);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisableObj()
    {


        for (int i = 0; i < ListLobbyObj.Count; i++)
        {
            if (ListLobbyObj[i] != null)
            {
                ListLobbyObj[i].SetActive(false);

            }

        }
        for (int i = 0; i < CharacterLobby.Count; i++)
        {
            if (CharacterLobby[i].CompareTag("Player") == false)
            {
                CharacterLobby[i].SetActive(false);

            }

        }


    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("Start Dungeon", DisableObj);
        ObserverManager.RemoveListener("Continues", DisableObj);


    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("Start Dungeon", DisableObj);
        ObserverManager.RemoveListener("Continues", DisableObj);


    }

}
