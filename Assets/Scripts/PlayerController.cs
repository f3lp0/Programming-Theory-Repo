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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            // ABSTRACTION
            // MovePlayer() is used to move the player
            MovePlayer(speed, torque); // move the player with speed and torque
            //MovePlayer(speed); // move the player with only speed
        }
    }

    // POLYMORPHISM
    // overload function
    protected virtual void MovePlayer(float speed, float torque)
    {
        if (isInXLimits())
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);
        }        
        playerRb.AddTorque(Vector3.left * torque * 100 * horizontalInput, ForceMode.Impulse);
    }

    protected virtual void MovePlayer(float speed)
    {
        if (isInXLimits())
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);
        }
        transform.RotateAround(new Vector3(0, 4, 2), Vector3.left, speed * horizontalInput * Time.deltaTime / rateRotation);
        playerRb.AddTorque(Vector3.left * speed * horizontalInput / rateSpeed, ForceMode.Acceleration);        
    }

    // ABSTRACTION
    // isInXLimits() is used to avoid the player to leave the stadium
    protected bool isInXLimits()
    {
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
            return false;
        }
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
            return false;
        }
        else
        {
            return true;
        }
    }
}
