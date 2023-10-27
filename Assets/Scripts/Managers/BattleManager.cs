using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Image playerHealthBar;
    public GameObject player;
    private UnitStats playerStats;

    public PowerupEffect PowerupEffect;



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
            PowerupEffect.Apply(player);
        }
    }
}
