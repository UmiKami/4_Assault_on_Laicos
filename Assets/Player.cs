using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float Speed = 20f;

    [SerializeField] float positionPitchFactor = -2.05f;
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 2.45f;
    [SerializeField] float controlRollFactor = 26f;

    float xThrow, yThrow;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControl = -xThrow * controlRollFactor;

        float pitch = pitchDueToControl + pitchDueToPosition;
        float yaw = yawDueToPosition;
        float roll = rollDueToControl;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // X axis 
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;  // Distance from the last frame
        float rawXPos = transform.localPosition.x + xOffset;   // Current position plus constant speed

        // Y axis
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawXPos, -14f, 14f), Mathf.Clamp(rawYPos, -5.1f, 5.1f), transform.localPosition.z);
    }
}
