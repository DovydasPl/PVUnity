using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    float moveSpeed = 10f;
    float angleRad;
    float angleDeg;

    Vector3 lookAt;
    [HideInInspector]
    public Vector3 velocity;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity.x = input.x * moveSpeed;
        velocity.y = input.y * moveSpeed;
        controller.Move(velocity * Time.deltaTime);
    }

    void Update()
    {
        //Look at mouse, no need for now
        /*
        lookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        angleDeg = (180 / Mathf.PI) * angleRad;
        controller.RotateToMouse(angleDeg);
        */
    }


}
