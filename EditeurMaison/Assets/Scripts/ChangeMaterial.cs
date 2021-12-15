using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial;
    
    public void changeMaterial()
    {
        foreach (GameObject objToChangeMaterial in GlobalVariables.listObjSelected)
        {
            objToChangeMaterial.GetComponent<Renderer>().material = newMaterial;
        }
        //GlobalVariables.objSelected.GetComponent<Renderer>().material = newMaterial; ;
        
    }
   
}
