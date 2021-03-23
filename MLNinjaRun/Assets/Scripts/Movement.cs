using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;

    public float speed = 2f;
    public float changeLaneSpeed = 6;

    bool moveR;
    bool moveL;

    Vector3 startPos;
    Vector3 endPos;
    int target = 0;

    int timer;

    Jump Jump;
    Health Health;
    public PlatformGeneration PlatformGeneration;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        moveR = false;
        moveL = false;

        Jump = GetComponent<Jump>();
        Health = GetComponent<Health>();
    }

    void Update()
    {
        //check input for right 
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            moveR = true;
        }

        //pcheck input for left
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            moveL = true;
        }
     }

     void FixedUpdate()
     { 
        //increase speed after time intervals
        timer++;
        if(timer == 2000 && speed < 4.5f){
            speed += .5f;
            Jump.fallMultiplier += .5f;
            timer = 0;
        }

        //smoothly move from lane to lane
        startPos = transform.position;
        endPos = new Vector3 (target, startPos.y, startPos.z);
        if(moveR){
            moveR = false;
            //if moveR, change target to next lane, but can never be more than 1
            target = Mathf.Min(1, target + 1);
            endPos = new Vector3 (target, startPos.y, startPos.z);

        } else if(moveL){
            moveL = false;
            //if moveL, change target to next lane, but can never be less than -1
            target = Mathf.Max(-1, target -1);
            endPos = new Vector3 (target, startPos.y, startPos.z);
        }
        //move towards target
        transform.position = Vector3.MoveTowards(startPos, endPos, changeLaneSpeed * Time.deltaTime);

        //when player falls, move towards center and set speed to 2
        if(rigidbody.position.y < -30){
            target = 0;
            speed = 2;

            if(Health.lives > 0){
            //reset player to fall back to start positon
                rigidbody.transform.position = new Vector3 (0, 30, -1);

                PlatformGeneration.ResetPlatformGen();
            }
        } 
    }
}