using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneLocker : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Start Dungeon", StartCoroutine);
        ObserverManager.AddListener("DungeonStart", UnLockPlayer);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartCoroutine()
    {
        StartCoroutine(LockPlayer());

    }
    public IEnumerator LockPlayer()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.Player.GetComponent<MovePlayer>().enabled = false;
        WeaponController.Instance.TurnOffWeaponWhenLoading();

    }
    public void UnLockPlayer()
    {
        GameManager.Instance.Player.GetComponent<MovePlayer>().enabled = true;
        WeaponController.Instance.TurnOnWeaponWhenLoading();
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("Start Dungeon", StartCoroutine);
        ObserverManager.RemoveListener("DungeonStart", UnLockPlayer);


    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("Start Dungeon", StartCoroutine);
        ObserverManager.RemoveListener("DungeonStart", UnLockPlayer);


    }
}
