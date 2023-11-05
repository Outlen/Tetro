using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterButton : MonoBehaviour
{
    public GameObject player;
    public GameObject elementCanvas;
    public GameObject pathCanvas;

    public void ChangeElementWater()
    {
        player.GetComponent<UnitStats>().element = "water";
        elementCanvas.SetActive(false);
        pathCanvas.SetActive(true);
    }
}
