using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    //if R is pressed, reload the scene
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerController.ammo = 210;
            PlayerScore.playerscore = 0;
            GameOver.dead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("scene1");
        }
    }
}
