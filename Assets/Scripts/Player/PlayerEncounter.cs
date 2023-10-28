using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEncounter : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject enemyCombatPos;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.transform.position = enemyCombatPos.transform.position;
            collision.gameObject.GetComponent<UnitStats>().EnterIdle();
            collision.gameObject.tag = "CurrentEnemy";
            GameManager.EnterBattleScene();
        }
    }
}
