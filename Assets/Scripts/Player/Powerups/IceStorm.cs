using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/IceStorm")]
public class IceStorm : PowerupEffect
{
    public Sprite waterSprite;
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
            GameObject[] fireCubes = GameObject.FindGameObjectsWithTag("fire");
            GameObject[] grassCubes = GameObject.FindGameObjectsWithTag("grass");

            // change them all to water
            foreach (GameObject cube in fireCubes)
            {
                cube.tag = "water";
                cube.GetComponent<SpriteRenderer>().sprite = waterSprite;
            }
            foreach (GameObject cube in grassCubes)
            {
                cube.tag = "water";
                cube.GetComponent<SpriteRenderer>().sprite = waterSprite;
            }
        }
        
    }
}
