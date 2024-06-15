using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class CharacterDash : MonoBehaviour
{

    CharacterMovement moveScript;

    public float dashSpeed;
    public float dashDelay;
    public float dashTime;

    float dashTimer;

    // Start is called before the first frame update
    void Start() {
        moveScript = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f) {
            StartCoroutine(Dash());
            dashTimer = dashDelay;
        }
        if (dashTimer > 0f) {
            dashTimer -= Time.deltaTime;
        }
    }

    IEnumerator Dash() {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime) {
            moveScript.isDashing = true;
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
        moveScript.isDashing = false;
    }
}
