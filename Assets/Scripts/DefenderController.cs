using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class DefenderController : PlayerController
{
    // Variables
    private float forceAttenuation = 40;
    private float speedAttenuation = 10;

    // POLYMORPHISM
    // overriding function
    protected override void MovePlayer(float speed, float torque)
    {
        if (isInXLimits())
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime / speedAttenuation);
        }
        playerRb.AddTorque(Vector3.left * torque * 100 * horizontalInput / forceAttenuation / forceAttenuation, ForceMode.VelocityChange);
    }

    protected override void MovePlayer(float speed)
    {
        if (isInXLimits())
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime / speedAttenuation);
        }
        transform.RotateAround(new Vector3(0, 4, 2), Vector3.left, speed * horizontalInput * Time.deltaTime / rateRotation / speedAttenuation);
        playerRb.AddTorque(Vector3.left * speed * horizontalInput / rateSpeed / speedAttenuation / forceAttenuation, ForceMode.Acceleration);

    }
}
