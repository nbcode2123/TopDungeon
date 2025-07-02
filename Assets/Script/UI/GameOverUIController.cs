using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private float TimeDuration;
    [SerializeField] private GameObject LevelUI;
    private TextMeshProUGUI LevelUIText;
    [SerializeField] private GameObject StageUI;
    private TextMeshProUGUI StageUIText;

    [SerializeField] public GameObject GoldUI;
    private TextMeshProUGUI GoldUIText;
    [SerializeField] private GameObject EnemyUI;
    private TextMeshProUGUI EnemyUIText;
    [SerializeField] public GameObject GameOverCanvas;
    [SerializeField] public GameObject ReStartBtn;
    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
        ObserverManager.AddListener("Game Complete", TurnOnGameOverCanvas);



    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("Game Complete", TurnOnGameOverCanvas);
    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("Game Complete", TurnOnGameOverCanvas);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        LevelUIText = LevelUI.GetComponent<TextMeshProUGUI>();
        StageUIText = StageUI.GetComponent<TextMeshProUGUI>();
        GoldUIText = GoldUI.GetComponent<TextMeshProUGUI>();
        EnemyUIText = EnemyUI.GetComponent<TextMeshProUGUI>();





    }
    public void ReStartBtnActive()
    {
        GameManager.Instance.ReturnToLobby();
        SceneManager.sceneLoaded += OnLobbySceneLoaded;

        SceneManager.LoadScene("MenuScene");


    }

    public void TurnOnGameOverCanvas()
    {
        StartCoroutine(GameOverPropertyUpdate());

    }
    private void OnLobbySceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LobbyScene")
        {
            // Notify sau khi scene đã load xong
            ObserverManager.Notify("LobbySceneLoaded");
            GameManager.Instance.CurrentScene = "LobbyScene";

            // Gỡ đăng ký sau khi xong, tránh gọi nhiều lần
            SceneManager.sceneLoaded -= OnLobbySceneLoaded;
        }
    }

    public IEnumerator GameOverPropertyUpdate()
    {
        yield return new WaitForSeconds(1);
        GameOverCanvas.SetActive(true);
        yield return StartCoroutine(LevelUICounterUpdate(DungeonController.Instance.Level));
        yield return StartCoroutine(StageUICounterUpdate(DungeonController.Instance.Stage));
        yield return StartCoroutine(GoldUICounterUpdate(DungeonController.Instance.GoldCounter));
        yield return StartCoroutine(EnemyUICounterUpdate(DungeonController.Instance.EnemyCounter));
        ReStartBtn.SetActive(true);
        UIManager.Instance.PlayerStatsCanvas.SetActive(false);

    }

    public IEnumerator LevelUICounterUpdate(int endLevel)
    {
        float _elapsed = 0f;
        while (_elapsed < TimeDuration)
        {
            _elapsed += Time.deltaTime;
            float t = _elapsed / TimeDuration;
            int currentValue = Mathf.FloorToInt(Mathf.Lerp(0, endLevel, t));
            LevelUIText.text = currentValue.ToString();
            yield return null;
        }
        LevelUIText.text = endLevel.ToString();
    }
    public IEnumerator StageUICounterUpdate(int endStage)
    {

        float _elapsed = 0f;
        while (_elapsed < TimeDuration)
        {
            _elapsed += Time.deltaTime;
            float t = _elapsed / TimeDuration;
            int currentValue = Mathf.FloorToInt(Mathf.Lerp(0, endStage, t));
            StageUIText.text = currentValue.ToString();
            yield return null;
        }
        StageUIText.text = endStage.ToString();


    }

    public IEnumerator GoldUICounterUpdate(int endGoldCounter)
    {
        float _elapsed = 0f;
        while (_elapsed < TimeDuration)
        {
            _elapsed += Time.deltaTime;
            float t = _elapsed / TimeDuration;
            int currentValue = Mathf.FloorToInt(Mathf.Lerp(0, endGoldCounter, t));
            GoldUIText.text = currentValue.ToString();
            yield return null;
        }
        GoldUIText.text = endGoldCounter.ToString();
    }
    public IEnumerator EnemyUICounterUpdate(int endEnemyCounter)
    {
        float _elapsed = 0f;
        while (_elapsed < TimeDuration)
        {
            _elapsed += Time.deltaTime;
            float t = _elapsed / TimeDuration;
            int currentValue = Mathf.FloorToInt(Mathf.Lerp(0, endEnemyCounter, t));
            EnemyUIText.text = currentValue.ToString();
            yield return null;
        }
        EnemyUIText.text = endEnemyCounter.ToString();
    }
}
