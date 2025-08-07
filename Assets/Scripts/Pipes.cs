using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float minY = -1f;
    [SerializeField] private float maxY = 3f;
    // Start is called before the first frame update
    void Start()
    {
        //altura variável dos canos
        float altura = Random.Range(minY, maxY);
        transform.position = new Vector2(transform.position.x, altura); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x - speed * Time.deltaTime,
            transform.position.y
        );
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("DestroyPipe"))
        {
            Destroy(gameObject);
        }
    }
}
