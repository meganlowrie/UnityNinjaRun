using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void FixedUpdate()
    {
        //if player on ground/jumping, only follow in z axis
        if( player.position.y > -.55f && player.position.y < 1f)
        {
            transform.position = new Vector3 (0, 1, player.position.z - 1.8f);
        }
        //if player falls off, follow all axes 
        else 
        {
           transform.position = new Vector3 (player.position.x, player.position.y + .5f, player.position.z - 1.8f);
        }
    }
}
