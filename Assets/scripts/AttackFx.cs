using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFx : MonoBehaviour
{
    public float PtclWidth;
    public float Opacity;
    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        PtclWidth = transform.localScale.y;
        Opacity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PtclWidth -= Time.deltaTime * 0.2f;
        Opacity = Mathf.Clamp(Opacity - Time.deltaTime * 2, 0f, 1f);

        //transform.position += transform.right * 0.02f; 

        transform.localScale = new Vector3( transform.localScale.x, PtclWidth, transform.localScale.z);

        sp.color = new Color(1f, 1f, 1f, Opacity);

        if (Opacity == 0f)
        {
            Destroy(gameObject);
        }
    }
}
