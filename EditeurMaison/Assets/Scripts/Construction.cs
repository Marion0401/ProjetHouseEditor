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
            pointer.transform.position = floorPosition(getWorldPoint());
            if (!GlobalVariables.isEnterButton)
            {
                if (Input.GetMouseButton(0))
                {
                    AddObject(GetPositionGrid());
                }
            }
            
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
    // Update is called once per frame



    public void AddObject(Vector3 position)
    {
        if (IsInGrid((int)position.x, (int)position.z))
        {
            if (grid[(int)position.x, (int)position.z] == null)
            {
                GameObject test = grid[(int)position.x, (int)position.z] = Instantiate(objToBuild, new Vector3(position.x, 0, position.z), Quaternion.identity);

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
