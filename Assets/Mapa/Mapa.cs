using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapaObject
{
    public Image icon { get; set; }
    public GameObject owner { get; set; }
}

public class Mapa : MonoBehaviour
{
    public Transform playerPos;

    float mapScale = 2.0f;

    public static List<MapaObject> radObjects = new List<MapaObject>();

    public static void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        radObjects.Add(new MapaObject() { owner = o, icon = image });
    }

    public static void RemoveMapaObject(GameObject o)
    {
        List<MapaObject> newList = new List<MapaObject>();
        for (int i = 0; i < radObjects.Count; i++)
        {
            if (radObjects[i].owner == o)
            {
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
        DrawRadarDots();
    }

    public void ItemDropped(GameObject go)
    {
        Debug.Log("Item Dropped");
        RegisterRadarObject(go, go.GetComponent<Item>().icon);
    }

    public void ItemPickedUp(GameObject go)
    {
        RemoveMapaObject(go);
    }

}
