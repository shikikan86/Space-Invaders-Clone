using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerScore.playerscore = 0;
            GameOver.dead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("scene1");
        }
    }
}
