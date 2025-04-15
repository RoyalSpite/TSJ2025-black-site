using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float YBorder = 5f;
    private bool isUp = true;
    [SerializeField] private float speed = 3f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 newPos = new Vector3();

        int dir = (isUp? 1 : -1);
        newPos.y = (isUp? 1 : -1) * (Time.deltaTime * speed);

        if(Mathf.Abs(newPos.y + transform.position.y) >= YBorder){
            isUp = !isUp;
            transform.position = new Vector3(
                transform.position.x,
                dir * YBorder
            );
        }
        else transform.position += newPos;

    }
}
