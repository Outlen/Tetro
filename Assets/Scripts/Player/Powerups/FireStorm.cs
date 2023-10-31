using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/FireStorm")]
public class FireStorm : PowerupEffect
{
    public Sprite fireSprite;
    public float amountHealthLoss;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<UnitStats>().currentHealth - amountHealthLoss <= 0)
        {
            Debug.Log("Not enough health!");
        }
        else
        {
            target.GetComponent<UnitStats>().currentHealth -= amountHealthLoss;
            // get all of the other element cubes
            GameObject[] waterCubes = GameObject.FindGameObjectsWithTag("water");
            GameObject[] grassCubes = GameObject.FindGameObjectsWithTag("grass");

            // change them all to fire 
            foreach (GameObject cube in waterCubes)
            {
                cube.tag = "fire";
                cube.GetComponent<SpriteRenderer>().sprite = fireSprite;
            }
            foreach (GameObject cube in grassCubes)
            {
                cube.tag = "fire";
                cube.GetComponent<SpriteRenderer>().sprite = fireSprite;
            }
        }   
    }
}
