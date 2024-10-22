using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runnering : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float Speedz;
    private int jumpCount = 0;
    private bool canJump = true;
    Animator amnt;
    private float timeSinceLastIncrease = 0f;
    private bool isSliding = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        amnt = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.right * Speedz * Time.deltaTime + transform.position;

        if (jumpCount == 2)
        {
            canJump = false;
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            rb2d.velocity = Vector3.up * 5.4f;
            amnt.SetTrigger("Jump");
            jumpCount += 1;
            AudioManager.instance.PlayFX("Jump");
        }

        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= 10f) // ทุกๆ 10 วินาที
        {
            Speedz += 0.2f;
            timeSinceLastIncrease = 0f; // รีเซ็ตเวลาใหม่หลังจากเพิ่มความเร็ว
        }
        if (Input.GetKeyDown(KeyCode.S) && !isSliding)
        {
            isSliding = true;
            amnt.SetBool("Slide", true);
        }

        
        if (Input.GetKeyUp(KeyCode.S) && isSliding)
        {
            isSliding = false;
            amnt.SetBool("Slide", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounds"))
        {
            jumpCount = 0;
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Enermy"))
        {

        }
    }


}
