using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // public GameObject ChoosingWeaponAlert;
    // public GameObject ChoosingWeaponName;
    public GameObject ScenePlayerCanvas;
    public GameObject BackToMenuBtn;
    public GameObject PauseBtn;
    public GameObject PauseCanvas;
    public GameObject PauseCanvasUI;
    public GameObject TurnOffChoosingCharacterBtn;
    public GameObject ChoosingCharacterCanvas;
    public GameObject PlayerStatsCanvas;
    public GameObject PlayerStatsHeath;
    public GameObject PlayerStatsAmmor;
    public GameObject PlayerStatsEnergy;
    public GameObject SaveBtn;




    public static UIManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
            // DontDestroyOnLoad(ScenePlayerCanvas);
            // // DontDestroyOnLoad(ChoosingWeaponName);
            // // DontDestroyOnLoad(ChoosingWeaponAlert);
            // DontDestroyOnLoad(BackToMenuBtn);
            // DontDestroyOnLoad(PauseBtn);
            // DontDestroyOnLoad(PauseCanvas);
            // DontDestroyOnLoad(PlayerStatsCanvas);
            // DontDestroyOnLoad(PauseCanvasUI);

        }

    }
    public void BackToMenu()
    {
        Destroy(gameObject);
        Destroy(ScenePlayerCanvas);
        // DontDestroyOnLoad(ChoosingWeaponName);
        // DontDestroyOnLoad(ChoosingWeaponAlert);
        // Destroy(BackToMenuBtn);
        Destroy(PauseBtn);
        Destroy(PauseCanvas);
        Destroy(PlayerStatsCanvas);
        Destroy(PauseCanvasUI);
    }
    private void Start()
    {

        // BackToMenuBtn.SetActive(true);
        PauseBtn.SetActive(false);
        PauseCanvas.SetActive(false);
        PlayerStatsCanvas.SetActive(false);
        SaveBtn.SetActive(false);

        // ObserverManager.AddListener("Select Player Complete", TurnOffBackToLobbyBtn);

        ObserverManager.AddListener("LobbyScene", BackToLobbyTrigger);
        ObserverManager.AddListener("Select Player Complete", TurnOnPauseBtn);
        ObserverManager.AddListener("Select Player Complete", TurnOnPlayerStatsUI);
        ObserverManager.AddListener("Map Generator Start", TurnOffAll);
        ObserverManager.AddListener("Map Generator Complete", TurnOnPlayerStatsUI);
        ObserverManager.AddListener("Map Generator Complete", TurnOnPauseBtn);
        ObserverManager.AddListener("Map Generator Complete", TurnOnSaveBtn);








    }
    public void PlayUISFX()
    {
        ObserverManager.Notify("Audio", "UIClick");
    }
    public void BackToLobbyTrigger()
    {
        ObserverManager.AddListener("Select Player Complete", TurnOnPauseBtn);
        ObserverManager.AddListener("Select Player Complete", TurnOnPlayerStatsUI);
    }
    void OnDestroy()
    {
        // ObserverManager.RemoveListener("Select Player Complete", TurnOffBackToLobbyBtn);
        // ObserverManager.RemoveListener("MenuScene", TurnOffBackToLobbyBtn);
        ObserverManager.RemoveListener("LobbyScene", BackToLobbyTrigger);
        ObserverManager.RemoveListener("Select Player Complete", TurnOnPauseBtn);
        ObserverManager.RemoveListener("Select Player Complete", TurnOnPlayerStatsUI);
        ObserverManager.RemoveListener("Map Generator Start", TurnOffAll);
        ObserverManager.RemoveListener("Map Generator Complete", TurnOnPlayerStatsUI);
        ObserverManager.RemoveListener("Map Generator Complete", TurnOnPauseBtn);



    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("LobbyScene", BackToLobbyTrigger);
        ObserverManager.RemoveListener("Select Player Complete", TurnOnPauseBtn);
        ObserverManager.RemoveListener("Select Player Complete", TurnOnPlayerStatsUI);
        ObserverManager.RemoveListener("Map Generator Start", TurnOffAll);
        ObserverManager.RemoveListener("Map Generator Complete", TurnOnPlayerStatsUI);
        ObserverManager.RemoveListener("Map Generator Complete", TurnOnPauseBtn);
        // ObserverManager.RemoveListener("Select Player Complete", TurnOffBackToLobbyBtn);
        // ObserverManager.RemoveListener("MenuScene", TurnOffBackToLobbyBtn);


    }
    public void TurnOnSaveBtn()
    {
        SaveBtn.SetActive(true);
    }
    public void TurnOnBackToMeneBtn()
    {
        // BackToMenuBtn.SetActive(true);



    }
    public void TurnOffAll()
    {
        // ChoosingWeaponAlert.SetActive(false);
        // ChoosingWeaponName.SetActive(false);
        ScenePlayerCanvas.SetActive(false);
        // BackToMenuBtn.SetActive(false);
        PauseBtn.SetActive(false);
        PauseCanvas.SetActive(false);
        PlayerStatsCanvas.SetActive(false);

    }



    public void TurnOnPauseCanvas()
    {
        PauseCanvas.SetActive(true);
        PlayUISFX();
        Time.timeScale = 0f;
    }

    public void TurnOffPauseCanvas()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        PlayUISFX();


    }
    public void TurnOnPauseBtn()
    {
        PauseBtn.SetActive(true);
        PlayUISFX();

    }






    public void TurnOffBackToLobbyBtn()
    {
        // BackToMenuBtn.SetActive(false);
        PlayUISFX();


    }
    public void TurnOffChoosingCharacterCanvas()
    {
        ChoosingCharacterCanvas.SetActive(false);
        gameObject.GetComponent<ChooseCharacter>().ExitChoosingCharacter();
        PlayUISFX();

    }
    public void TurnOnPlayerStatsUI()
    {
        PlayerStatsCanvas.SetActive(true);
        PlayerStatsHeath.GetComponent<Slider>().maxValue = GameManager.Instance.Player.GetComponent<PlayerStats>().GetMaxHeath();
        PlayerStatsAmmor.GetComponent<Slider>().maxValue = GameManager.Instance.Player.GetComponent<PlayerStats>().MaxAmmor;
        PlayerStatsEnergy.GetComponent<Slider>().maxValue = GameManager.Instance.Player.GetComponent<PlayerStats>().MaxEnergy;
        PlayerStatsHeath.GetComponent<Slider>().value = GameManager.Instance.Player.GetComponent<PlayerStats>().GetMaxHeath();
        PlayerStatsAmmor.GetComponent<Slider>().value = GameManager.Instance.Player.GetComponent<PlayerStats>().MaxAmmor;
        PlayerStatsEnergy.GetComponent<Slider>().value = GameManager.Instance.Player.GetComponent<PlayerStats>().MaxEnergy;
    }
    public void PlayerStatsHeathUpdate(int value)
    {
        PlayerStatsHeath.GetComponent<Slider>().value = value;
    }
    public void PlayerStatsAmmorUpdate(int value)
    {
        PlayerStatsAmmor.GetComponent<Slider>().value = value;

    }
    public void PlayerStatsEnergyUpdate(int value)
    {
        PlayerStatsEnergy.GetComponent<Slider>().value = value;
    }
    public void SaveGame()
    {
        ObserverManager.Notify("Save Game");
    }


}
