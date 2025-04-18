using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            OnBecameInvisible();
        }
    }

    void OnBecameInvisible(){
        // print("out of screen");
        gameObject.SetActive(false);
    }
}
