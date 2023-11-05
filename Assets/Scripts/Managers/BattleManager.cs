using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    private bool isIceActive = false;
    private bool isBuffActive = false;
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
            if (!isBuffActive)
            {
                StartCoroutine("DamageBuff");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch(playerStats.element)
            {
                case "water":
                    if (!isIceActive)
                    {
                        StartCoroutine("IceSkill");
                    }
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

    IEnumerator IceSkill()
    {
        isIceActive = true;
        powerupIceStorm.Apply(player);
        yield return new WaitForSeconds(10);
        Time.timeScale += 0.5f;
        isIceActive = false;
    }    

    IEnumerator DamageBuff()
    {
        isBuffActive = true;
        powerupDamage.Apply(player);
        yield return new WaitForSeconds(10);
        isBuffActive = false;
        playerStats.attack -= 2;
    }    
}
