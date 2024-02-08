using UnityEngine;
using DG.Tweening;
public class Decal : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.DOFade(0, 3f).OnComplete(() =>
        {
            Destroy(gameObject, 1f);
        });
    }

   

}
