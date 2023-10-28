using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UnitStats : MonoBehaviour 
{
    public Animator animator;

    public Image HealthBar;

    public bool isEnemy;
    public float currentHealth;
    public float maxHealth;
    public float mana;
    public float attack;
    public float defense;
    public float speed;
    public string element;
    public int expAmount;


    public GameObject lootPrefab;

    void Start()
    {
        this.currentHealth = this.maxHealth;
    }


    public void TakeDamage (float damage) 
    {
        animator.SetTrigger("Damaged");
        this.currentHealth -= damage;
        HealthBar.fillAmount = this.currentHealth / this.maxHealth;
        if(this.currentHealth <= 0 && isEnemy)
        {
            ExperienceManager.Instance.AddExperience(expAmount);
            Instantiate(lootPrefab, transform.localPosition, Quaternion.identity);
        }
    }

    public void Heal (float amount)
    {
        this.currentHealth += amount;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void LevelUp()
    {
        maxHealth = maxHealth * 1.2f;
        attack = attack * 1.2f;
    }

    public void EnterIdle()
    {
        animator.SetTrigger("Idle");
    }

    public void EnterAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void EnterRoam()
    {
        animator.SetTrigger("RoamIdle");
    }

    public void EnterDead()
    {
        animator.SetTrigger("Dead");
    }

}
