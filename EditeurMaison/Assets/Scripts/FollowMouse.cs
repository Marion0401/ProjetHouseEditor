using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    

    private void OnMouseDrag()
    {
       
        gameObject.transform.position = floorPosition(getWorldPoint());
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
        return new Vector3(original.x,gameObject.transform.position.y,original.z);
    }




}
