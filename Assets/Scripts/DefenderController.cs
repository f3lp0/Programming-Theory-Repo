using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : PlayerController
{
    protected override void MovePlayer(float speed, float torque)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.left * speed * verticalInput);
        playerRb.AddTorque(Vector3.left * torque * horizontalInput);
    }

    protected override void MovePlayer(float speed)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.left * speed * verticalInput);
        //playerRb.AddTorque(Vector3.left * torque * horizontalInput);
        playerRb.transform.Translate(Vector3.forward * speed * horizontalInput / 200);
        playerRb.transform.Rotate(Vector3.left, speed * verticalInput / 200);
    }
}
