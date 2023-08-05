using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    [SerializeField] float speed;
    [SerializeField] float torque;
    private float horizontalInput;
    private float verticalInput;

    private GameManager gameManager;
    //private RestartBallPosition restartBall;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //restartBall = GameObject.Find("Ball(Clone)").GetComponent<RestartBallPosition>();
        //restartBall = FindObjectOfType<RestartBallPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.left * speed * verticalInput);
            playerRb.AddTorque(Vector3.left * torque * horizontalInput);
        }        
    }
}
