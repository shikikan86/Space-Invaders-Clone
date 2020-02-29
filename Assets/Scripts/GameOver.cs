using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool dead = false;
    public Text gameOver;
    public AudioSource source;
    public AudioSource source2;
    public AudioClip lose;
    public AudioClip wilhelm;

    public bool Lock = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            //source.Stop();

            //Lock makes sure the sound is only played once
            if (!Lock)
            {
                Lock = true;
                source2.clip = lose;
                source2.PlayOneShot(source2.clip);
                source2.clip = wilhelm;
                source2.PlayOneShot(source2.clip);
            }
            
            
        }
    }
}
