using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameCamehah : MonoBehaviour
{
    private GameObject Runner;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Runner = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Runner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Runner.transform.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
