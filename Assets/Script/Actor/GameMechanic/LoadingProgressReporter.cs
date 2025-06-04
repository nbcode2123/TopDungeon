using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LoadingProgressReporter : MonoBehaviour
{
    public static LoadingProgressReporter Instance { private set; get; }
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    public static float CurrentProgress { get; private set; } = 0;
    public static bool IsDone { get; private set; } = false;
    // public GameObject WaitScene;
    public GameObject Slider;

    IEnumerator Start()
    {
        // WaitScene.SetActive(true);
        // Step 1: Setup camera, player...
        PropertyDungeon.Instance.LoadingSceneCanvas.SetActive(true);
        UIManager.Instance.PlayerStatsCanvas.SetActive(false);
        GameManager.Instance.Player = GameObject.Find("Player");
        Debug.Log("Xác định Player");

        GameManager.Instance.Player.transform.position = Vector3.zero;
        GameManager.Instance.Camera = PropertyDungeon.Instance.Camera;
        Debug.Log("Lấy Camera mới");
        GameManager.Instance.CinemaCamera = PropertyDungeon.Instance.CinemaCamera;
        Debug.Log("Lấy CineCamera mới");

        GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().Follow = GameManager.Instance.Player.transform;
        GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        CurrentProgress = 0.2f;
        Debug.Log("Hoan thanh camera setup");

        yield return new WaitForSeconds(2f);
        DungeonController.Instance.InitializeDungeonValue();
        CurrentProgress = 0.4f;
        Debug.Log("Hoan thanh khoi tao ");

        yield return new WaitForSeconds(2f);

        // Step 3: Tạo map từng bước một
        // yield return GenerateMapStepByStep();
        MapProcessor.Instance.MapGenerator();
        Debug.Log("Hoan thanh tao map");
        // Step 2: Init Value
        // WaitScene.SetActive(false);
        CurrentProgress = 1f;
        IsDone = true;
    }

    // IEnumerator GenerateMapStepByStep()
    // {
    //     MapProcessor.Instance.InitializeGeneration(); yield return null; CurrentProgress = 0.5f;
    //     MapProcessor.Instance.DecideConcept(); yield return null; CurrentProgress = 0.6f;
    //     MapProcessor.Instance.CreateRoomObjectPooling(); yield return null; CurrentProgress = 0.7f;
    //     MapProcessor.Instance.CreateRoomAndCollider(); yield return null; CurrentProgress = 0.8f;
    //     MapProcessor.Instance.AddEnvironmentToRoom(); yield return null; CurrentProgress = 0.9f;
    //     MapProcessor.Instance.PaintTileMap(MapProcessor.Instance.FloorPosition);
    //     ObserverManager.Notify("DungeonStart");
    //     yield return null;

    //     ObserverManager.Notify("Map Generator Complete");
    // }
    public IEnumerator ProcessCreateMap()

    {
        // WaitScene.SetActive(true);
        // Step 1: Setup camera, player...

        DungeonController.Instance.InitializeDungeonValue();
        CurrentProgress = 0.4f;
        Debug.Log("Hoan thanh khoi tao ");

        yield return new WaitForSeconds(2f);
        Debug.Log("Buoc vao  tao map");


        // Step 3: Tạo map từng bước một
        // yield return GenerateMapStepByStep();
        // yield return StartCoroutine(MapProcessor.Instance.MapGenerator());
        Debug.Log("Hoan thanh tao map");
        // Step 2: Init Value

        // WaitScene.SetActive(false);
        CurrentProgress = 1f;
        IsDone = true;

    }
    public IEnumerator Test1()
    {

        // WaitScene.SetActive(true);
        // Step 1: Setup camera, player...
        GameManager.Instance.Player = GameObject.Find("Player");
        Debug.Log(1);
        GameManager.Instance.Camera = PropertyDungeon.Instance.Camera;
        Debug.Log(2);
        GameManager.Instance.CinemaCamera = PropertyDungeon.Instance.CinemaCamera;
        Debug.Log(3);

        GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().Follow = GameManager.Instance.Player.transform;
        GameManager.Instance.CinemaCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        CurrentProgress = 0.2f;
        Debug.Log("Hoan thanh camera setup");

        yield return new WaitForSeconds(2f);
        DungeonController.Instance.InitializeDungeonValue();
        CurrentProgress = 0.4f;
        Debug.Log("Hoan thanh khoi tao ");

        yield return new WaitForSeconds(2f);

        // Step 3: Tạo map từng bước một
        // yield return GenerateMapStepByStep();
        // yield return StartCoroutine(MapProcessor.Instance.MapGenerator());
        Debug.Log("Hoan thanh tao map");
        // Step 2: Init Value
        // WaitScene.SetActive(false);
        CurrentProgress = 1f;
        IsDone = true;
    }

}
