using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;

public class ClickManager : MonoBehaviour
{
    public GameController gameController;
    public GameObject square;
    public GameObject rombus;
    public GameObject circle;
    public GameObject triangle;
    public GameObject hexagon;
    public GameObject decalPrefab;

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

    private Camera cameraMain;

    void Start()
    {
        cameraMain = Camera.main;
        shapes = new GameObject[] { square, rombus, circle, triangle, hexagon };
        SpawnNewShape();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isGameOver)
        {
            return;
        }


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                ProcessTouch(touch.position);
            }
        }


    }

    private void ProcessTouch(Vector2 position)
    {
        Vector2 worldPosition = cameraMain.ScreenToWorldPoint(position);

        GameObject decal = Instantiate(decalPrefab);

        // decal.GetComponent<SpriteRenderer>().sprite = decals[Random.Range(0, decals.Length)];
        decal.transform.position = worldPosition;
        // PlayRandomizedSound(stepSound);

        // SpawnPopParticles(worldPosition);
        //  prevTapPos = worldPosition;

    }

    private void PaintDecal(Vector2 position)
    {

    }

    public void Yes()
    {
        if (currentShape == null)
        {
            return;
        }

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
        if (currentShape == null)
        {
            return;
        }

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
