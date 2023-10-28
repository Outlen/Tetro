using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerCombatPos;
    
    public GameObject lastEnemy;
    public GameObject Spawner;
    public GameObject BattleUI;
    public GameObject FreeRoamCam;
    public GameObject BattleCam;
    public GameObject BattleManager;
    public GameObject Player;
    public Image EnemyHealthBar;
    private Vector3 pos;

    public static bool inputsEnabled = true;

    public void EnterBattleScene()
    {
        StartCoroutine("Enter");
        Spawner.SetActive(true);
        inputsEnabled = true;
        BattleUI.SetActive(true);
        BattleManager.SetActive(true);
        EnemyHealthBar.fillAmount = 1;
        Spawner.GetComponent<TetrominoSpawner>().NewTetromino();
    }

    public void ExitBattleScene()
    {
        StartCoroutine("Exit");
    }

    public void Dead()
    {
        StartCoroutine("GameOver");
        
    }

    IEnumerator Enter()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        pos = Player.transform.position;
        Player.transform.position = playerCombatPos.transform.position;
        Player.GetComponent<UnitStats>().EnterIdle();
        FreeRoamCam.SetActive(false);
        BattleCam.SetActive(true);
        inputsEnabled = false;
        yield return new WaitForSeconds(1);
    }

    IEnumerator Exit()
    {
        // play enemy dead animation
        lastEnemy = GameObject.FindWithTag("CurrentEnemy");
        lastEnemy.GetComponent<UnitStats>().EnterDead();
        yield return new WaitForSeconds(3);
        Destroy(lastEnemy);

        //Put player back
        pos = pos + new Vector3(-3 , 0, 0);
        Player.transform.position = pos;
        Player.GetComponent<UnitStats>().EnterRoam();

        // Switch camera to Roam
        BattleCam.SetActive(false);
        FreeRoamCam.SetActive(true);  
        Spawner.SetActive(false);
        BattleUI.SetActive(false);
        yield return new WaitForSeconds(1);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

    IEnumerator GameOver()
    {
        // play player dead animation
        Player.GetComponent<UnitStats>().EnterDead();
        yield return new WaitForSeconds(3);

        // put last enemy back
        lastEnemy = GameObject.FindWithTag("CurrentEnemy");
        lastEnemy.gameObject.tag = "enemy";
        lastEnemy.transform.position = pos;
        lastEnemy.GetComponent<UnitStats>().currentHealth = lastEnemy.GetComponent<UnitStats>().maxHealth;

        // put player back
        pos = pos + new Vector3(-3 , 0, 0);
        Player.transform.position = pos;
        Player.GetComponent<UnitStats>().EnterRoam();
        Player.GetComponent<UnitStats>().currentHealth = Player.GetComponent<UnitStats>().maxHealth * 0.2f;


        // Switch camera to Roam
        BattleCam.SetActive(false);
        FreeRoamCam.SetActive(true);  
        Spawner.SetActive(false);
        BattleUI.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

}
