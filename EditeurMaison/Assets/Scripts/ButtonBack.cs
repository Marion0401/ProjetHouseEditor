using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
   public GameObject currentInventory;
   public GameObject previousInventory;
    public GameObject buttonBack; 
   public void Back()
    {
        currentInventory.SetActive(false);
        previousInventory.SetActive(true);
        buttonBack.SetActive(false);

    }
}
