using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject BattleUI;
    public GameObject FreeRoamCam;
    public GameObject BattleCam;
    public GameObject BattleManager;
    public GameObject Player;
    public Image EnemyHealthBar;

    public void EnterBattleScene()
    {
        FreeRoamCam.SetActive(false);
        BattleCam.SetActive(true);
        Spawner.SetActive(true);
        BattleUI.SetActive(true);
        BattleManager.SetActive(true);
        EnemyHealthBar.fillAmount = 1;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Spawner.GetComponent<TetrominoSpawner>().NewTetromino();
    }

    public void ExitBattleScene()
    {
        BattleCam.SetActive(false);
        FreeRoamCam.SetActive(true);  
        Spawner.SetActive(false);
        BattleUI.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }

}
