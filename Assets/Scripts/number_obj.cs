using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_obj : MonoBehaviour
{
    // Generating numbers between 1 and 30
    public int object_value;
    public Vector3 object_pos;
    public Vector3 initial_obj_scale;

    void Start()
    {

    }

    private void Awake()
    {
        this.object_value = Random.Range(1, 20);
        gameObject.name = object_value.ToString();
        this.initial_obj_scale = gameObject.transform.localScale;
        this.initial_obj_scale.y = object_value * 0.5f;
        this.gameObject.transform.localScale = initial_obj_scale;
    }

    public int get_obj_value()
    {
        return this.object_value;
    }

    void Update()
    {
        
    }
}
