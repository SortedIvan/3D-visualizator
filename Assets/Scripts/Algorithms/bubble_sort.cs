using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_sort : MonoBehaviour
{
    public IEnumerator sort_objects_bubble_sort
        (
        List<GameObject> unsorted_objects,
        Material red_material,
        Material white_material,
        Material green_material
        )
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
                unsorted_objects[i].GetComponent<Renderer>().material = red_material;
                unsorted_objects[i + 1].GetComponent<Renderer>().material = red_material;
                yield return new WaitForSeconds(1f); // 1
                if (unsorted_objects[i].GetComponent<number_obj>().object_value >
                    unsorted_objects[i + 1].GetComponent<number_obj>().object_value)
                {

                    unsorted_objects[i].GetComponent<Renderer>().material = green_material;
                    yield return new WaitForSeconds(1f); // 1
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

                    unsorted_objects[i].gameObject.GetComponent<Renderer>().material = white_material;
                    yield return new WaitForSeconds(2f); // 2
                }

                unsorted_objects[i].GetComponent<Renderer>().material = white_material;
                unsorted_objects[i + 1].GetComponent<Renderer>().material = white_material;
            }
        }


        // Color all of the objects once sorting is complete
        for (int i = 0; i < unsorted_objects.Count; i++)
        {
            unsorted_objects[i].GetComponent<Renderer>().material = green_material;
        }
    }
}
