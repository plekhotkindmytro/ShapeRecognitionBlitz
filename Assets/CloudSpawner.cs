using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    private float x;
    private Camera cam;
    public float spawnTime = 3f;
    private float timeElapsed = 0;
    void Start()
    {
        cam = Camera.main;
        x = - cam.orthographicSize * cam.aspect - 2;

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTime)
        {
            GameObject cloud = Instantiate(cloudPrefab);
            cloud.transform.position = new Vector2(x, Random.Range(1, cam.orthographicSize - 1));
            timeElapsed = 0;
        }


    }
}
