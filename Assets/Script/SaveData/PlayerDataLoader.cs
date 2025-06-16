using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLoader : MonoBehaviour
{
    public ChooseCharacter chooseCharacter;
    private void Start()
    {
        ObserverManager.AddListener("Continues", CreatePlayer);
    }
    public void CreatePlayer()
    {
        var _dataCharacter = DataLoader.DataCharacter();
        GameObject Player = Instantiate(GameObjectStorage.Instance.CharacterStorage.Find(p => p.Name == _dataCharacter.NameCharacter).Prefab);
        chooseCharacter.TargetCharacter = Player;
        chooseCharacter.ExceptCharacter();
        WeaponController.Instance.LoadWeaponData(GameObjectStorage.Instance.WeaponStorage.Find(p => p.Id == _dataCharacter.Weapon1Id).Prefab, GameObjectStorage.Instance.WeaponStorage.Find(p => p.Id == _dataCharacter.Weapon2Id).Prefab);
        Player.name = "Player";
        Debug.Log(_dataCharacter.NameCharacter);
        ObserverManager.Notify("Start Dungeon");


    }
}
