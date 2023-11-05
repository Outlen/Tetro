using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkills : MonoBehaviour
{
    public GameObject GameManager;
    public UnitStats stats;

    void Update()
    {
        if (stats.currentHealth <= 0.5f * stats.maxHealth)
        {
            Time.timeScale = 2;
        }
    }

}

   
