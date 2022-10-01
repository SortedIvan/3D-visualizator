using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_controls : MonoBehaviour
{
    [Header("Positions, objects & materials")]
    [SerializeField] List<GameObject> positions;
    [SerializeField] GameObject number_object;
    [SerializeField] Material red_material;
    [SerializeField] Material green_material;
    [SerializeField] Material white_material;

    [SerializeField] float solve_time = 2f;
    public List<GameObject> unsorted_objects;

    [Header("Algorithm script references")]
    [SerializeField] GameObject scripts_holder;
    private bubble_sort bubble_sort_script;


    private GameObject temporary;
     
    

    void Start()
    {
        bubble_sort_script = scripts_holder.GetComponent<bubble_sort>();


        this.unsorted_objects = new List<GameObject>();

        // Populate the list with objects and parent them to the positions
        populate_list_obj();

        // Bubble sort
        //bubble_sort(unsorted_objects);


        // Selection sort
        selection_sort_test(unsorted_objects);
    }

    void Update()
    {
        
    }

    private IEnumerator wait_bubble_sort(List<GameObject> unsorted_objects) 
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(
            bubble_sort_script.sort_objects_bubble_sort(
                unsorted_objects, red_material,white_material,green_material));

    }

    private void bubble_sort(List<GameObject> unsorted_objects)
    {
        StartCoroutine(wait_bubble_sort(unsorted_objects));
    }

    private void populate_list_obj()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            number_object.transform.position = positions[i].transform.position;
            temporary = Instantiate(number_object);
            unsorted_objects.Add(temporary);
            temporary.transform.SetParent(positions[i].transform);
        }

    }


    private IEnumerator selection_sort_test(List<GameObject> unsorted_list)
    {
        GameObject min_value;
        GameObject temp;
        for(int i = 0; i < unsorted_list.Count; i++) 
        {
            int minIndex = i;
            unsorted_objects[minIndex].GetComponent<Renderer>().material = red_material;
            yield return new WaitForSeconds(1f);
            min_value = unsorted_list[i];
            for (int j = i + 1; j < unsorted_list.Count; j++)
            {
                unsorted_objects[j].GetComponent<Renderer>().material = red_material;
                if (unsorted_list[j].GetComponent<number_obj>().object_value.
                    CompareTo(min_value.GetComponent<number_obj>().object_value) < 0)
                {
                    // new smallest value
                    unsorted_objects[j].GetComponent<Renderer>().material = green_material;
                    minIndex = j;
                    min_value = unsorted_list[j];



                }
            }

            temp = unsorted_list[i];
            unsorted_list[i] = unsorted_list[minIndex];
            unsorted_list[minIndex] = temp;
        }

    }


}
