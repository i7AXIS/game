using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour {
    public CharacterController controller;
    public UIManager UIManager;
    public bool isDashing = false;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public Vector3 moveDir;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) {
            UIManager.SetCanvas(true);
            UIManager.SetGameOverMenu(true);
        }
        if (isDashing) {
            horizontal = 0f;
            vertical = 0f;
        }
        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            controller.Move(moveDir * speed * Time.deltaTime);
        }

    }

}
