using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitStats : MonoBehaviour 
{
    public GameManager GameManager;
    
    public float health;
    public float mana;
    public float attack;
    public float defense;
    public float speed;
    public string element;

    private bool dead = false;


    public bool isDead()
    {
        return this.dead;
    }

    public void TakeDamage (float damage) 
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            this.dead = true;
            GameManager.ExitBattleScene();
            //Destroy(this.gameObject);
        }
    }
}
