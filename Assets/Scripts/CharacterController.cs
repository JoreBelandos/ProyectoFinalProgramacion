using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    private float ySpeed;
    private float xSpeed;
    Rigidbody rb;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
   
        ySpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        xSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(xSpeed, 0, ySpeed);

        if ((rb.velocity.x != 0) || (rb.velocity.y != 0))
        {
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }

    }

    internal void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
