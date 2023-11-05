using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireButton : MonoBehaviour
{
    public GameObject player;
    public GameObject elementCanvas;
    public GameObject pathCanvas;

    public void ChangeElementFire()
    {
        player.GetComponent<UnitStats>().element = "fire";
        elementCanvas.SetActive(false);
        pathCanvas.SetActive(true);
    }
}
