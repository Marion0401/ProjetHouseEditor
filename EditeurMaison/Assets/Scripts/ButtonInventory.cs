using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject inventoryGeneral;
    public GameObject buttonBack; 
    public void goodInventory()
    {
        inventoryGeneral.SetActive(false);
        inventory.SetActive(true);
        buttonBack.SetActive(true);
    }
}
