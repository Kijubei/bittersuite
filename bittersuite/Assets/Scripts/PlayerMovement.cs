using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float rotationSpeed = 100;
    public float gravity = 20.0f;

    public Transform playerCam;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotationY = Vector3.zero;
    private Vector3 rotationX = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        receiveInput();
        applyGravity();
        applyInput();
    }

    private void receiveInput() {
        if (characterController.isGrounded) {
            receiveMovement();
            receiveJump();
        }
        receiveTurn();
    }

    private void receiveMovement() {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = GetCameraTurn() * moveDirection;
        moveDirection *= speed;
    }

    private void receiveJump() {
        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
    }

    private void receiveTurn() {
        //Input.GetAxis("Mouse X")
        rotationY = new Vector3(0,Input.GetAxis("Mouse X"),0);
        rotationY *= rotationSpeed;
        rotationX = new Vector3(Input.GetAxis("Mouse Y")*-1,0,0);
        rotationX *= rotationSpeed;

        // Vector3 rotationNorm = rotation.normalized;
        // kamera nach X und Y drehen
        // player nur auf Y achse drehen
    }

    private void applyGravity() {
        moveDirection.y -= gravity * Time.deltaTime;
    }

    private void applyInput() {
        characterController.transform.Rotate(rotationY * Time.deltaTime);
        playerCam.transform.Rotate(rotationX* Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private Quaternion GetCameraTurn()
    {
        // ka was ein Quaternion sein soll
        return Quaternion.AngleAxis(
            playerCam.rotation.eulerAngles.y,
            Vector3.up);
    }


}
