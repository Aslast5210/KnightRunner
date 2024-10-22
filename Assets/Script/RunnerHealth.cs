using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthbar;
    private bool isDead;
    public GameManger gameMange;
    public float fallLimitY = -5f;
    private float timeSinceLastDamage = 0f;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = Mathf.Clamp(health /  maxHealth, 0, 1);

        if(health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameMange.gameOver();
            Debug.Log("Dead");
            AudioManager.instance.PlayFX("Over");
        }
        if (transform.position.y < fallLimitY)
        {
            health = 0;
            AudioManager.instance.PlayFX("Over");
        }

        // ลด health ทุกๆ 1 วินาที
        timeSinceLastDamage += Time.deltaTime;

        if (timeSinceLastDamage >= 1f)
        {
            health -= 1.5f;
            timeSinceLastDamage = 0f; // รีเซ็ตเวลาเพื่อเริ่มนับใหม่
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            IncreaseHealth(10f); // เพิ่มค่า health ตามจำนวนที่กำหนด
            Destroy(other.gameObject); // ทำลายวัตถุ Heart เมื่อชน
            AudioManager.instance.PlayFX("Healing");
        }
    }

    // ฟังก์ชันเพิ่ม health
    public void IncreaseHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth); // ทำให้ health ไม่เกิน maxHealth
        Debug.Log("Health increased! Current health: " + health);
    }

}
