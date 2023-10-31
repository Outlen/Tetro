using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Image playerHealthBar;
    public GameObject player;
    private UnitStats playerStats;

    public PowerupEffect powerupDamage, powerupIceStorm, powerupFireStorm, powerupGrassStorm;
    void Start()
    {
        playerStats = player.GetComponent<UnitStats>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = playerStats.currentHealth / playerStats.maxHealth;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            powerupDamage.Apply(player);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch(playerStats.element)
            {
                case "water":
                    powerupIceStorm.Apply(player);
                    break;
            
                case "fire":
                    powerupFireStorm.Apply(player);
                    break;

                case "grass":
                    powerupGrassStorm.Apply(player);
                    break;

                default:
                    break;
            }
        }
    }
    
}
