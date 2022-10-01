using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection_sort : MonoBehaviour
{
    public IEnumerator selection_sort_test
        (
        List<GameObject> unsorted_list,
        Material green_material,
        Material white_material,
        Material red_material
        )
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
                yield return new WaitForSeconds(0.5f);
                unsorted_list[j].GetComponent<Renderer>().material = red_material;
                if (unsorted_list[j].GetComponent<number_obj>().object_value.
                    CompareTo(min_value.GetComponent<number_obj>().object_value) < 0)
                {
                    // new smallest value
                    yield return new WaitForSeconds(0.5f);
                    min_value.GetComponent<Renderer>().material = white_material;
                    minIndex = j;
                    min_value = unsorted_list[j];
                    min_value.GetComponent<Renderer>().material = green_material;
                    continue;
                }
                yield return new WaitForSeconds(0.5f);
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
            yield return new WaitForSeconds(1f);
        }


        // Making all of the elements green after completion
        for (int i = 0; i < unsorted_list.Count; i++)
        {
            yield return new WaitForSeconds(0.3f);
            unsorted_list[i].GetComponent<Renderer>().material = green_material;
        }

    }
}
