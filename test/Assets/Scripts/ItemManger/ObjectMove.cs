using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
