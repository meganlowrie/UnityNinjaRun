using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    
    public GameObject [] platforms;
    private int platformSelector;
    
    public Transform generationPoint;
    public float distBetween;
    private float platformLength;
    private int gapBool;

    public GameObject player;

    PlatformDestroyer PlatformDestroyer;

    void Start()
    {
        platformLength = platforms[platformSelector].transform.localScale.z;
        PlatformDestroyer = platforms[1].GetComponent<PlatformDestroyer>();
    }

    void Update()
    {
        //if further back than generation point, then create a new platform and move forward point to end of new platform 
        if(transform.position.z < generationPoint.position.z)
        {
            //randomly choose between the 4 kinds of platforms
            platformSelector = Random.Range(0, platforms.Length);

            //randonly choose if there will be a space between the last platform and the new platfrom about to be instantiated
            gapBool = Random.Range(0, 2);
            
            if(gapBool == 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformLength);
            }
            if(gapBool == 1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformLength + distBetween);
            }
            //create new platform
            Instantiate(platforms[platformSelector], transform.position, transform.rotation);
        }
    }

    public void ResetPlatformGen()
    {
        //reset this point back to the start and destroy all platforms currently in the scene
            PlatformDestroyer.DestroyPlatforms();
            transform.position = new Vector3 (0, -3, -0.15f);
    }
}
