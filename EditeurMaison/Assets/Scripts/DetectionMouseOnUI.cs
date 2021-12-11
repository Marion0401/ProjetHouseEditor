using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectionMouseOnUI : MonoBehaviour
{
    private void Update()
    {
        GlobalVariables.isEnterButton = IsMouseOverUI();
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
