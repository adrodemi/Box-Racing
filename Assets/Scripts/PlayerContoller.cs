using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float horsePower = 20000f;
    [SerializeField] private float turnSpeed = 44f;
    private float horizontalInput;
    private float forwardInput;
    public KeyCode switchKey;
    public Camera mainCamera;
    public Camera hoodCamera;
    public Camera backCamera;
    int countCamera = 1;
    public string inputID;
    public TextMeshProUGUI speedometerText;
    public TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    [SerializeField] GameObject centerOfMass;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for km/h
            speedometerText.SetText("Speed: " + speed + " mph");

            rpm = (speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        }

        if (Input.GetKeyDown(switchKey))
        {
            if (countCamera == 1)
            {
                backCamera.enabled = false;
                mainCamera.enabled = true;
            }
            if (countCamera == 2)
            {
                mainCamera.enabled = false;
                hoodCamera.enabled = true;
            }
            if (countCamera == 3)
            {
                hoodCamera.enabled = false;
                backCamera.enabled = true;
                countCamera = 0;
            }
            countCamera++;
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
                wheelsOnGround++;
        }
        if (wheelsOnGround == 4)
            return true;
        else
            return false;
    }
}