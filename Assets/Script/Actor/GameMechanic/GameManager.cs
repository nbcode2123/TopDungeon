
using UnityEngine;




public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject Player;
    public Camera Camera;
    public GameObject CammeraObj;
    public GameObject CinemaCamera;
    public string CurrentScene;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        CurrentScene = "LobbyScene";
        ObserverManager.AddListener("MenuScene", ReturnToMenu);

    }

    public void ReturnToLobby()
    {
        Destroy(Player);
        CinemaCamera = PropertyLobby.Instance.CinemachineCamera;

    }
    public void ReturnToMenu()
    {
        Destroy(Player);


    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("MenuScene", ReturnToMenu);


    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("MenuScene", ReturnToMenu);


    }


}
