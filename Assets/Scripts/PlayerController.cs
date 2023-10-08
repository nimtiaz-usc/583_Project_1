using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified from https://www.youtube.com/watch?v=qQLvcS9FxnY

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public int health = 5;

    CharacterController characterController;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
            health--;

            if (health == 0) {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start() {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;        
    }

    // Update is called once per frame
    void Update() {
        // movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // rotation
        characterController.Move(moveDirection * Time.deltaTime);
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }
}
