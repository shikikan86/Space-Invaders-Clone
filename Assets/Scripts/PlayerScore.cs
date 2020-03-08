using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static float playerscore = 0;
    public static float highscore = 0;
    public string temp, temp2;
    public Text scoretext;
    public Text highscoretext;
    // Start is called before the first frame update
    void Start()
    {
        playerscore = 0;
        scoretext = GetComponent<Text>();
    }

    //updates the text fields for score and high score
    void Update()
    {
        temp = string.Format("{0:0000}", playerscore);
        temp2 = string.Format("{0:0000}", highscore);
        scoretext.text = "Score: " + temp.ToString();
        highscoretext.text = "High Score: " + temp2.ToString();

        if(playerscore >= highscore)
        {
            highscore = playerscore;
        }
    }
}
