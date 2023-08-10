using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // Variables
    public Text scoreText;
    private int goals = 0;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        goals = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive && other.CompareTag("Ball"))
        {
            goals += 1;
            scoreText.text = "Score : " + goals;
            Destroy(other.gameObject);
            gameManager.SpawnBall();
        }        
    }
}
