using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    protected Rigidbody playerRb;
    [SerializeField] protected float speed;
    [SerializeField] protected float torque;
    [SerializeField] protected float rateSpeed;
    [SerializeField] protected float rateRotation;
    protected float horizontalInput;
    protected float verticalInput;
    protected float xLimit = 3.4f;

    protected GameManager gameManager;
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
            MovePlayer(speed, torque);
            //MovePlayer(speed);
        }
    }

    protected virtual void MovePlayer(float speed, float torque)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else
        {
            //playerRb.AddForce(Vector3.left * speed * verticalInput);
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);

        }
        playerRb.AddTorque(Vector3.left * torque * 100 * horizontalInput, ForceMode.Impulse);
        //transform.Rotate(Vector3.left * speed * horizontalInput * Time.deltaTime / rateRotation, Space.Self);
    }

    protected virtual void MovePlayer(float speed)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.left * speed * verticalInput);
        //playerRb.AddTorque(Vector3.left * torque * horizontalInput);
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);
            
        }
        //transform.Rotate(Vector3.left * speed * horizontalInput / rateRotation, playerRb.centerOfMass.y);
        //transform.Rotate(Vector3.left * speed * horizontalInput *Time.deltaTime / rateRotation, Space.World);
        transform.RotateAround(new Vector3(0, 4, 2), Vector3.left, speed * horizontalInput * Time.deltaTime / rateRotation);
        playerRb.AddTorque(Vector3.left * speed * horizontalInput / rateSpeed, ForceMode.Acceleration);
        
    }
}
