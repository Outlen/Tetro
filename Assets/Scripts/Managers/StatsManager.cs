using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public GameObject StatsUI;
    public GameObject Player;
    public TextMeshProUGUI textHealth, textMana, textAttack, textLevel, textElement, textSkill1, textSkill2;


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
        textAttack.text = "Attack: " + Player.GetComponent<UnitStats>().attack.ToString("#.0");
        textMana.text = "Healing Power: " + Player.GetComponent<UnitStats>().mana.ToString();
        textLevel.text = "Level: " + Player.GetComponent<UnitStats>().level.ToString();
        textElement.text = "Element specialty: " + Player.GetComponent<UnitStats>().element.ToString();
        textSkill1.text = "Skill 1 (Left Shift key): Damage buff\n+2 Damage for 10 seconds, -40 Health";
        

        switch (Player.GetComponent<UnitStats>().element)
        {
            case ("fire"):
            {
                textSkill2.text = "Skill 2 (Q key): Firestorm\nTurns all blocks onscreen to fire";
                break;
            }

            case ("water"):
            {
                textSkill2.text = "Skill 2 (Q key): Frostbites\nSlows all blocks for 10 seconds";
                break;
            }

            case ("grass"):
            {
                textSkill2.text = "Skill 2 (Q key): Breath of the Forest\nInstant heal and small permanent damage increase";
                break;
            }

            default:
                break;
        }
    }
}
