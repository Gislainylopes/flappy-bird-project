using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private bool jumping;
    private Rigidbody2D rb;
    //public bool finish = false;

    [SerializeField] private float jumpSpeed;
    //[SerializeField] private GameObject finish, duck;


    // Start is called before the first frame update
    void Start()
    {
        //finish = false;
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            GameController.instance.IncreaseScore(1);
        }
    }

}
