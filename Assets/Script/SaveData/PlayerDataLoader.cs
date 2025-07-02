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
        Player.GetComponent<PlayerStats>().CurrentHeath = _dataCharacter.CurrentHeath;
        chooseCharacter.TargetCharacter = Player;
        chooseCharacter.ExceptCharacter();
        WeaponController.Instance.LoadWeaponData(GameObjectStorage.Instance.WeaponStorage.Find(p => p.Id == _dataCharacter.Weapon1Id).Prefab);
        Player.name = "Player";
        Debug.Log(_dataCharacter.NameCharacter);
        ObserverManager.Notify("Start Dungeon");


    }
    public void OnDisable()
    {
        ObserverManager.RemoveListener("Continues", CreatePlayer);

    }
    public void OnDestroy()
    {
        ObserverManager.RemoveListener("Continues", CreatePlayer);

    }
}
