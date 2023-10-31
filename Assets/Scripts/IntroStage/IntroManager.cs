using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (enemy.GetComponent<UnitStats>().currentHealth <= 0)
        {
            Debug.Log("Yay");
            SceneManager.LoadScene("Main");
        }
    }
}
