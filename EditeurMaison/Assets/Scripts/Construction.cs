using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public int height = 100;
    public int width;
    public GameObject[,] grid;
    public GameObject objToBuild;
    bool _onConstruction = false;
    public GameObject canvasConstruction;
    public GameObject canvasGeneral;
    public GameObject pointer;
    public bool wallConstruction;
    public float positionGameX;
    public float positionGameZ;
    public float positionGameRotationX;
    public float positionGameRotationZ;
    bool rotationActive=false;
    public Color greenColor;

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[height, width];

        //for (int y = 0; y < height; y++)
        //{
        //    for (int x = 0; x < width; x++)
        //    {

        //        grid[x, y] = Instantiate(objToBuild, new Vector3(x, 0, y), Quaternion.identity);
        //    }
        //}
    }
    void Update()
    {
        
        if (_onConstruction)
        {
            if (wallConstruction)
            {
                pointer.transform.position = floorPositionWall(getWorldPoint());
                ChangeColorPointer(pointer.transform.position.x, pointer.transform.position.z);
            }
            
            else
            {
                pointer.transform.position = floorPosition(getWorldPoint());
                ChangeColorPointer(pointer.transform.position.x, pointer.transform.position.z);
            }
            
            
            if (!GlobalVariables.isEnterButton)
            {
                if (Input.GetMouseButton(0))
                {
                    AddObject(GetPositionGrid());
                }
               if (Input.GetMouseButtonDown(1))
                {
                    
                    rotationActive =!rotationActive;
                    

                    if (rotationActive)
                    {
                        
                        
                        pointer.transform.Rotate(0f, -90f, 0f);

                    }
                    else
                    {
                       
                        pointer.transform.Rotate(0f, 90f, 0f);
                    }
                }
            }
            
        }


    }

    void ChangeColorPointer(float x,float z)
    {
        if (!IsInGrid(pointer.transform.position))
        {
            pointer.GetComponent<Renderer>().material.color = Color.red;

        }
        else if(grid[(int)x, (int)z] == null)
        {
            pointer.GetComponent<Renderer>().material.color = greenColor;
        }
        else
        {
            pointer.GetComponent<Renderer>().material.color = Color.red;
        }

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
        snapped.x = Mathf.Floor(original.x + 0.1f);
        snapped.y = Mathf.Floor(original.y + 0.1f);
        snapped.z = Mathf.Floor(original.z + 0.1f);
        return snapped;
    }

    public Vector3 floorPositionWall(Vector3 original)
    {
        Vector3 snapped;
        snapped.x = Mathf.Floor(original.x + 0.1f);
        snapped.y = Mathf.Floor(original.y + 0.1f);
        snapped.z = Mathf.Floor(original.z + 0.1f);
        snapped.z += 0.3f;
        
        if (rotationActive)
        {
            snapped.x += 0.4f;
            snapped.z -= 0.5f;
        }
        return snapped;
    }
    



    public void AddObject(Vector3 position)
    {
        if (IsInGrid((int)position.x, (int)position.z))
        {
            if (grid[(int)position.x, (int)position.z] == null)
            {
                GameObject test = null;
                if (rotationActive)
                {
                    test = grid[(int)position.x, (int)position.z] = Instantiate(objToBuild, new Vector3(position.x + positionGameRotationX, 0, position.z + positionGameRotationZ), Quaternion.Euler(0f,90f,0));
                    
                }
                else
                {
                    test = grid[(int)position.x, (int)position.z] = Instantiate(objToBuild, new Vector3(position.x + positionGameX, 0, position.z + positionGameZ), Quaternion.Euler(0f,0f,0f));
                    
                }
                MainEditor.Instance.ListObjects.Add(test);

            }
            
        }
        

    }

    private Vector3 GetPositionGrid()
    {
        Vector3 position = getWorldPoint();
        position = floorPosition(position);
        return position;
    }

    public bool IsInGrid(int x, int y)
    {
        return (x >= 0 && x < height && y >= 0 && y < width);
    }
    public bool IsInGrid(Vector3 target)
    {
        return (target.x >= 0 && target.x < height && target.z >= 0 && target.z < width);
    }

    public void onConstruction()
    {

        _onConstruction = true;
        pointer.SetActive(true);
        canvasConstruction.SetActive(true);
        canvasGeneral.SetActive(false);

    }

    public void offConstruction()
    {
        _onConstruction = false;
        pointer.SetActive(false);
        canvasConstruction.SetActive(false);
        canvasGeneral.SetActive(true);
    }
}
