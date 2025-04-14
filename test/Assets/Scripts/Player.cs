using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health = 30;
    [SerializeField] private float chargeTimePerShot = 0.75f;
    [SerializeField] private const int maxShot = 10;
    [SerializeField] private float range = 5;
    [SerializeField] private GameObject point;

    [SerializeField] private int shot = maxShot;
    private float countDown = 0;
    public bool isMoveable = true;

    // Update is called once per frame
    void Update()
    {
        // fire
        if(Input.GetMouseButtonDown(0)){

            Vector3 mousePosScreen = Input.mousePosition;
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);
            mousePosWorld.z = 0;

            // Debug.Log(mousePosWorld);
            // Debug.Log(Vector3.Distance(transform.position, Input.mousePosition));

            if(shot > 0 && (Vector2.Distance(transform.position, mousePosWorld) <= range)){
                Debug.Log("Fire");
                shot -= 1;
                point.SetActive(true);
                point.transform.position = mousePosWorld;
            }
        }
        else if(Input.GetMouseButtonUp(0)){
            point.SetActive(false);
        }

        // countdown
        if(maxShot >= shot){
            countDown += Time.deltaTime;
            if(countDown >= chargeTimePerShot){
                shot = (int)MathF.Min(maxShot, shot + 1);
                countDown = 0;
            }
        }

    }
}
