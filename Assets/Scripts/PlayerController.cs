using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public AudioSource source2;
    public AudioClip bgm;
    public AudioClip shoot;
    public AudioClip explosion;

    public Sprite startsprite;
    public Sprite alt;
    public Sprite explode;
    public Sprite fire;
    public SpriteRenderer spriteRenderer;
    public bool alive = true;
    public static int ammo;
    public Text ammotext;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        speed = 6f;
        LeftBoundary = -9.5f;
        RightBoundary = 9.5f;
        fireRate = 0.1f;
        source = GetComponent<AudioSource>();
        source.clip = bgm;
        source.PlayOneShot(source.clip);
        ammo = 210;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeSprite());
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
        ammotext.text = "Ammo: " + ammo.ToString();
        if (Input.GetKey(KeyCode.Space) && Time.time > next && ammo > 0)
        {
            StartCoroutine(ShootSprite());
            next = Time.time + fireRate;
            Instantiate(shot, spawnshot.position + new Vector3(0f,1f,0f), spawnshot.rotation);
            Instantiate(shot, spawnshot.position + new Vector3(-0.5f, 0f, 0f), spawnshot.rotation);
            Instantiate(shot, spawnshot.position + new Vector3(0.5f, 0f, 0f), spawnshot.rotation);
            source.clip = shoot;
            source.PlayOneShot(source.clip);
            ammo = ammo - 3;
            if(ammo < 0)
            {
                ammo = 0;
            }
        }
    }

    IEnumerator ChangeSprite()
    {
        while (alive)
        {
            if (spriteRenderer.sprite == startsprite)
            {
                spriteRenderer.sprite = alt;
            }
            else
            {
                spriteRenderer.sprite = startsprite;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Explode()
    {
        alive = false;
        spriteRenderer.sprite = explode;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = startsprite;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = explode;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        GameOver.dead = true;
    }

    IEnumerator ShootSprite()
    {
        spriteRenderer.sprite = fire;
        yield return new WaitForSeconds(0.1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            source2.clip = explosion;
            source2.PlayOneShot(source2.clip);
            StartCoroutine(Explode());
        }

    }
}
