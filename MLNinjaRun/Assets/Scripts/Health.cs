using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Rigidbody rigidbody;

    public int lives;

    public GameObject[] heart;

    GameOver GameOver;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        heart = GameObject.FindGameObjectsWithTag("heart");
        GameOver = GetComponent<GameOver>();

        lives = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //when player falls, decrease lives by 1 and remove a heart 
        if(rigidbody.position.y < -30){
            if((lives ) > 0){
                lives --;
                heart[lives].SetActive(false);
            }
            //if no lives, game over
            if((lives) == 0){
                GameOver.gameOver();
            }
        } 
    }
}
