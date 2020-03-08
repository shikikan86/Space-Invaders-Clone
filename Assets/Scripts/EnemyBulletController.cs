using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Transform bullet;
    public float speed;
    public AudioSource source;
    public AudioClip blowup;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        speed = 0.1f;
    }

    //Fixed Update updates based on time passed rather than every frame
    void FixedUpdate()
    {
        //Move the bullet down, towards the player
        bullet.position += Vector3.up * -speed; 
        if(bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Player is dead if bullet hits them
        if(other.tag == "Player")
        {
            //source.clip = blowup;
            //source.PlayOneShot(source.clip);
            //Destroy(other.gameObject);
            Destroy(gameObject);
            //GameOver.dead = true;
        }
        //base colliding wasn't working here, so I moved it to the base script
        
    }
}
