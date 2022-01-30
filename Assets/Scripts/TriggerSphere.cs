using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSphere : MonoBehaviour
{
    //Creamos las variables del tereno para modificar la altura al desplazar el objeto
    public Terrain terreno;
    TerrainData terrainData;


    private void OnTriggerEnter(Collider other)
    {
        //Comprobamos si el que entra en el trigger es el jugador
        if (other.tag == "Player")
        {
            //Sumamos los puntos y el tiempo en el HUD
            FindObjectOfType<PuntosyTiempo>().puntos++;
            FindObjectOfType<PuntosyTiempo>().tiempo = FindObjectOfType<PuntosyTiempo>().tiempo + 10f;
            //Iniciamos la corrutina
            StartCoroutine(reposition());
        }
        //Comprobamos si el que entra en el trigger es el terreno
        if (other.tag == "Terreno")
        {
            //Iniciamos la corrutina
            StartCoroutine(reposition());
        }


    }

    private IEnumerator reposition()
    {
        //Creamos nuevos puntos de posicion
        int x = Random.Range(-50, 50);
        int z = Random.Range(-50, 50);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terreno.SampleHeight(pos) - 0.5f;
        //Asignamos la posicion de este objeto a la nueva creada
        transform.position = pos;
        //Activamos el objeto
        gameObject.SetActive(true);
        //Hacemos esperar por 5 segundos
        yield return new WaitForSeconds(5);


    }
}
