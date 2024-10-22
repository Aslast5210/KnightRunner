using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGrepete : MonoBehaviour
{
    public GameObject camecame;
    public float parallax;
    private float width, positionX;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        positionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallaxDistance = camecame.transform.position.x * parallax;
        float remainDistance = camecame.transform.position.x * (1 - parallax);
        transform.position = new Vector3(positionX + parallaxDistance, transform.position.y, transform.position.z);

        if (remainDistance > positionX + width) 
        {
            positionX += width;
        }
    }
}
