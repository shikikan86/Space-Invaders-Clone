using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLose : MonoBehaviour
{
    public Transform playerBase;
    public AudioSource source;
    public AudioClip wilhelm;
    public AudioClip lose;
    public bool Lock;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<Transform>();
        Lock = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase.childCount == 0)
        {
            
            if (Lock)
            {
                Lock = false;
                source.Stop();
                source.clip = wilhelm;
                source.PlayOneShot(source.clip);
                source.clip = lose;
                source.PlayOneShot(source.clip);
            }
            
            GameOver.dead = true;
        }
    }
}
