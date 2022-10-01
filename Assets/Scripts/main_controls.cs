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
        selection_sort(unsorted_objects);
    }

    void Update()
    {

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

    #region Bubble Sort
    private IEnumerator wait_bubble_sort(List<GameObject> unsorted_objects)
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(
            bubble_sort_script.sort_objects_bubble_sort(
                unsorted_objects, red_material, white_material, green_material));

    }

    private void bubble_sort(List<GameObject> unsorted_objects)
    {
        StartCoroutine(wait_bubble_sort(unsorted_objects));
    }

    #endregion

    #region Selection Sort
    private void selection_sort(List<GameObject> unsorted_objects)
    {
        StartCoroutine(selection_sort_test(unsorted_objects));
    }

    private IEnumerator selection_sort_test(List<GameObject> unsorted_list)
    {
        GameObject min_value;
        GameObject temp;
        Transform parent1;
        Transform parent2;
        for (int i = 0; i < unsorted_list.Count; i++)
        {
            int minIndex = i;
            yield return new WaitForSeconds(1f);
            min_value = unsorted_list[i];
            min_value.GetComponent<Renderer>().material = green_material; // First element red;
            for (int j = i + 1; j < unsorted_list.Count; j++)
            {
                yield return new WaitForSeconds(0.7f);
                unsorted_list[j].GetComponent<Renderer>().material = red_material;
                if (unsorted_list[j].GetComponent<number_obj>().object_value.
                    CompareTo(min_value.GetComponent<number_obj>().object_value) < 0)
                {
                    // new smallest value
                    yield return new WaitForSeconds(0.7f);
                    min_value.GetComponent<Renderer>().material = white_material;
                    minIndex = j;
                    min_value = unsorted_list[j];
                    min_value.GetComponent<Renderer>().material = green_material;
                    continue;
                }
                yield return new WaitForSeconds(0.7f);
                unsorted_list[j].GetComponent<Renderer>().material = white_material;
            }

            temp = unsorted_list[i];
            unsorted_list[i] = unsorted_list[minIndex];
            unsorted_list[minIndex] = temp;



            parent1 = temp.transform.parent;
            parent2 = unsorted_list[i].transform.parent;

            unsorted_list[i].transform.position = parent1.position;
            temp.transform.position = parent2.position;
            

            temp.gameObject.transform.SetParent(parent2);
            unsorted_list[i].gameObject.transform.SetParent(parent1);

            unsorted_list[i].gameObject.GetComponent<Renderer>().material = white_material;
            unsorted_list[minIndex].gameObject.GetComponent<Renderer>().material = white_material;
            yield return new WaitForSeconds(2f);



        }


        // Making all of the elements green after completion
        for (int i = 0; i < unsorted_list.Count; i++)
        {
            yield return new WaitForSeconds(0.3f);
            unsorted_list[i].GetComponent<Renderer>().material = green_material;
        }

    }

    #endregion


}
