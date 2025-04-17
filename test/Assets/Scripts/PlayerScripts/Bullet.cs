using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 moveDirection;

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // // ถ้าอยู่นอกกล้องนานเกินก็ทำลายตัวเอง
        // if (transform.position.magnitude > 50f)
        // {
        //     Destroy(gameObject);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible(){
        print("out of screen");
        Destroy(gameObject);
    }
}
