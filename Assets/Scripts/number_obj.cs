using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_obj : MonoBehaviour
{

    // Generating numbers between 1 and 30
    public int object_value;
    public Vector3 object_pos;


    void Start()
    {
        this.object_value = Random.Range(1, 20);    
    }

    void Update()
    {
        
    }
}
