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
    public GameObject HeathText;
    public GameObject StrText;
    public GameObject AgiText;
    public GameObject RangeAttackText;
    public GameObject RangeAttackIcon;
    public GameObject BasicAttackText;
    public GameObject BasicAttackIcon;
    public GameObject ActorNameText;
    public GameObject TargetCharacter;



    void Start()
    {
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
        UI_ChosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        ObserverManager.AddListener("ConfirmPlayer", ConfirmPlayer);


    }
    void Update()
    {
        ZoomToCharacter();

    }

    public void ZoomToCharacter()
    {
        ZoomToCharacter(RangeAttackText);
    }

    public void ZoomToCharacter(GameObject rangeAttackText)
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
                    HeathText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().MaxHeath.ToString();
                    StrText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().DefaultAttackDamage.ToString();
                    AgiText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().MoveSpeed.ToString();
                    HeathText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().MaxHeath.ToString();
                    rangeAttackText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().CharacterRangeAttack.ToString();
                    RangeAttackIcon.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<PlayerStats>().RangeAttackIcon;

                    BasicAttackText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().BasicAttackName.ToString();
                    BasicAttackIcon.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<PlayerStats>().BasicAttackIcon;


                    ActorNameText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<PlayerStats>().ActorName.ToString();

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
        TargetCharacter.name = "Player";
        TargetCharacter.tag = "Player";
        UI_ChosingCharacterBorder.SetActive(false);
        MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = TargetCharacter.transform;
        MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
        TargetCharacter.AddComponent<AllowControllActor>();
        ObserverManager.Notify("ConfirmPlayer");

        gameObject.SetActive(false);



    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("ConfirmPlayer", ConfirmPlayer);


    }


    public void ConfirmPlayer()
    {
        GameManager.Instance.Player = TargetCharacter;


    }


}
