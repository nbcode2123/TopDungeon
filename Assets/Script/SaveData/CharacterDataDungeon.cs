using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class CharacterDataDungeon : MonoBehaviour
{
    public string NameCharacter;
    public int CurrentHeath;
    public int CurrentAmmor;
    public int CurrentEnergy;
    public string Weapon1;
    public string Weapon2;
    public int Weapon1Id;
    public int MaxHeath;
    public int MaxAmmor;
    public int MaxEnergy;



    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Save Game", SaveDataPlayer);



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveDataPlayer()
    {
        PlayerStats _player = GameManager.Instance.Player.GetComponent<PlayerStats>();
        CharacterDataDungeon characterDataDungeon = new CharacterDataDungeon
        {
            NameCharacter = _player.NameCharacter,
            CurrentHeath = _player.GetCurrentHeath(),
            CurrentAmmor = _player.GetCurrentAmmor(),
            CurrentEnergy = _player.GetCurrentEnergy(),
            MaxHeath = _player.GetMaxHeath(),
            MaxAmmor = _player.GetMaxAmmor(),
            MaxEnergy = _player.GetMaxEnergy(),
            Weapon1 = WeaponController.Instance.Weapon1.name,
            Weapon1Id = WeaponController.Instance.Weapon1.GetComponent<IWeapon>().Id
        };



        string filePath = Path.Combine(Application.persistentDataPath, "Character.json");
        DataSaver.SaveToJson(characterDataDungeon, filePath);





    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("Save Game", SaveDataPlayer);

    }

}
