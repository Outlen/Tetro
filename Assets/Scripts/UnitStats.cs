using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UnitStats : MonoBehaviour 
{
    public Animator animator;

    public Image HealthBar;

    public bool isEnemy;
    public bool isFighting;
    
    public float currentHealth;
    public float maxHealth;
    public float mana;
    public float attack;
    public float speed;
    public string element;
    public int expAmount;
    public int level;



    public GameObject lootPrefab;

    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    void Update()
    {
        if (this.currentHealth > this.maxHealth)
        {
            this.currentHealth = this.maxHealth;
        }

        if (this.attack < 0)
        {
            this.attack = 2f;
        }


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
        level++;
        maxHealth = maxHealth * 1.2f;
        attack = attack * 1.5f;
        mana = mana * 1.2f;
    }

    public void EnterIdle()
    {
        animator.SetTrigger("Idle");
    }

    public void EnterAttack()
    {
        if (isFighting)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void EnterRoam()
    {
        animator.SetTrigger("RoamIdle");
    }

    public void EnterDead()
    {
        animator.SetTrigger("Dead");
    }

    public void RoamUp()
    {
        animator.SetTrigger("RoamUp");
    }

    public void RoamDown()
    {
        animator.SetTrigger("RoamDown");
    }

}
