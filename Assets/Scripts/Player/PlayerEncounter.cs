using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEncounter : MonoBehaviour
{
    public GameManager GameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.tag = "CurrentEnemy";
            GameManager.EnterBattleScene();
        }
    }
}
