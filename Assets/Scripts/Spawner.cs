using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public Terrain terreno;
    TerrainData terrainData;

    

    // Start is called before the first frame update
    void Start()
    {
        terrainData = terreno.terrainData;
        //InvokeRepeating("CreateSphere", 1, 1);
        StartCoroutine(CrearSphere());
    }

    void CreateSphere()
    {
        GameObject a = Pool.singleton.Get("SpherePrefab");
        //Si el objeto que he recibido no está vacío(osea que se puede usar)
        if (a != null)
        {       
            int x = Random.Range(-50, 50);
            int z = Random.Range(-50, 50);
            Vector3 pos = new Vector3(x, 0, z);
            pos.y = terreno.SampleHeight(pos)-0.5f;
            GameObject sphere = Instantiate(spherePrefab, pos, Quaternion.identity);
            a.SetActive(true);
        }


    }

    public IEnumerator CrearSphere()
    {
        for (int i = 0; i < Pool.singleton.pooledItems.Count; i++)
        {
            int x = (int)Random.Range(-terrainData.size.x / 2, terrainData.size.x/2);
            int z = (int)Random.Range(-terrainData.size.z / 2, terrainData.size.z/2);
            Vector3 pos = new Vector3(x, 0, z);
            pos.y = terreno.SampleHeight(pos);

            Pool.singleton.pooledItems[i].SetActive(true);
            Pool.singleton.pooledItems[i].transform.position = pos;

            yield return new WaitForSeconds(5);
 
        }
    }
}
