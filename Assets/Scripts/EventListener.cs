using UnityEngine;
using UnityEngine.Events;

//Creamos la clase publica
[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventListener : MonoBehaviour
{
    //Creamos las variables
    //Creamos el evento que vamos a usar
    public Event gEvent;
    //Asignamos la respuesta del evento
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    //Registramos este evento
    private void OnEnable()
    {
        gEvent.Register(this);
    }

    //Quitamos del registro este evento
    private void OnDisable()
    {
        gEvent.Unregister(this);
    }

    //Activamos el evento para que ocurra
    public void OnEventOccurs(GameObject go)
    {
        response.Invoke(go);
    }
}
