using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] GameObject[] bullets;
    public int bulletIndex = 0;

    public Transform firePoint;   // จุดที่ยิงกระสุนออกไป
    public float fireRate = 0.2f;  // เวลาหน่วงระหว่างยิงแต่ละครั้ง
    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        // สร้างกระสุน
        bullets[bulletIndex].SetActive(true);
        bullets[bulletIndex].transform.position = firePoint.position;

        // หาทิศทางจาก firePoint ไปที่ตำแหน่งเมาส์
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // ล็อคไม่ให้มีค่า z
        Vector3 direction = (mousePosition - firePoint.position).normalized;

        // ส่งทิศทางให้กระสุน
        bullets[bulletIndex].GetComponent<Bullet>().SetDirection(direction);

        bulletIndex = (bulletIndex + 1 == bullets.Length)? 0 : bulletIndex + 1;

    }
}
