using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MiddleScreen;
    public GameObject UI_ChoosingCharacterBorder;

    private GameObject TargetCharacter;
    public GameObject ExceptBtn;
    public GameObject TurnOffBorderBtn;




    void Start()
    {
        UI_ChoosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        MainCamera = PropertyLobby.Instance.CinemachineCamera;
        MiddleScreen = PropertyLobby.Instance.MiddleScreen;
        UI_ChoosingCharacterBorder = PropertyLobby.Instance.ChoosingBorder;//! về sau đưa về cho GameManager 



    }
    void Update()
    {
        ZoomToCharacter();

    }



    public void ZoomToCharacter()
    {

        if (Input.GetMouseButtonDown(0)) // Kiểm tra khi nhấn chuột trái
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                TargetCharacter = clickedObject;
                if (clickedObject.tag == "Character")
                {
                    MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = clickedObject.transform;
                    MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 5;
                    UI_ChoosingCharacterBorder.SetActive(true);
                }
            }

        }
    }
    public void ExitChoosingCharacter()
    {
        UI_ChoosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        PlayUISFX();

    }
    public void PlayUISFX()
    {
        ObserverManager.Notify("Audio", "UIClick");
    }
    public void ExceptCharacter()
    {
        PlayUISFX();
        DontDestroyOnLoad(TargetCharacter);
        GameManager.Instance.Player = TargetCharacter;
        TargetCharacter.name = "Player";
        TargetCharacter.tag = "Player";
        UI_ChoosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = TargetCharacter.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        TargetCharacter.AddComponent<MovePlayer>();
        TargetCharacter.AddComponent<WeaponController>();
        TargetCharacter.AddComponent<PlayerStateController>();
        ObserverManager.Notify("Select Player Complete");

        // TargetCharacter.GetComponent<PlayerStats>().ChangeActorWeapon(_tempObecjt);
        ConfirmPlayer();
        // gameObject.SetActive(false);

    }
    public void ConfirmPlayer()
    {
        GameManager.Instance.Player = TargetCharacter;
    }
}
