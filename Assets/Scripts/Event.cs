using System.Collections.Generic;
using UnityEngine;

//Creamos un nuevo scriptableobject dentro del menu
[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 52)]

//Creamos el scriptable object
public class Event : ScriptableObject
{
    //Creamos una nueva lista de eventos
    private List<EventListener> elisteners = new List<EventListener>();

    //Creamos la funcion para añadir nuevos eventos
    public void Register(EventListener listener)
    {
        elisteners.Add(listener);
    }

    //Creamos la funcion para eliminar eventos de la lista
    public void Unregister(EventListener listener)
    {
        elisteners.Remove(listener);
    }

    //Creamos la funcion para ejecutar los eventos en la lista
    public void Occurred(GameObject go)
    {
        //Recorremos la lista de eventos y los ejecutamos
        for (int i = 0; i < elisteners.Count; i++)
        {
            elisteners[i].OnEventOccurs(go);
        }
    }
}
