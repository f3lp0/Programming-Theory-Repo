using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    private float timeLeft = 45;
    private float spawnRate = 5.0f;

    public bool isGameActive;
    public Text timerText;
    public Text gameOverText;
    public GameObject ballObject;
    public List<GameObject> obstaclePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        SpawnBall();
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            //timerText.SetText("Time: " + Mathf.Round(timeLeft));
            timerText.text = "Time: " + Mathf.Round(timeLeft) + " s";
            if (timeLeft < 0)
            {
                GameOver();
            }
        }        
    }

    // While game is active spawn a random target
    IEnumerator SpawnObstacle()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            if (isGameActive)
            {
                int index = Random.Range(0, obstaclePrefabs.Count);
                float xPos = Random.Range(-4, 4);
                Instantiate(obstaclePrefabs[index], new Vector3(xPos, 7, -5), obstaclePrefabs[index].transform.rotation);
            }
        }
    }

    public void SpawnBall()
    {
        if (isGameActive)
        {
            Instantiate(ballObject, new Vector3(0, 7, 0), ballObject.transform.rotation);
        }
    }

    
    public void GameOver()
    {
        Debug.Log("Game over!");
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
