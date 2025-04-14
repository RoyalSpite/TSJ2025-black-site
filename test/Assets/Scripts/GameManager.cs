using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Player player;
    [SerializeField] private Transform[] roadPosition;

    [SerializeField] private int laneIndex = 0;
    [SerializeField] private int colIndex = 0;

    void Start()
    {
        player.transform.position = new Vector3(
            player.transform.position.x,
            roadPosition[laneIndex].position.y
        );
    }

    // Update is called once per frame
    void Update()
    {
        
        // player movement
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
            // up and down
            if(player.isMoveable){

                if(Input.GetKeyDown(KeyCode.W)){
                    laneIndex = (int) MathF.Max(laneIndex - 1, 0);
                }
                else if(Input.GetKeyDown(KeyCode.S)){
                    laneIndex = (int) MathF.Min(laneIndex + 1, roadPosition.Length - 1);
                }

                player.transform.position = new Vector3(
                    player.transform.position.x,
                    roadPosition[laneIndex].position.y
                );
            }
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)){
            // left and right
            if(player.isMoveable){
                Vector3 newPos = new Vector3();
                if(Input.GetKeyDown(KeyCode.D)){
                    if(colIndex < 3){
                        newPos.x = 1;
                        colIndex += 1;
                    }
                }
                else if(Input.GetKeyDown(KeyCode.A)){
                    if(colIndex > 0){
                        newPos.x = -1;
                        colIndex -= 1;
                    }
                }

                player.transform.position += newPos;
            }

        }

    }
}
