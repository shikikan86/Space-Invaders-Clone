using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform enemyHolder;
    public float speed;
    public int childCount;
    public GameObject shot;
    public Text winText;
    public float fireRate = 30f;
    public float v = 0.9f;
    public float timer = 3f;
    public float load;

    public AudioSource source;
    
    //Calling the function MoveEnemy with the given parameters for the increments to move the enemy
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, v);
        enemyHolder = GetComponent<Transform>();
        winText.enabled = false;
        speed = 1;
        childCount = enemyHolder.childCount;
        
    }


    void MoveEnemy()
    {
        //Moving the entire group
        enemyHolder.position += Vector3.right * speed;

        


        //Checks every enemy in the enemyholder object
        foreach (Transform enemy in enemyHolder)
        {
            
            //determines the borders for the enemy
            if (enemy.position.x < -9.5f || enemy.position.x > 9.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            //Enemy reaches the player
            if(enemy.position.y <= -3)
            {
                source.Stop();
                GameOver.dead = true;
                Time.timeScale = 0;
            }

            //Fire rate
            if(Random.Range(0,61) == 30) //one in 60 chance of an enemy shooting when moving
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            //checks if child count has gone down (changed), if so, speed up
            if(enemyHolder.childCount != childCount)
            {
                childCount = enemyHolder.childCount;
                CancelInvoke();
                v -= 0.01f;
                InvokeRepeating("MoveEnemy", 0.1f, v);
            }


        }
        //speeds up the last enemy by a more significant amount
        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.05f);
        }

        //Win condition
        if(enemyHolder.childCount <= 0)
        {
            //win text 
            winText.enabled = true;
            //Time.timeScale = 0;
            StartCoroutine(win());

        }
    }

    IEnumerator win()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }

    
    
}
