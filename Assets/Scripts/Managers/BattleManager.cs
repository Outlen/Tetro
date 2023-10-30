using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Image playerHealthBar;
    public GameObject player;
    private UnitStats playerStats;

    public PowerupEffect powerupDamage, powerupIceStorm;



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

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            powerupIceStorm.Apply(player);
        }
    }
}
