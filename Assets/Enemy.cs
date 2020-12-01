using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //instantiate cloud particle prefab
    [SerializeField] private GameObject _cloudParticlePrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //destroy an enemy if bird collides with it
        if (collision.collider.GetComponent<Bird>() != null)
        {
            //spawn cloudParticlePrefab when position (transform) and rotation (quaternion: default rotation) occurs
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
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
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return; 
        }
    }
}
