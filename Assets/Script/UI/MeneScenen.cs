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
        EditorApplication.isPlaying = false;
    }
}
