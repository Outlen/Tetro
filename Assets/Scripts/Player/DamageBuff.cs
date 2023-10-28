using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups")]
public class DamageBuff : PowerupEffect
{
    public float amountDamage;
    public float amountHealthLoss;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<UnitStats>().currentHealth - amountHealthLoss <= 0)
        {
            Debug.Log("Not enough health!");
        }
        else
        {
            target.GetComponent<UnitStats>().attack += amountDamage;
            target.GetComponent<UnitStats>().currentHealth -= amountHealthLoss;
        }
        
    }
}
