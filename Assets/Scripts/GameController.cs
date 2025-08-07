using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject message, duck;
    [SerializeField] private GameObject pipes, source;
    private float interval = 2f;
    private bool started;
    private int score;
    public static GameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        started = false;
        InvokeRepeating("SpawnPipes", 0f, interval);
    }

    private void SpawnPipes()
    {
        if (!started) return;

        Instantiate(
            pipes,
            source.transform.position,
            Quaternion.identity
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // message.SetActive(true);
            Destroy(message);
            duck.SetActive(true);
            started = true;
        }

    }
    public void IncreaseScore(int score)
    {
        this.score += score;
        Debug.Log("Score: " + this.score);
    }
}

    
