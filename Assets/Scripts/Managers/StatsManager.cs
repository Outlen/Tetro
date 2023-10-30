using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public GameObject StatsUI;
    public GameObject Player;
    public TextMeshProUGUI textHealth, textMana, textAttack, textLevel;


    public bool isOpen = false;


    void Update()
    {
        // Open stats screen
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!isOpen)
            {
                OpenStats();
            }

            else
            {
                StatsUI.SetActive(false);
                isOpen = false;
            }
            
        }
    }


    void OpenStats()
    {
        WriteStats();
        StatsUI.SetActive(true);
        isOpen = true;

    }

    void WriteStats()
    {
        textHealth.text = "Health: " + Player.GetComponent<UnitStats>().currentHealth.ToString() + "/" + Player.GetComponent<UnitStats>().maxHealth.ToString();
        textAttack.text = "Attack: " + Player.GetComponent<UnitStats>().attack.ToString();
        textMana.text = "Healing Power: " + Player.GetComponent<UnitStats>().mana.ToString();
        textLevel.text = "Level: " + Player.GetComponent<UnitStats>().level.ToString();
    }
}
