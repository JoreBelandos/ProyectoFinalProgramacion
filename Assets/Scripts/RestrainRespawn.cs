using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrainRespawn : MonoBehaviour
{
    //Comprobamos si las esferas salen del espacio deseado
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SpherePrefab")
        {
            //Reposicionamos la esfera
            int x = Random.Range(-50, 50);
            int z = Random.Range(-50, 50);
            Vector3 pos = new Vector3(x, 0, z);
            pos.y = other.transform.position.y;
            other.transform.position = pos;

        }
    }
}
