using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
        SceneManager.sceneLoaded += LoadNewScene;


    }
    public void LoadNewScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        GameManager.Instance.Player = GameObject.Find("Player");
        GameManager.Instance.Camera = PropertyDungeon.Instance.Camera;
        GameManager.Instance.CinemaCamera = PropertyDungeon.Instance.CinemaCamera;
        GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().Follow = GameManager.Instance.Player.transform;
        GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        DungeonController.Instance.InitializeDungeonValue();

        ObserverManager.Notify("DungeonStart");


    }




}
