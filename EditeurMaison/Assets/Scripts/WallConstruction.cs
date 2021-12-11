using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConstruction : MonoBehaviour
{
    bool creating;

    public GameObject pointer;
    public GameObject polePrefab;
    GameObject lastPole;
    public GameObject wallPrefab;
    bool _onConstruction = false;
    public GameObject canvasWallConstruction;
    public GameObject canvasGeneral;
    

    private void Start()
    {
        
    }
    public Vector3 getWorldPoint()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    

    public Vector3 floorPosition(Vector3 original)
    {
        Vector3 snapped;
        snapped.x = Mathf.Floor(original.x+0.1f);
        snapped.y = Mathf.Floor(original.y+0.1f);
        snapped.z = Mathf.Floor(original.z+0.1f);

        return snapped;
    }

    public void onConstruction()
    {
       
        _onConstruction = true;
        pointer.SetActive(true);
        canvasWallConstruction.SetActive(true);
        canvasGeneral.SetActive(false);
        
    }

    public void offConstruction()
    {
        _onConstruction = false;
        pointer.SetActive(false);
        canvasWallConstruction.SetActive(false);
        canvasGeneral.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_onConstruction)
        {
            
            pointer.transform.position = floorPosition(getWorldPoint());

            if (!GlobalVariables.isEnterButton)
            {
                Debug.Log(GlobalVariables.isEnterButton);
                if (Input.GetMouseButtonDown(0))
                {
                    startWall();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    endWall();

                }
                else
                {
                    if (creating)
                    {
                        updateWall();
                    }
                }

            }
            
        }

    }
        

    private void startWall()
    {
        creating = true;
        Vector3 startPosition = getWorldPoint();
        startPosition = floorPosition(startPosition);
        GameObject startPole = Instantiate(polePrefab, new Vector3 (startPosition.x,0,startPosition.z), Quaternion.identity);
        startPole.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        lastPole = startPole;
        

    }   

    void endWall()
    {
        creating = false;

       
    }

    void updateWall()
    {

        Vector3 current = getWorldPoint();
        current = floorPosition(current);
        current = new Vector3(current.x, current.y + 0.3f, current.z);
        if (!current.Equals(lastPole.transform.position))
        {
            createWallSegment(current);
        }
    }
    void createWallSegment(Vector3 current)
    {
        GameObject newPole = Instantiate(polePrefab, new Vector3 (current.x,0,current.z), Quaternion.identity);
        Vector3 middle = Vector3.Lerp(newPole.transform.position, lastPole.transform.position, 0.5f);
        GameObject newWall = Instantiate(wallPrefab, new Vector3 (middle.x,0,middle.z), Quaternion.identity);
        newWall.transform.LookAt(lastPole.transform);
        lastPole = newPole;
    }


}
