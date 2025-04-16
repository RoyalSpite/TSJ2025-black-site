using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDetection : MonoBehaviour
{
    [SerializeField] private Player player;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision){

        if(collision.gameObject.tag == "Enemy"){
            // print("Shoot");
            // player.Fire();
        }
    }
}