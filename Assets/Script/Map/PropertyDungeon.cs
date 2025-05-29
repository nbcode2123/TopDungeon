using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyDungeon : MonoBehaviour
{
    public static PropertyDungeon Instance { get; private set; }
    public Camera Camera;
    public GameObject CinemaCamera;
    public GameObject LoadingSceneCanvas;
    void Awake()
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
        GameManager.Instance.CurrentScene = "DungeonScene";
        ObserverManager.AddListener("Map Generator Start", TurnOnLoadingSceneCanvas);
        ObserverManager.AddListener("Map Generator Complete", TurnOffLoadingSceneCanvas);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnOnLoadingSceneCanvas()
    {
        LoadingSceneCanvas.SetActive(true);
    }
    public void TurnOffLoadingSceneCanvas()
    {
        LoadingSceneCanvas.SetActive(false);
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("Map Generator Start", TurnOnLoadingSceneCanvas);
        ObserverManager.RemoveListener("Map Generator Complete", TurnOffLoadingSceneCanvas);
    }
}
