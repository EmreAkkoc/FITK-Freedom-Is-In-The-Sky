using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m/s")] [SerializeField] private float movementSpeed = 25f;
    private float xMissile;
    private float yMissile;
    private float xOffset;
    private float yOffset;
    [Range(-10f,10f)] [SerializeField] private float leftRange, rightRange;
    [Range(-10f,10f)] [SerializeField] private float downRange, upRange;

    [SerializeField] private float pitchFactor = -5f;
    [SerializeField] private float yawFactor = 2f;
    [SerializeField] private float controlpitchFactor = -30f;
    [SerializeField] private float controlrollFactor = -30f;
    //[SerializeField] private float controlyawFactor = 2f;
    private float xThrow, yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Movement();
       Rotation();
    }

    private void Movement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = xThrow * movementSpeed * Time.deltaTime;
        xMissile = transform.localPosition.x + xOffset;
        var clampedX = Mathf.Clamp(xMissile, leftRange, rightRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = yThrow * movementSpeed * Time.deltaTime;
        yMissile = transform.localPosition.y + yOffset;
        var clampedY = Mathf.Clamp(yMissile, downRange, upRange);

        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
        print(xThrow);
    }

    private void Rotation()
    {
        
        var pitch = transform.localPosition.y * pitchFactor + yThrow * controlpitchFactor;
        //var yaw = transform.position.x * yawFactor;
        var roll = xThrow * controlrollFactor;
        var yaw = transform.localPosition.x * yawFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
