using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantdata", menuName = "Plant Data", order = 51)]
public class PlantData : ScriptableObject
{
    public enum THREAT { None, Low, Moderate, High}

    [SerializeField]
    string _plantName;
    [SerializeField]
    THREAT _plantThreat;
    [SerializeField]
    Texture _icon;
    
    //Constructors
    public string Name {get {return _plantName;} }
    public THREAT Threat {get {return _plantThreat;} }
    public Texture Icon {get {return _icon;} }

}
