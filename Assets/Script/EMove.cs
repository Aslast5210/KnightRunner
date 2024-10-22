using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class EMove : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator Anmt;
    private Transform curPoint;
    public float speede;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anmt = GetComponent<Animator>();
        curPoint = pointB.transform;
        Anmt.SetBool("EEgleFlight", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = curPoint.position - transform.position;
        if(curPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speede, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speede, 0);
        }

        if(Vector2.Distance(transform.position, curPoint.position) < 0.5f && curPoint == pointB.transform)
        {
            flipper();
            curPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, curPoint.position) < 0.5f && curPoint == pointA.transform)
        {
            flipper();
            curPoint = pointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
    private void flipper()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
