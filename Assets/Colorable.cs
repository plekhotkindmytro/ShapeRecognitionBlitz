
using UnityEngine;

public class Colorable : MonoBehaviour
{
    [SerializeField]Color[] colors;
    private SpriteRenderer baseRenderer;
    void Start()
    {
        baseRenderer = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        baseRenderer.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
