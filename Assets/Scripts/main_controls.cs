using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_controls : MonoBehaviour
{
    [SerializeField] List<GameObject> positions;
    [SerializeField] GameObject number_object;
    void Start()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            number_object.transform.position = positions[i].transform.position;
            Instantiate(number_object);
        }
    }

    void Update()
    {
        
    }
}
