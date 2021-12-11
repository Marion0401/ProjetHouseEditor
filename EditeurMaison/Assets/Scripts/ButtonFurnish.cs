using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFurnish : MonoBehaviour
{
    public GameObject obj;


    public void AppareanceFurnish()
    {
        Instantiate(obj, new Vector3(1, 0, 1), Quaternion.identity);
        

    }
   
    
}
