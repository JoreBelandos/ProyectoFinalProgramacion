using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] PlantData info;
    SetPlantInfo spi; 

    private void Start() 
    {
        spi = GameObject.FindGameObjectWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    private void OnMouseDown() 
    {
        spi.OpenPlantPanel();
        spi.plantName.text = info.Name;
        spi.threatLevel.text = info.Threat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = info.Icon;
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player" && info.Threat == PlantData.THREAT.High)
        {
        }
    }
}
