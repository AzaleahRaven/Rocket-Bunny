using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public ScrollingEffect[] scrollingEffect;    
    public Spawner[] spawner;                    
    public HeartSystem heartSystem;              
    public PointsSystem pointsSystem;
    public KumaController kumaController;

    public GameObject gameOverScreen;

    public AudioSource backgroundMusic;
    public AudioClip playingMusic;
    public AudioClip gameOverMusic;

    private bool isGameOver = false;

    void Start()
    {
        backgroundMusic.clip = playingMusic;
        backgroundMusic.Play();
    }


    void Update()
    {
        if (!isGameOver && heartSystem.currentHealth == 0)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;

        gameOverScreen.SetActive(true);

        // Stop scrolling backgrounds
        foreach (ScrollingEffect scroll in scrollingEffect)
        {
            scroll.scrollSpeed = Vector2.zero;
        }

        foreach (Spawner spawner in spawner)
        {
            spawner.enabled = false;
        }

        pointsSystem.StopScore();

        kumaController.enabled = false;

        DestroyAllObstacles();

        if (backgroundMusic.clip != gameOverMusic)
        {
            backgroundMusic.clip = gameOverMusic;
            backgroundMusic.Play();
        }
    }

    void DestroyAllObstacles()
    {
        // Destroy all obstacles
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        // Destroy all blockers
        GameObject[] blockers = GameObject.FindGameObjectsWithTag("Blocker");
        foreach (GameObject blocker in blockers)
        {
            Destroy(blocker);
        }
    }

}
