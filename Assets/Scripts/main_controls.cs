using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_controls : MonoBehaviour
{
    [SerializeField] List<GameObject> positions;
    [SerializeField] GameObject number_object;
    List<GameObject> unsorted_objects;
    public bool sort_objects = false;
    void Start()
    {
        this.unsorted_objects = new List<GameObject>();
        for (int i = 0; i < positions.Count; i++)
        {
            number_object.transform.position = positions[i].transform.position;
            Instantiate(number_object);
            this.unsorted_objects.Add(number_object);
        }

        int[] array = new int[] { 1, 10, 3, 5, 8, 3, 4, 9, 6};
        bubble_sort_test(array);
    }

    void Update()
    {
        if (sort_objects)
        {
            sort_objects_bubble_sort();
        }
    }

    private void sort_objects_bubble_sort() 
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
