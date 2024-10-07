using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask RightDoor;
    public LayerMask WrongDoor;
    public float walkSpeed = 3f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 90f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;


    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        //bool isRunning = Input.GetKey(KeyCode.LeftShift) && !isZooming;
        float curSpeedX = canMove ? (walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion

        #region Handles Clicking
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked!");

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, RightDoor))
            {
                Debug.Log("Door Opened!");
                SceneManager.LoadScene(3);

            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, WrongDoor))
            {
                Debug.Log("Door Opened!");
                SceneManager.LoadScene(4);


            }
        }

            #endregion

            #region Resetting
            if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Test");
        }
        #endregion
    } 
}
