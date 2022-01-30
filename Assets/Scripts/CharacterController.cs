using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Creamos las variables necesarias
    //Variable de velocidad
    public float speed = 10.0f;
    //Variables de movimiento en X e Y
    private float ySpeed;
    private float xSpeed;

    void Update()
    {
   
        //Guardamos los imputs de X e Y en las variables
        ySpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        xSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Movemos al jugador
        transform.Translate(xSpeed, 0, ySpeed);

    }

}
