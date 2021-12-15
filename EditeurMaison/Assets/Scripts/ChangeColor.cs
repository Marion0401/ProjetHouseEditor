using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeColor : MonoBehaviour
{
    public InputField rInput;
    public InputField gInput;
    public InputField bInput;

    public Button buttonValidate;

    public GameObject canvas;
    Color newColor; 
    float r;
    float g;
    float b;
    
    public void closeCanvas()
    {
        canvas.SetActive(false);
    }

    public void openCanvas()
    {
        canvas.SetActive(true);
    }

    void Start()
    {
        buttonValidate.onClick.AddListener(changeColorMaterial);
    }

    public void changeColorMaterial()
    {
        r = float.Parse(rInput.text.Replace('.',','));
        g = float.Parse(gInput.text.Replace('.', ','));
        b = float.Parse(bInput.text.Replace('.', ','));
        
       
        newColor = new Color(r, g, b, 1);

        foreach (GameObject objToChangeColor in GlobalVariables.listObjSelected)
        {
            objToChangeColor.GetComponent<Renderer>().material.color = newColor;
        }
        //GlobalVariables.objSelected.GetComponent<Renderer>().material.color= newColor;
    }

    
}
