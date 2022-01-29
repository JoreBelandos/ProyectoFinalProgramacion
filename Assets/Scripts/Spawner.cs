using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public Terrain terreno;
    TerrainData terrainData;

    // Start is called before the first frame update
    void Start()
    {
        terrainData = terreno.terrainData;
        InvokeRepeating("CreateSphere", 1, 1);
    }

    void CreateSphere()
    {
        int x = (int)Random.Range(0, terrainData.size.x);
        int z = (int)Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terreno.SampleHeight(pos) + 1;
        GameObject egg = Instantiate(eggPrefab, pos, Quaternion.identity);
    }


}
