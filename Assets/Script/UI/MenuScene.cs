using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject NewGameCanvas;
    public GameObject ContinuesCanvas;
    public GameObject ExitCanvas;
    public GameObject ContinuesBtn;
    public GameObject ScoreCanvas;
    public GameObject TimeText;
    public GameObject EnemyText;
    public GameObject StageText;
    public GameObject LevelText;
    private TextMeshProUGUI TimeTxt;
    private TextMeshProUGUI EnemyTxt;
    private TextMeshProUGUI StageTxt;
    private TextMeshProUGUI LevelTxt;
    // Start is called before the first frame update
    void Start()
    {
        TimeTxt = TimeText.GetComponent<TextMeshProUGUI>();
        EnemyTxt = EnemyText.GetComponent<TextMeshProUGUI>();
        StageTxt = StageText.GetComponent<TextMeshProUGUI>();
        LevelTxt = LevelText.GetComponent<TextMeshProUGUI>();

        Scene currentScene = SceneManager.GetActiveScene();
        ScoreCanvas.SetActive(false);

        foreach (var obj in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            // Bỏ qua object không thuộc scene nào (tức là asset)
            if (!obj.scene.IsValid()) continue;

            // Chỉ xoá object thuộc scene "DontDestroyOnLoad" (không thuộc scene hiện tại)
            if (obj.scene != currentScene && obj.hideFlags == HideFlags.None)
            {
                if (obj != null)
                {
                    Destroy(obj);

                }
            }
        }
        ContinuesCanvas.SetActive(false);
        NewGameCanvas.SetActive(false);
        ExitCanvas.SetActive(false);
        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");
        if (FileChecker.CheckFile(filePathConcept))
        {
            ContinuesBtn.SetActive(true);

        }
        else
        {
            ContinuesBtn.SetActive(false);
        }
        string filePathScore = Path.Combine(Application.persistentDataPath, "Score.json");
        if (FileChecker.CheckFile(filePathScore))
        {
            var _lastScore = DataLoader.DataScore();
            TimeTxt.text = FormatTime(_lastScore.Time);
            // TimeTxt.text = _lastScore.Time.ToString();
            EnemyTxt.text = _lastScore.Enemy.ToString();
            StageTxt.text = _lastScore.Stage.ToString();
            LevelTxt.text = _lastScore.Level.ToString();
        }
        else
        {
            TimeTxt.text = "0";
            // TimeTxt.text = _lastScore.Time.ToString();
            EnemyTxt.text = "0";
            StageTxt.text = "0";
            LevelTxt.text = "0";
        }



    }
    string FormatTime(float timeInSeconds)
    {
        int totalMinutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int hours = totalMinutes / 60;
        int minutes = totalMinutes % 60;
        return string.Format("{0:D2}:{1:D2}", hours, minutes); // "hh:mm"
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LobbyScene()
    {
        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");
        string filePath = Path.Combine(Application.persistentDataPath, "DungeonController.json");
        string filePathDirection = Path.Combine(Application.persistentDataPath, "Direction.json");
        string filePathCharacter = Path.Combine(Application.persistentDataPath, "Character.json");

        FileHelper.DeleteFile(filePathConcept);
        FileHelper.DeleteFile(filePath);
        FileHelper.DeleteFile(filePathDirection);
        FileHelper.DeleteFile(filePathCharacter);

        SceneManager.LoadScene("LobbyScene");
    }
    public void ExitGame()
    {
        // EditorApplication.isPlaying = false;
        Application.Quit(); // Dành cho bản build
    }
    public void Continues()
    {
        SceneManager.LoadSceneAsync("LobbyScene");


    }
    public void TurnOnNewGameCanvas()
    {
        NewGameCanvas.SetActive(true);
    }
    public void TurnOnContinuesCanvas()
    {
        ContinuesCanvas.SetActive(true);
    }
    public void TurnOnExitCanvas()
    {
        ExitCanvas.SetActive(true);
    }
    public void TurnOffNewGameCanvas()
    {
        NewGameCanvas.SetActive(false);
    }
    public void TurnOffContinuesCanvas()
    {
        ContinuesCanvas.SetActive(false);
    }
    public void TurnOffExitCanvas()
    {
        ExitCanvas.SetActive(false);
    }
    public void TurnOnScoreCanvas()
    {
        ScoreCanvas.SetActive(true);
    }
    public void TurnOffScoreCanvas()
    {
        ScoreCanvas.SetActive(false);
    }

}
