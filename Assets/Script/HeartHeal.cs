using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    public int healthIncreaseAmount = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // เช็คว่าถ้าชนกับวัตถุที่มี Tag เป็น "Player"
        if (other.CompareTag("Player"))
        {
            // เพิ่มค่า health ให้ player (ถ้ามีฟังก์ชันใน player)
            RunnerHealth playerHealth = other.GetComponent<RunnerHealth>();
            if (playerHealth != null)
            {
                playerHealth.IncreaseHealth(10f); // เพิ่มค่า health ให้ player 10 หน่วย
            }

            // ทำลายวัตถุ Heart หลังจากชนกับ player
            Destroy(gameObject);
        }
        
    }

}
