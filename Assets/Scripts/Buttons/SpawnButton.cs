using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject player;
    public GameObject pos;
    public GameObject chooseScreen;
    public GameObject WallsTrue;


    public void Spawn()
    {
        player.transform.position = pos.transform.position;
        chooseScreen.SetActive(false);
        WallsTrue.SetActive(true);
    }
}
