using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLose : MonoBehaviour
{
    public Transform playerBase;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        playerBase = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBase.childCount == 0)
        {
            source.Stop();
            GameOver.dead = true;
        }
    }
}
