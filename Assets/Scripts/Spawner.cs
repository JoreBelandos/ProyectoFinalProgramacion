using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Creamos las variables necesarias 
    //Terreno donde van a spawnear los elementos
    public Terrain terreno;
    //Creamos los datos del terreno
    TerrainData terrainData;

    

    // Start is called before the first frame update
    void Start()
    {
        //Asignamos los datos del terreno que vamos a usar a la varible de datos
        terrainData = terreno.terrainData;
        //Iniciamos la corrutina
        StartCoroutine(CrearSphere());
    }

    //Creamos la corrutina
    public IEnumerator CrearSphere()
    {
        //Recorremos todos los elementos del pool y los mostramos cada 5 segundos
        for (int i = 0; i < Pool.singleton.pooledItems.Count; i++)
        {
            int x = (int)Random.Range(-terrainData.size.x / 3, terrainData.size.x/3);
            int z = (int)Random.Range(-terrainData.size.z / 3, terrainData.size.z/3);
            Vector3 pos = new Vector3(x, 0, z);
            pos.y = terreno.SampleHeight(pos);

            Pool.singleton.pooledItems[i].SetActive(true);
            Pool.singleton.pooledItems[i].transform.position = pos;

            yield return new WaitForSeconds(5);
 
        }
    }
}
