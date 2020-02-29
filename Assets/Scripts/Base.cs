using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float hp = 3f;
    public AudioSource source;
    public AudioClip explosion;
    public AudioClip losebase;

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            source.clip = explosion;
            source.PlayOneShot(source.clip);
            source.clip = losebase;
            source.PlayOneShot(source.clip);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hp = hp - 1;
        transform.localScale /= 1.5f;
        Destroy(other.gameObject);
    }
}
