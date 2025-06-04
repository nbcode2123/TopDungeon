using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeneScenen : MonoBehaviour
{
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


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void ExitGame()
    {
        // EditorApplication.isPlaying = false;
        Application.Quit(); // Dành cho bản build
    }

}
