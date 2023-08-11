using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    private float maxX;
    void Start()
    {
        cam = Camera.main;
       maxX = cam.orthographicSize*cam.aspect + 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
        if(transform.position.x > maxX)
        {
            Destroy(this.gameObject);
        }
    }
}
