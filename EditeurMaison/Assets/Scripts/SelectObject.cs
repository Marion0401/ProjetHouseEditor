using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour
{
    public GameObject buttonDelete;
    private bool _isSelected = false;
    private string _selectableTag = "Selectable";
    private GameObject _obj;
    private bool _isEnterButton = false;
    public GameObject arrows;

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void TurnObjectToRight()
    {
        foreach (GameObject objToRotate in GlobalVariables.listObjSelected)
        {
            float newY = objToRotate.transform.rotation.y;
            objToRotate.transform.Rotate(0, newY + 45, 0);
        }

    }
    public void TurnObjectToLeft()
    {
        foreach (GameObject objToRotate in GlobalVariables.listObjSelected)
        {
            float newY = objToRotate.transform.rotation.y;
            objToRotate.transform.Rotate(0, newY - 45, 0);
        }
    }

    public void deleteObject()
    {

        Destroy(GlobalVariables.objSelected);
        GlobalVariables.objSelected = null;
        foreach (GameObject objToDelete in GlobalVariables.listObjSelected)
        {
            //GlobalVariables.listObjSelected.Remove(objToDelete);
            //GameObject temp = objToDelete;
            Destroy(objToDelete);
            
        }
        GlobalVariables.listObjSelected.Clear();

        foreach (GameObject objToDelete in GlobalVariables.listObjSelected)
        {
            //GlobalVariables.listObjSelected.Remove(objToDelete);
            //GameObject temp = objToDelete;
            Debug.Log(objToDelete);

        }



        buttonDelete.SetActive(false);
        _isSelected = false;
        arrows.SetActive(false);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Unselect()
    {
        //GlobalVariables.objSelected.GetComponent<Outline>().enabled = false;
        foreach (GameObject objToUnselect in GlobalVariables.listObjSelected)
        {
            objToUnselect.GetComponent<Outline>().enabled = false;
        }
        _isSelected = false;
        //GlobalVariables.objSelected = null;
        GlobalVariables.listObjSelected.Clear();
        buttonDelete.SetActive(false);
        arrows.SetActive(false);

    }

    void UnselectObj(GameObject obj)
    {
        GlobalVariables.listObjSelected.Remove(obj);
        obj.GetComponent<Outline>().enabled = false;
    }

    void Select(GameObject obj)
    {
        _isSelected = true;
        //GlobalVariables.objSelected = obj;
        GlobalVariables.listObjSelected.Add(obj);
        obj.GetComponent<Outline>().enabled = true;
        buttonDelete.SetActive(true);
        arrows.SetActive(true);

    }

    bool objInList(GameObject obj)
    {
        foreach (GameObject objToVerify in GlobalVariables.listObjSelected)
        {
            if (obj == objToVerify)
            {
                return true;
            }

        }
        return false;
    }

    void Update()
    {
        _isEnterButton = IsMouseOverUI();
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _obj = hit.transform.gameObject;


                if (_obj.CompareTag(_selectableTag))
                {
                    


                    if (_isSelected && Input.GetKey(KeyCode.LeftControl))
                    {
                        Select(_obj);
                    }
                    else if (_isSelected)
                    {
                        Unselect();
                    }

                    Select(_obj);


                }
                else
                {
                    if (_isSelected)
                    {
                        if (!_isEnterButton)
                        {
                            Unselect();
                        }

                    }
                }

            }


        }

    }
}
