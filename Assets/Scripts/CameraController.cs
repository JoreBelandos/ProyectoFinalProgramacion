using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Creamos las variables de control de la camara
    //Control de la sensibilidad
    public float sensitivity = 5.0f;
    //Control de la suavidad de rotacion
    public float smoothing = 2.0f;
    //Objeto del jugador
    public GameObject character;

    //Variables de control del movimiento
    private Vector2 mouseMove;
    private Vector2 smoothMouseMove;


    // Update is called once per frame
    void Update()
    {
        //Creamos una variable para guardar los imputs del raton
        var cameraVector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        cameraVector = Vector2.Scale(cameraVector, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        //Controlamos los movimientos del raton en X e Y
        smoothMouseMove.x = Mathf.Lerp(smoothMouseMove.x, cameraVector.x, 1f / smoothing);
        smoothMouseMove.y = Mathf.Lerp(smoothMouseMove.y, cameraVector.y, 1f / smoothing);

        mouseMove += smoothMouseMove;

        //Rotacion de la camara
        transform.localRotation = Quaternion.AngleAxis(-mouseMove.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseMove.x, character.transform.up);
    }
}
