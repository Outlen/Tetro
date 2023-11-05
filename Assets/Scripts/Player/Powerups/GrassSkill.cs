using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/GrassSkill")]
public class GrassSkill : PowerupEffect
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
            target.GetComponent<UnitStats>().currentHealth = 0.1f * target.GetComponent<UnitStats>().maxHealth;
            target.GetComponent<UnitStats>().attack =  1.05f * target.GetComponent<UnitStats>().attack + 0.5f;
        }
    }
}
