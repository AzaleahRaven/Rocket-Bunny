using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndestructableObject : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ObjectDestroyer")
        {
            Destroy(gameObject);
        }
    }

}
