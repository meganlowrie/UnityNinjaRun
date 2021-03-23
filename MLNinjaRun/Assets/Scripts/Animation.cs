using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator Animator;
    Jump Jump;

    void Start()
    {
       Animator = GetComponent<Animator>(); 
       rigidbody = GetComponent<Rigidbody>();
       Jump = GetComponent<Jump>();
    }

    void Update()
    {
        //if not grounded, play jump animation
        if (!Jump.isGrounded && Input.GetButton("Jump")){
            Animator.SetBool("isJumping", true);
            Animator.SetBool("isRunning", false);
            Animator.SetBool("isFalling", false);
        }

        //if grounded, play running animation
        if(Jump.isGrounded){
            Animator.SetBool("isRunning", true);
            Animator.SetBool("isJumping", false);
            Animator.SetBool("isFalling", false);
        }
        //if fallen off platform, play falling animation
        if(rigidbody.position.y < -0.5){
            Animator.SetBool("isFalling", true);
            Animator.SetBool("isJumping", false);
            Animator.SetBool("isRunning", false);
        }
    }
}
