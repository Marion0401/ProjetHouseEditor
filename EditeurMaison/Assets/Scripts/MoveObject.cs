using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public FollowMouse mouse;
    private void OnMouseDrag()
    {

        gameObject.transform.position = mouse.floorPosition(mouse.getWorldPoint());
    }

}
