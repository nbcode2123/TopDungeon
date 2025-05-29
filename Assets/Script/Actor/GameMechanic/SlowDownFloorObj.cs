using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownFloorObj : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        var _moveSpeed = other.gameObject.GetComponent<CharacterStats>();
        if (_moveSpeed != null)
        {
            float _tempMoveSpeed = _moveSpeed.GetMovementSpeed() / 2;
            _moveSpeed.DecreaseMovementSpeed(_tempMoveSpeed);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        var _moveSpeed = other.gameObject.GetComponent<CharacterStats>();
        if (_moveSpeed != null)
        {
            float _tempMoveSpeed = _moveSpeed.GetMovementSpeed() * 2;
            _moveSpeed.IncreaseMovementSpeed(_tempMoveSpeed);
        }
    }
}
