using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,  speed * Time.deltaTime);
    }
}
