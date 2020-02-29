using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float LeftBoundary, RightBoundary;

    public GameObject shot;
    public Transform spawnshot;
    public float fireRate;
    public float next;

    public AudioSource source;
    public AudioClip bgm;
    public AudioClip shoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        speed = 6f;
        LeftBoundary = -9.5f;
        RightBoundary = 9.5f;
        fireRate = 0.7f;
        source = GetComponent<AudioSource>();
        source.clip = bgm;
        source.PlayOneShot(source.clip);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if(player.position.x < LeftBoundary)
        {
            player.position = new Vector3(LeftBoundary, -5.28f, 0f);
        }
        else if(player.position.x > RightBoundary)
        {
            player.position = new Vector3(RightBoundary, -5.28f, 0f);
        }


        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > next)
        {
            next = Time.time + fireRate;
            Instantiate(shot, spawnshot.position + new Vector3(0f,1f,0f), spawnshot.rotation);
            source.clip = shoot;
            source.PlayOneShot(source.clip);
        }
    }
}
