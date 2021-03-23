using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Movement Movement;

    public GameObject platformGenerator;
    PlatformDestroyer PlatformDestroyer;
    PlatformGeneration PlatformGeneration;

    public GameObject GameOverScreen;
    public Text gameOverScoreText;
    Pickups Pickups;

    void Start()
    {
        PlatformGeneration = platformGenerator.GetComponent<PlatformGeneration>();
        PlatformDestroyer = PlatformGeneration.platforms[1].GetComponent<PlatformDestroyer>();
        Pickups = GetComponent<Pickups>();
        Movement = GetComponent<Movement>();

        GameOverScreen.SetActive(false);
    }
    public void gameOver()
    {
        PlatformDestroyer.DestroyPlatforms();
        Destroy(platformGenerator);
        Movement.changeLaneSpeed = 0;

        GameOverScreen.SetActive(true);
        //gameOverScoreText.text = Pickups.score.ToString();
    }
}
