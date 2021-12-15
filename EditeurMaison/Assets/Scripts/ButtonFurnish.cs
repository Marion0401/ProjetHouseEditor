using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFurnish : MonoBehaviour
{
    public GameObject obj;
    GameObject newGameObject;
    public float xCoor=10;
    public float zCoor = 10;
    public AudioSource sound;

    public void AppareanceFurnish()
    {
        newGameObject=Instantiate(obj, new Vector3(xCoor, 0, zCoor), Quaternion.identity);
        sound.Play();

    }
   
    
}
