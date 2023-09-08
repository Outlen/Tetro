using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TetrisBlock : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public Vector3 rotationPoint;

    private float previousTime;
    public float fallTime = 0.8f;

    public static int height = 20;
    public static int width = 10;

    private float elemModifier;
    private float allignModifier;

    private static Transform[,] grid = new Transform[width, height];

    bool fireBias, waterBias, grassBias;


    // Start is called before the first frame update
    void Start()
    {
        textElement = FindObjectOfType<TextMeshProUGUI>();  
    }

    // Update is called once per frame
    void Update()
    {
        CheckElement();

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotate
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;
                FindObjectOfType<TetrominoSpawner>().NewTetromino();
                
            }
            previousTime = Time.time; 
        }


    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if(grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }
        return true;
    }

    void CheckForLines()
    {
        for (int i = height -1; i >= 0; i--)
        {
            if(HasLines(i))
            {
                //CheckElement();
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLines(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if(grid[j, i] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (waterBias == true)
            {
                elemModifier = 4f;
            }

            else if (fireBias == true)
            {
                elemModifier = 0.25f;
            }
            else elemModifier = 1f;
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        FindObjectOfType<HealthManager>().TakeDamage(10 * elemModifier * allignModifier);
        ResetElement();
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j, y -1] = grid[j,y];
                    grid[j,y] = null;
                    grid[j, y -1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    void CheckElement()
    {
        int waterBlocks = GameObject.FindGameObjectsWithTag("water").Length;
        int fireBlocks = GameObject.FindGameObjectsWithTag ("fire").Length;
        int grassBlocks = GameObject.FindGameObjectsWithTag ("grass").Length;
        int lightBlocks = GameObject.FindGameObjectsWithTag ("light").Length;
        int darkBlocks = GameObject.FindGameObjectsWithTag ("dark").Length;

        if (waterBlocks > fireBlocks && waterBlocks > grassBlocks)
        {
            waterBias = true;
            textElement.text = "Water";
            textElement.color = new Color(0, 116, 255, 255);
        }

        if (fireBlocks > waterBlocks && fireBlocks > grassBlocks)
        {
            fireBias = true;
            textElement.text = "Fire";
            textElement.color = new Color(255, 0, 0, 255);
        }

        if (grassBlocks > waterBlocks && grassBlocks > fireBlocks)
        {
            grassBias = true;
            textElement.text = "Grass";
            textElement.color = new Color(21, 212, 0, 255);
        }
    }

    void ResetElement()
    {
        waterBias = false;
        fireBias = false;
        grassBias = false;
    }
}
   