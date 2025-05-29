using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeepUpFloorObj : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        var _moveSpeed = other.gameObject.GetComponent<CharacterStats>();
        if (_moveSpeed != null)
        {
            float _tempMoveSpeed = _moveSpeed.GetMovementSpeed() / 2;
            _moveSpeed.DecreaseMovementSpeed(_tempMoveSpeed);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var _moveSpeed = other.gameObject.GetComponent<CharacterStats>();
        if (_moveSpeed != null)
        {
            float _tempMoveSpeed = _moveSpeed.GetMovementSpeed() * 2;
            _moveSpeed.DecreaseMovementSpeed(_tempMoveSpeed);
        }
    }

}
