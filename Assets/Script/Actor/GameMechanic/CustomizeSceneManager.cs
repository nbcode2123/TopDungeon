using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizeSceneManager : MonoBehaviour
{



    // Start is called before the first frame update
    public void GoToDungeonScene()
    {

        SceneManager.LoadSceneAsync("DungeonScene");
        // ObserverManager.Notify("DungeonScene");

    }
    public void BackToLobby()
    {
        SceneManager.LoadScene("LobbyScene");
        ObserverManager.Notify("LobbyScene");


    }
    public void BackToMenu()
    {
        Destroy(gameObject);
        ObserverManager.Notify("MenuScene");
        SceneManager.LoadScene("MenuScene");


    }
    public void ExitGame()
    {

        // EditorApplication.isPlaying = false;
        Application.Quit(); // Dành cho bản build

    }
    public void GoToDungeon()
    {

        // SceneManager.LoadScene("LoadingScene");
        // SceneManager.sceneLoaded += LoadNewScene;


    }
    // public void LoadNewScene(Scene scene, LoadSceneMode loadSceneMode)
    // {
    //     GameManager.Instance.Player = GameObject.Find("Player");
    //     GameManager.Instance.Player.transform.position = Vector3.zero;
    //     GameManager.Instance.Camera = PropertyDungeon.Instance.Camera;
    //     GameManager.Instance.CinemaCamera = PropertyDungeon.Instance.CinemaCamera;
    //     GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().Follow = GameManager.Instance.Player.transform;
    //     GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
    //     DungeonController.Instance.InitializeDungeonValue();

    //     MapProcessor.Instance.MapGenerator();
    // }





}
