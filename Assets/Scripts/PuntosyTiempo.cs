using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosyTiempo : MonoBehaviour
{
    //Creamos las variables necesarias
    public Text contadortiempo;
    public Text contadorpuntos;
    public int puntos;
    public float tiempo;
    public GameObject gameOver;
    public Text record;
    public GameObject ranking;
    public bool gamestart;

    // Inicializamos las variables
    void Start()
    {
        puntos = 0;
        tiempo = 50;
        gameOver.SetActive(false);
        gamestart = false;
        
    }

    void Update()
    {
        //Escribimos las variables en el HUD
        contadorpuntos.text = "" + puntos;
        contadortiempo.text = "" + tiempo.ToString("f0");
        if (gamestart == true)
        {
            tiempo = (tiempo - 1 * Time.deltaTime);

        }

        //Comprobamos si nos hemos quedado sin tiempo
        if (tiempo <= 0)
        {
            gameOver.SetActive(true);
            record.text = "Puntuacion: " + puntos;
            //Time.timeScale = 0;
            gamestart = false;
        }
    }
    public void activateGame()
    {
        gamestart = true;
    }

    public void guardarPuntos()
    {
        ranking.GetComponent<RankingManager>().InsertarPuntos(puntos);

    }
}
