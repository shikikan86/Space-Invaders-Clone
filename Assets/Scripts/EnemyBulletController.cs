using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Transform bullet;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        speed = 0.1f;

    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if(bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.dead = true;
        }

        else if(other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            Base basehp = playerBase.GetComponent<Base>();
            basehp.hp -= 1;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
