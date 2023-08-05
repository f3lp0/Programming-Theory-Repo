using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBallPosition : MonoBehaviour
{
    // Variables
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartBall();
            }
        }        
    }

    public void RestartBall()
    {
        gameManager.SpawnBall();
        Destroy(gameObject);
    }
}
