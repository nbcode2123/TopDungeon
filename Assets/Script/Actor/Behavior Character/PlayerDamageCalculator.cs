using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCalculator : DamageCalculator
{

    public override void TakeDamage(int damage)
    {
        var _characterStats = gameObject.GetComponent<PlayerStats>();

        if (_characterStats.GetCurrentAmmor() != 0)
        {
            _characterStats.DecreaseCurrentAmmor(damage);
            // if (_characterStats.GetCurrentAmmor() < 0)
            // {
            //     _characterStats.DecreaseCurrentAmmor(damage);
            //     UIManager.Instance.PlayerStatsAmmorUpdate(_characterStats.CurrentAmmor);

            // }
            UIManager.Instance.PlayerStatsAmmorUpdate(_characterStats.GetCurrentAmmor());
        }

        else if (_characterStats.GetCurrentAmmor() == 0)
        {
            _characterStats.DecreaseCurrentHeath(damage);
            if (_characterStats.GetCurrentHeath() > 0)
            {
                UIManager.Instance.PlayerStatsHeathUpdate(_characterStats.GetCurrentHeath());

            }
            else if (_characterStats.GetCurrentHeath() <= 0)
            {
                _characterStats.DecreaseCurrentHeath(damage);
                UIManager.Instance.PlayerStatsHeathUpdate(_characterStats.GetCurrentHeath());
                InvokeOnDeath();
                Debug.Log("Player death");
                ObserverManager.Notify("Game Complete");
            }

        }


    }
}
