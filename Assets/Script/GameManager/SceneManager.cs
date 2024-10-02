using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizeSceneManager : MonoBehaviour
{
    public List<SceneAsset> ListScene = new List<SceneAsset>();

    private void Start()
    {
    }

    // Start is called before the first frame update
    public void Continue()
    {

        SceneManager.LoadScene("DungeonScene");

    }
    public void NewGame()
    {
        SceneManager.LoadScene("LobbyScene");

    }
    public void ExitGame()
    {

        EditorApplication.isPlaying = false;


    }
    public void GoToDungeon()
    {

        SceneManager.LoadScene("DungeonScene");
        GameManager.Instance.Player = GameObject.Find("Player");







    }



}
