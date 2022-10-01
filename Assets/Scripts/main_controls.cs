using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_controls : MonoBehaviour
{
    [SerializeField] List<GameObject> positions;
    [SerializeField] GameObject number_object;
    [SerializeField] Material compare_material;
    [SerializeField] Material bigger_material;
    [SerializeField] Material normal_m;
    public List<GameObject> unsorted_objects;
    private Vector3 force_obj_down = new Vector3(0.0f, -15f, 0.0f);
    private GameObject temporary;
    public bool sort_objects = false;
    void Start()
    {
        this.unsorted_objects = new List<GameObject>();
        for (int i = 0; i < positions.Count; i++)
        {
            number_object.transform.position = positions[i].transform.position;
            temporary = Instantiate(number_object);
            unsorted_objects.Add(temporary);
            temporary.transform.SetParent(positions[i].transform);
        }


        sort();
        //sort_objects_bubble_sort();
        //for (int i = 0; i < unsorted_objects.Count; i++)
        //{
        //    Debug.Log(unsorted_objects[i].GetComponent<number_obj>().object_value);
        //}
    }

    void Update()
    {
 
    }

    private IEnumerator wait_for_a_bit() 
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(sort_objects_bubble_sort());

    }

    private void sort()
    {
        StartCoroutine(wait_for_a_bit());
    }

    private IEnumerator sort_objects_bubble_sort() 
    {
        GameObject temporary;
        Transform parent1;
        Transform parent2;
        int k = unsorted_objects.Count;
        bool sorted = false;

        while (k > 1 && !sorted)
        {
            sorted = true;
            for (int i = 0; i < k - 1; i++)
            {
                unsorted_objects[i].GetComponent<Renderer>().material = compare_material;
                unsorted_objects[i + 1].GetComponent<Renderer>().material = compare_material;
                yield return new WaitForSeconds(1f);
                if (unsorted_objects[i].GetComponent<number_obj>().object_value > 
                    unsorted_objects[i + 1].GetComponent<number_obj>().object_value) 
                {
                    unsorted_objects[i].GetComponent<Renderer>().material = bigger_material;
                    yield return new WaitForSeconds(1f);
                    sorted = false;
                    temporary = unsorted_objects[i + 1];
                    unsorted_objects[i + 1] = unsorted_objects[i];
                    unsorted_objects[i] = temporary;

                    parent1 = unsorted_objects[i].transform.parent;
                    parent2 = unsorted_objects[i + 1].transform.parent;

                    unsorted_objects[i].transform.position = parent2.position;
                    unsorted_objects[i + 1].transform.position = parent1.position;

                    unsorted_objects[i].gameObject.transform.SetParent(parent2);
                    unsorted_objects[i + 1].gameObject.transform.SetParent(parent1);

                    unsorted_objects[i].gameObject.GetComponent<Renderer>().material = normal_m;
                    yield return new WaitForSeconds(2f);
                }

                unsorted_objects[i].GetComponent<Renderer>().material = normal_m;
                unsorted_objects[i + 1].GetComponent<Renderer>().material = normal_m;
            }
        }
    }

    private void sort_objects_bubble_sort_2()
    {
        GameObject temporary;
        int k = unsorted_objects.Count;
        bool sorted = false;

        while (k > 1 && !sorted)
        {
            sorted = true;
            for (int i = 0; i < k - 1; i++)
            {
                if (unsorted_objects[i].GetComponent<number_obj>().object_value >
                    unsorted_objects[i + 1].GetComponent<number_obj>().object_value)
                {
                    sorted = false;
                    temporary = unsorted_objects[i + 1];
                    unsorted_objects[i + 1] = unsorted_objects[i];
                    unsorted_objects[i] = temporary;
                    
                }
            }
        }
    }




    private void replace_sorted_positions()
    {
        for (int i = 0; i < unsorted_objects.Count; i++)
        {
            unsorted_objects[i].transform.position = positions[i].transform.position;
        }
    }

    private void bubble_sort_test(int[] unsorted_list) 
    {
        bool sorted = false;
        int temporary;
        int k = unsorted_list.Length - 1;

        while (k > 1 && !sorted) 
        {
            sorted = true;
            for(int i = 0; i < unsorted_list.Length - 1; i++) 
            {
                if (unsorted_list[i] > unsorted_list[i + 1]) 
                {
                    sorted = false;
                    temporary = unsorted_list[i + 1];
                    unsorted_list[i + 1] = unsorted_list[i];
                    unsorted_list[i] = temporary;
                }
            }
            k--;
        }

        for (int i = 0; i < unsorted_list.Length - 1; i++)
        {
            Debug.Log(unsorted_list[i]);
        }
        
    }

}
