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
        target.GetComponent<UnitStats>().attack += amountDamage;
        target.GetComponent<UnitStats>().currentHealth -= amountHealthLoss;
    }
}
