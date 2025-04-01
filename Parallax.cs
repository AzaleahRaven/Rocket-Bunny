using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;          // Layer to move
        public float parallaxSpeed;      // Speed of the layer
    }

    public ParallaxLayer[] layers;       // Array of parallax layers
    public float length;                 // Length of the texture before repeating
    private Vector3 startPosition;       // Starting position of the layer

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float distance = Time.time * layers[0].parallaxSpeed; // Reference speed for all layers

        for (int i = 0; i < layers.Length; i++)
        {
            float temp = (distance * (1 - layers[i].parallaxSpeed)) % length;
            layers[i].layer.position = startPosition + Vector3.left * temp;
        }
    }
}
