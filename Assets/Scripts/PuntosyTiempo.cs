using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosyTiempo : MonoBehaviour
{
    //Creamos las variables necesarias
    public Text contadortiempo;
    public Text contadorpuntos;
    public float puntos;
    public float tiempo;
    public GameObject gameOver;

    // Inicializamos las variables
    void Start()
    {
        puntos = 0;
        tiempo = 50;
        gameOver.SetActive(false);
    }

    void Update()
    {
        //Escribimos las variables en el HUD
        contadorpuntos.text = "" + puntos;
        contadortiempo.text = "" + tiempo.ToString("f0");

        tiempo = tiempo - 1 * Time.deltaTime;

        //Comprobamos si nos hemos quedado sin tiempo
        if (tiempo <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
