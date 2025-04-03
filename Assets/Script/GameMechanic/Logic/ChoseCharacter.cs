using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class ChoseCharacter : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MiddleScreen;
    public GameObject UI_ChosingCharacterBorder;

    private GameObject TargetCharacter;




    void Start()
    {
        UI_ChosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;



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
                    UI_ChosingCharacterBorder.SetActive(true);
                }
            }
            else
            {
            }
        }
    }
    public void ExitChosingCharacter()
    {
        UI_ChosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
    }
    public void ExceptCharacter()
    {
        DontDestroyOnLoad(TargetCharacter);
        GameManager.Instance.Player = TargetCharacter;
        TargetCharacter.name = "Player";
        TargetCharacter.tag = "Player";
        UI_ChosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = TargetCharacter.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        TargetCharacter.AddComponent<MovePlayer>();
        TargetCharacter.AddComponent<WeaponController>();
        TargetCharacter.AddComponent<PlayerStateController>();

        // TargetCharacter.GetComponent<PlayerStats>().ChangeActorWeapon(_tempObecjt);
        ConfirmPlayer();
        gameObject.SetActive(false);
    }
    public void ConfirmPlayer()
    {
        GameManager.Instance.Player = TargetCharacter;
    }
}
