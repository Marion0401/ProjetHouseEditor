using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEditor : MonoBehaviour
{
    public List<GameObject> ListObjects = new List<GameObject>();
    public static MainEditor Instance;
    public List<GameObject> ListAllObjects = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
