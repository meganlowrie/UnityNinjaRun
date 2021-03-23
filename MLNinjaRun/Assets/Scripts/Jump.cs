using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;

    float jumpForce = 4.5f;
    public float fallMultiplier = 1.5f; 
    public bool isGrounded;
    float distToGround = .005f; 

    public ParticleSystem dirtParticles;
    public ParticleSystem dustParticles;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        isGrounded = true;

        dirtParticles.Play();
        dustParticles.Play();
    }

    void Update()
    {
        //raycast for isGrounded- only cast in layer 9 (ground layer) and ignore triggers
        isGrounded = Physics.Raycast(rigidbody.transform.position, Vector3.down, distToGround, 1 << 9, QueryTriggerInteraction.Ignore);

        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rigidbody.velocity = Vector3.up * jumpForce;

            dirtParticles.Stop();
            dustParticles.Stop();
            StartCoroutine(particlePlay());
        }  

        //increase gravity as falling
        if (rigidbody.velocity.y < 0){
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if(rigidbody.position.y < -0.5){
            fallMultiplier = 1;

            dirtParticles.Stop();
            dustParticles.Stop();

            if(rigidbody.position.y < -30){
                fallMultiplier = 1.5f;
            }
        }
    }

    IEnumerator particlePlay()
    {
        yield return new WaitForSeconds(1);
        dirtParticles.Play();
        dustParticles.Play();
    }
}
