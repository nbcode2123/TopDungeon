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
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

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

}
