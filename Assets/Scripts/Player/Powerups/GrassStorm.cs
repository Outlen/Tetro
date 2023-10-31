using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/GrassStorm")]
public class GrassStorm : PowerupEffect
{
    public Sprite grassSprite;
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
            GameObject[] fireCubes = GameObject.FindGameObjectsWithTag("fire");

            // change them all to grass 
            foreach (GameObject cube in waterCubes)
            {
                cube.tag = "grass";
                cube.GetComponent<SpriteRenderer>().sprite = grassSprite;
            }
            foreach (GameObject cube in fireCubes)
            {
                cube.tag = "grass";
                cube.GetComponent<SpriteRenderer>().sprite = grassSprite;
            }
        }   
    }
}
