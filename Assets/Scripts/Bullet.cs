using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bullet;
    public GameObject enemycontroller;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        speed = 0.5f;
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;
        if(bullet.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerscore += 10;
        }
        if (other.tag == "Enemy2")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerscore += 20;
        }
        if (other.tag == "Enemy3")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerscore += 30;
        }
        if (other.tag == "Enemy4")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerscore += 100;
        }

        if (other.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
