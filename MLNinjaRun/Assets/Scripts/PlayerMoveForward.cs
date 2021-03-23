using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForward : MonoBehaviour
{
    Movement Movement;
    public GameObject Codey;

    void Start()
    {
        Movement =  Codey.GetComponent<Movement>();
    }

    void FixedUpdate()
    {
        //always move player forward
        transform.Translate(Vector3.forward * Movement.speed * Time.deltaTime); 
    }
}
