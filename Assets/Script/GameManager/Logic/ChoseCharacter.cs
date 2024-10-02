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
                Debug.Log("Tên của GameObject được click: " + clickedObject.tag);
                if (clickedObject.tag == "Character")
                {
                    MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = clickedObject.transform;
                    MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 5;
                    UI_ChosingCharacterBorder.SetActive(true);
                    HeathText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().MaxHeath.ToString();
                    StrText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().DefaultAttackDamage.ToString();
                    AgiText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().MoveSpeed.ToString();
                    HeathText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().MaxHeath.ToString();
                    rangeAttackText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().CharacterRangeAttack.ToString();
                    RangeAttackIcon.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<IActorStats>().RangeAttackIcon;

                    BasicAttackText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().BasicAttackName.ToString();
                    BasicAttackIcon.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<IActorStats>().BasicAttackIcon;


                    ActorNameText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats>().ActorName.ToString();

                }
            }
            else
            {
                Debug.Log("Không có đối tượng nào bị click");
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
