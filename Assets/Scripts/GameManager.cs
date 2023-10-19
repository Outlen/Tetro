using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject BattleUI;
    public GameObject FreeRoamCam;
    public GameObject BattleCam;
    public GameObject BattleManager;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnterBattleScene()
    {
        FreeRoamCam.SetActive(false);
        BattleCam.SetActive(true);
        Spawner.SetActive(true);
        BattleUI.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;

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
