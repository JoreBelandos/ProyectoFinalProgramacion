using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapaObject
{
    //Variable para obtener el icono del elemento
    public Image icon { get; set; }
    //Variable para obtener el gameobject del elemento
    public GameObject owner { get; set; }
}

public class Mapa : MonoBehaviour
{
    //Variable para la posicion del jugador
    public Transform playerPos;
    //Variable para el tamaño del mapa
    float mapScale = 2.0f;
    //Creamos la lista de elementos que van a aparecer en el mapa
    public static List<MapaObject> radObjects = new List<MapaObject>();

    public static void RegisterRadarObject(GameObject o, Image i)
    {
        //Registramos el objeto en la lista y lo instanciamos
        Image image = Instantiate(i);
        radObjects.Add(new MapaObject() { owner = o, icon = image });
    }

    public static void RemoveMapaObject(GameObject o)
    {
        //Recorremos la lista de objetos
        List<MapaObject> newList = new List<MapaObject>();
        for (int i = 0; i < radObjects.Count; i++)
        {
            if (radObjects[i].owner == o)
            {
                //Eliminamos el objeto deseado de la lista
                Destroy(radObjects[i].icon);
                continue;
            }
            else
                newList.Add(radObjects[i]);
        }

        radObjects.RemoveRange(0, radObjects.Count);
        radObjects.AddRange(newList);
    }

    void DrawRadarDots()
    {
        foreach (MapaObject ro in radObjects)
        {
            //Pintamos los objetos de la lista en el mapa
            Vector3 radarPos = (ro.owner.transform.position - playerPos.position);
            float distToObject = Vector3.Distance(playerPos.position, ro.owner.transform.position) * mapScale;
            float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

            ro.icon.transform.SetParent(this.transform);
            RectTransform rt = this.GetComponent<RectTransform>();
            Debug.Log(rt.pivot);
            ro.icon.transform.position = new Vector3(radarPos.x + rt.pivot.x, radarPos.z + rt.pivot.y, 0) + this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la funcion para pintar los objetos
        DrawRadarDots();
    }

    //Ejecutamos la funcion para añadir el objeto
    public void ItemDropped(GameObject go)
    {
        Debug.Log("Item Dropped");
        RegisterRadarObject(go, go.GetComponent<Item>().icon);
    }

    //Ejecutamos la funcion de eliminar el objeto 
    public void ItemPickedUp(GameObject go)
    {
        RemoveMapaObject(go);
    }

}
