using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject endScene;
    public UnitStats stats;

    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            StartCoroutine("WaitForSeconds");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
        endScene.SetActive(true);
    }
}
