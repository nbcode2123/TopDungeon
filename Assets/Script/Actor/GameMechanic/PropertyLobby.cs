using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PropertyLobby : MonoBehaviour
{
    public static PropertyLobby Instance { get; private set; }
    public Camera Camera;
    public GameObject CameraObj;
    public GameObject CinemachineCamera;
    public GameObject MiddleScreen;
    public GameObject ChoosingBorder;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Camera = Camera;
        GameManager.Instance.CinemaCamera = CinemachineCamera;
        GameObject gameManagerObj = GameManager.Instance.gameObject;

        // gameManagerObj.GetComponent<ChooseCharacter>().TurnOffBorderBtn.GetComponent<Button>().onClick += 



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoToDungeonScene()
    {
        SceneManager.LoadScene("DungeonScene");
    }
}
