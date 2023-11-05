using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/IceSkill")]
public class IceSkill : PowerupEffect
{

    public float amountHealthLoss;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<UnitStats>().currentHealth - amountHealthLoss <= 0)
        {
            Debug.Log("Not enough health!");
        }
        
        else
        {
            target.GetComponent<UnitStats>().currentHealth = target.GetComponent<UnitStats>().currentHealth - amountHealthLoss;
            Time.timeScale -= 0.5f;
        }
    }
}
