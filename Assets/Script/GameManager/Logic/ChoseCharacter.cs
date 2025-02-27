// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Cinemachine;
// using TMPro;
// using UnityEngine;

// public class ChoseCharacter : MonoBehaviour
// {
//     public GameObject MainCamera;
//     public GameObject MiddleScreen;
//     public GameObject UI_ChosingCharacterBorder;
//     public GameObject HeathText;
//     public GameObject Speed;
//     public GameObject AtackDmg;
//     public GameObject Skill;
//     public GameObject SkillImg;
//     public GameObject DefaultWeapon;
//     public GameObject DefaultWeaponImg;
//     public GameObject ActorNameText;
//     private GameObject TargetCharacter;



//     void Start()
//     {
//         MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
//         UI_ChosingCharacterBorder.SetActive(false);
//         MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;


//     }
//     void Update()
//     {
//         ZoomToCharacter();

//     }



//     public void ZoomToCharacter()
//     {
//         if (Input.GetMouseButtonDown(0)) // Kiểm tra khi nhấn chuột trái
//         {
//             Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

//             if (hit.collider != null)
//             {
//                 GameObject clickedObject = hit.collider.gameObject;
//                 TargetCharacter = clickedObject;
//                 if (clickedObject.tag == "Character")
//                 {
//                     MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = clickedObject.transform;
//                     MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 5;
//                     UI_ChosingCharacterBorder.SetActive(true);
//                     HeathText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IPlayerStats>().MaxHeath.ToString();
//                     Speed.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IPlayerStats>().MoveSpeed.ToString();
//                     AtackDmg.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IPlayerStats>().AttackDamage.ToString();
//                     DefaultWeapon.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IPlayerStats>().DefaultWeapon.name.ToString();

//                     // rangeAttackText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats >().CharacterRangeAttack.ToString();
//                     // RangeAttackIcon.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<IActorStats >().RangeAttackIcon;

//                     // BasicAttackText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats >().BasicAttackName.ToString();
//                     // BasicAttackIcon.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<IActorStats >().BasicAttackIcon;


//                     // ActorNameText.GetComponent<TextMeshProUGUI>().text = clickedObject.GetComponent<IActorStats >().ActorName.ToString();

//                 }
//             }
//             else
//             {
//             }
//         }
//     }
//     public void ExitChosingCharacter()
//     {
//         UI_ChosingCharacterBorder.SetActive(false);
//         MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = MiddleScreen.transform;
//         MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;

//     }
//     public void ExceptCharacter()
//     {
//         DontDestroyOnLoad(TargetCharacter);
//         TargetCharacter.name = "Player";
//         TargetCharacter.tag = "Player";
//         UI_ChosingCharacterBorder.SetActive(false);
//         MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = TargetCharacter.transform;
//         MainCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 15;
//         TargetCharacter.AddComponent<AllowControllActor>();
//         var _tempObecjt = Instantiate(TargetCharacter.GetComponent<IPlayerStats>().DefaultWeapon);
//         TargetCharacter.GetComponent<ActorWeapon>().ChangeActorWeapon(_tempObecjt);
//         ConfirmPlayer();
//         gameObject.SetActive(false);



//     }



//     public void ConfirmPlayer()
//     {
//         GameManager.Instance.Player = TargetCharacter;


//     }


// }
