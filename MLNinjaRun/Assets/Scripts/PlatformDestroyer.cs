using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    GameObject platformDestructionPoint;
    public GameObject [] platformsInGame;

    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    void Update()
    {
        //if platform is less than the destruction point's z position, then delete platform (destruction point moves forward with the camera)
        if(transform.position.z < platformDestructionPoint.transform.position.z){
            Destroy(gameObject);
        }
    }
    public void DestroyPlatforms(){
        //delete platforms in game
        platformsInGame = GameObject.FindGameObjectsWithTag("platform");
        foreach(GameObject platform in platformsInGame){
            GameObject.Destroy(platform);
        }
    }
}
