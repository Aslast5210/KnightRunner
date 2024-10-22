using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScCounter : MonoBehaviour
{
    public static ScCounter instance;
    public TMP_Text ScText;
    public int ScNow = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScText.text = "Score : " + ScNow.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        instance = this;
    }

    public void IncreaseSc(int v)
    {
        ScNow += v;
        ScText.text = "Score : " + ScNow.ToString();
    }
}
