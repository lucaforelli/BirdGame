using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //loop through each enemy
        foreach(Enemy enemy in _enemies)
        {
            //check if enemy is not dead, exit out of method 
            if (enemy != null)
            {
                return;
            }

            Debug.Log("You killed all enemies");

            //increment index
            _nextLevelIndex++;
            //loads next level
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
