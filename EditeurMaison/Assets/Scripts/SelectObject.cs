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

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    public void deleteObject()
    {
        Destroy(GlobalVariables.objSelected);
        GlobalVariables.objSelected = null;
        buttonDelete.SetActive(false);
        _isSelected = false;

    }

    void Unselect()
    {
        GlobalVariables.objSelected.GetComponent<Outline>().enabled = false;
        _isSelected = false;
        GlobalVariables.objSelected = null;
        buttonDelete.SetActive(false);

    }

    void Select(GameObject obj)
    {
        _isSelected = true;
        GlobalVariables.objSelected = obj;
        obj.GetComponent<Outline>().enabled = true;
        buttonDelete.SetActive(true);

    }

    // Update is called once per frame
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
                    if (_isSelected)
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
