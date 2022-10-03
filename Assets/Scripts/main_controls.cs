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
    private selection_sort selection_sort_script;


    private GameObject temporary;



    void Start()
    {
        // Assigning script references
        bubble_sort_script = scripts_holder.GetComponent<bubble_sort>();
        selection_sort_script = scripts_holder.GetComponent<selection_sort>();

        //Create and populate the list with objects and parent them to the positions
        this.unsorted_objects = new List<GameObject>();
        populate_list_obj();

        //bubble_sort(unsorted_objects);
        start_selection_sort(unsorted_objects);
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
    private IEnumerator selection_sort(List<GameObject> unsorted_objects)
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(
            selection_sort_script.selection_sort_test(
                unsorted_objects, green_material, white_material, red_material)
        );
    }

    private void start_selection_sort(List<GameObject> unsorted_objects)
    {
        StartCoroutine(selection_sort(unsorted_objects));
    }

    #endregion


}
