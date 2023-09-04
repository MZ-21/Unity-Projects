using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;



    // Start is called before the first frame update
    void Start()
    {   //FindWithTag returns null if no tag found. Else gets transform position of the tag with player
        player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate() //lateUpdate is called every frame if the behaviour is enabled (same as update) but this is called after every update so wont have conflict
    {   
        if(!player){
            return; //exits out of function and doesnt execute code below
        }
        tempPos = transform.position; //current position of camera
        tempPos.x = player.position.x; // take x position of tempPos and set it to the players current position
        
        
        if( tempPos.x < minX){
            tempPos.x = minX;
            // Debug.Log("max");
        }
        if(tempPos.x > maxX){
            tempPos.x = maxX;
            //Debug.Log("min");
        }
        transform.position = tempPos; // now assign that value back to the current position of the camera (y,z of camera dont change but x positions follows player
    }
}
