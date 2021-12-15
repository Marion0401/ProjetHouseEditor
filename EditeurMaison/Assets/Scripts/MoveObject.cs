using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject objToMove in GlobalVariables.listObjSelected)
        {
            if(Input.GetKey(KeyCode.Z))
        {

                objToMove.transform.position = new Vector3(objToMove.transform.position.x, objToMove.transform.position.y, objToMove.transform.position.z - 0.1f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                objToMove.transform.position = new Vector3(objToMove.transform.position.x - 0.1f, objToMove.transform.position.y, objToMove.transform.position.z);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                objToMove.transform.position = new Vector3(objToMove.transform.position.x + 0.1f, objToMove.transform.position.y, objToMove.transform.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                objToMove.transform.position = new Vector3(objToMove.transform.position.x, objToMove.transform.position.y, objToMove.transform.position.z + 0.1f);
            }
        }
    }
}
