using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private Vector3 _initialPosition;  //underscore used as convention 
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 500; //SerializedField enables launchPowrer to be modified in Unity script component 
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    //updates every frame per second
    public void Update()
    {
        //checks if bird is inactive for a period of time
        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime; 
        }

        if (transform.position.y > 10 ||
            transform.position.y < -20 ||
            transform.position.x > 20 ||
            transform.position.x < -20||
            _timeSittingAround > 3)
        {
            //loads active scene's name
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName); 
        }
    }

    //method call everytime mouse is pressed on bird
  private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        //set current position of bird and add movement to object
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;  //reset gravity
        _birdWasLaunched = true;
    }
    
    //move bird with mouse pressed 
    private void OnMouseDrag()
    {
        //create new vector instance and set it to mouse input 
         Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //set newPosition to x and y, in order to make bird visible
         transform.position = new Vector3(newPosition.x, newPosition.y);
    } 
}
