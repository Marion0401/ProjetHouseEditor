using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial;
    public GameObject materialToChange;
    
    public void changeMaterial()
    {
        materialToChange.GetComponent <Renderer>().material= newMaterial;
    }
   
}
