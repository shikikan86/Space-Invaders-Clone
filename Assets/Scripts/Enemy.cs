using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite startsprite;
    public Sprite alt;
    public Sprite explode;
    public SpriteRenderer spriteRenderer;
    public bool alive = true;

    public AudioSource source;
    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeSprite());
    }

    IEnumerator ChangeSprite()
    {
        while (alive)
        {
            if(spriteRenderer.sprite == startsprite)
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Enemy")
        {
            source.clip = explosion;
            source.PlayOneShot(source.clip);
            StartCoroutine(Explode());
        }
        
    }
}
