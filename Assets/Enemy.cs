using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy an enemy if bird collides with it
        if (collision.collider.GetComponent<Bird>() != null)
        {
            Destroy(gameObject);
            return; //quit
        }

        //check if other objects collided with an enemy 
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return; //quit 
        }

        if (collision.contacts[0].normal.y < -0.5)
        {
            Destroy(gameObject);
            return; 
        }
    }
}
