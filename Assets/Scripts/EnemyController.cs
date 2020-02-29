using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform enemyHolder;
    public float speed;
    public int childCount;
    public GameObject shot;
    public Text winText;
    public float fireRate = 30f;
    public float v = 0.9f;

    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, v);
        enemyHolder = GetComponent<Transform>();
        winText.enabled = false;
        speed = 1;
        childCount = enemyHolder.childCount;
        
    }

    void Update()
    {
        
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder)
        {
            if(enemy.position.x < -9.5f || enemy.position.x > 9.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if(enemy.position.y <= -3)
            {
                source.Stop();
                GameOver.dead = true;
                Time.timeScale = 0;
            }

            if(Random.Range(0,30) == 15) //one in 30 chance of an enemy shooting when moving
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            //checks if child count has gone down (changed), if so, speed up
            if(enemyHolder.childCount != childCount)
            {
                childCount = enemyHolder.childCount;
                CancelInvoke();
                v -= 0.02f;
                InvokeRepeating("MoveEnemy", 0.1f, v);
            }


        }

        //speedUp(enemyHolder.childCount);

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if(enemyHolder.childCount <= 0)
        {
            //win text 
            winText.enabled = true;
            Time.timeScale = 0;
        }
    }

    
    
}
