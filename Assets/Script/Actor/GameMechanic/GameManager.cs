
using System.IO;
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
        ObserverManager.AddListener("Start Dungeon", PlayerSetToZero);
        ContinuesLevelCheck();

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
    public void PlayerSetToZero()
    {
        Player.transform.position = Vector2.zero;
    }
    public void ContinuesLevelCheck()
    {
        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");

        if (FileChecker.CheckFile(filePathConcept))
        {
            ObserverManager.Notify("Continues");
            // var _dataCharacter = DataLoader.DataCharacter();
            // Debug.Log(_dataCharacter.NameCharacter);
            // ObserverManager.Notify("Start Dungeon");

        }

    }



}
