using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedChanger : MonoBehaviour
{
    public PointsSystem pointsSystem;
    public ScrollingEffect[] scrollingEffects;
    public Spawner[] spawner;

    private int nextScoreThreshold = 150;

    void Update()
    {
        if (pointsSystem.score >= nextScoreThreshold)
        {
            foreach (ScrollingEffect scrollingEffect in scrollingEffects)
            {
                if (scrollingEffect.gameObject.name == "CitySky")
                    scrollingEffect.scrollSpeed = new Vector2(Mathf.Min(scrollingEffect.scrollSpeed.x + 0.05f, 0.2f), 0f);
                else if (scrollingEffect.gameObject.name == "City1")
                    scrollingEffect.scrollSpeed = new Vector2(Mathf.Min(scrollingEffect.scrollSpeed.x + 0.05f, 0.35f), 0f);
                else if (scrollingEffect.gameObject.name == "City2")
                    scrollingEffect.scrollSpeed = new Vector2(Mathf.Min(scrollingEffect.scrollSpeed.x + 0.05f, 0.4f), 0f);
                else if (scrollingEffect.gameObject.name == "City3")
                    scrollingEffect.scrollSpeed = new Vector2(Mathf.Min(scrollingEffect.scrollSpeed.x + 0.05f, 0.45f), 0f);
            }

            foreach (Spawner spawner in spawner)
            {
                spawner.obstacleSpawnTime = Mathf.Max(spawner.obstacleSpawnTime - 0.3f, 0.5f); // Limiter
                spawner.obstacleSpeed += 1.5f;
            }

            nextScoreThreshold += 150;
        }
    }
}
