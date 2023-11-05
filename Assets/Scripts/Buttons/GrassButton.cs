using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrassButton : MonoBehaviour
{
    public GameObject player;
    public GameObject elementCanvas;
    public GameObject pathCanvas;

    public void ChangeElementGrass()
    {
        player.GetComponent<UnitStats>().element = "grass";
        elementCanvas.SetActive(false);
        pathCanvas.SetActive(true);
    }
}
