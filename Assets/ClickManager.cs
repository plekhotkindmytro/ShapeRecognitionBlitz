using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameController gameController;
    public GameObject square;
    public GameObject rombus;
    public GameObject circle;
    public GameObject triangle;
    public GameObject hexagon;

    public TMPro.TMP_Text goalText;
    private GameObject[] shapes;

    private GameObject currentShape;
    private string goal;
    private string[] goals = new string[]
    {
        Constants.Square,
        Constants.Rombus,
        Constants.Circle,
        Constants.Triangle,
        Constants.Hexagon,
    };
    

    void Start()
    {
        shapes = new GameObject[] { square, rombus, circle, triangle, hexagon };
        SpawnNewShape();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.isGameOver)
        {
            return;
        }

      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            Yes();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            No();
        }*/

    }

    public void Yes()
    {
        if (currentShape.name.StartsWith(goal))
        {
            gameController.CorrectScore();
        }
        else
        {
            gameController.WrongScore();
        }
        SpawnNewShape();
    }

    public void No()
    {
        if (!currentShape.name.StartsWith(goal))
        {
            gameController.CorrectScore();
        }
        else
        {
            gameController.WrongScore();
        }
        SpawnNewShape();
    }


    public void SpawnNewShape()
    {
        if (currentShape != null) { Destroy(currentShape); }

        int shapeIndex = Random.Range(0, shapes.Length);
        int goalIndex = Random.Range(0, 2) == 0 ? shapeIndex : Random.Range(0, goals.Length);
        currentShape = Instantiate(shapes[shapeIndex]);
        goal = goals[goalIndex];
        goalText.text = Constants.GOAL_TEXT_PREFIX + goal.ToString() + Constants.GOAL_TEXT_SUFFIX;
    }
}
