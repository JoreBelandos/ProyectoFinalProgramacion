using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //Creamos las variables necesarias
    //Creamos los eventos 
    public Event dropped;
    public Event pickup;
    //Creamos la variable del icono
    public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        //Ejecutamos el evento 
        dropped.Occurred(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        //Eliminamos el elemento al colisionar con el jugador
        if (other.gameObject.tag == "Player")
        {
            pickup.Occurred(this.gameObject);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject,5);
        }
    }
}
