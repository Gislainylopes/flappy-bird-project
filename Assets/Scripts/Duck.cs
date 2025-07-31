using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private bool jumping;
    private Rigidbody2D rb;
    private bool finish;

    [SerializeField] private float jumpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "pipes")
        {
            Debug.Log("Game Over!");
            finish = true;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Teclou o Espaço");
            jumping = true;
        }
    }


    void FixedUpdate()
    {
        if (jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed; // (0, 1) * jumpSpeed
            jumping = false;
        }
    }

}
