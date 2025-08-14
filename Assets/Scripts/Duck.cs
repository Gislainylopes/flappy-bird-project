using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private bool jumping;
    private Rigidbody2D rb;

    [SerializeField] private float jumpSpeed;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip dieSound;

    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
    }


    void FixedUpdate()
    {
        if (jumping)
        {
            AudioController.instance.PlayAudioClip(jumpSound, false);
            rb.velocity = Vector2.up * jumpSpeed; // (0, 1) * jumpSpeed
            jumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            AudioController.instance.PlayAudioClip(scoreSound, false);
            GameController.instance.IncreaseScore(1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("Ground"))
        {
            AudioController.instance.PlayAudioClip(dieSound, false);
            GameController.instance.GameOver();
        }
    }

}
