using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosyTiempo : MonoBehaviour
{
    public Text contadortiempo;
    public Text contadorpuntos;
    public float puntos;
    public float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        tiempo = 30;
    }

    // Update is called once per frame
    void Update()
    {
        contadorpuntos.text = "" + puntos;
        contadortiempo.text = "" + tiempo.ToString("f0");

        tiempo = tiempo - 1 * Time.deltaTime;
    }
}
