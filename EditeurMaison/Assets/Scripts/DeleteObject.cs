using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteObject : MonoBehaviour //, IPointerDownHandler
{
    public GameObject buttonDelete;
    public void deleteObject()
    {
        Destroy(GlobalVariables.objSelected);
        GlobalVariables.objSelected = null;
        buttonDelete.SetActive(false);

    }

    
}
