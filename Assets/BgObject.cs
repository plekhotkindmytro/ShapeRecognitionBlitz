using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class BgObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private Vector3 moveDirection;

    private Camera cam;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Rotate(Vector3.forward, 360 * rotationSpeed *Time.deltaTime);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    
}
