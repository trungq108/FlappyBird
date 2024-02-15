using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed = 1.0f;
    public float streng = 15f;

    private SpriteRenderer spriteRender;
    private Rigidbody2D rb;
    private int spriteIndex = 0;
    private Vector3 direction;
    private void Awake()
    {
        spriteRender=GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        InvokeRepeating("AnimateSpite", 0.15f, 0.15f);
    }

    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            direction = Vector3.up * streng;
            rb.AddForce(direction, ForceMode2D.Impulse);
        }
    }

    void AnimateSpite()
    {
        spriteIndex++;
        if(spriteIndex > sprites.Length) 
        {
            spriteIndex = 0;
        }                   
        else if (spriteIndex <= sprites.Length)
        {
            spriteRender.sprite = sprites[spriteIndex];
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            GameManager.Instance.GameOver();
        }
        if (other.gameObject.CompareTag("ScoredPlace"))
        {
            GameManager.Instance.AddScore();
        }
    }


}
