using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public List<GameObject> Points;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Points.Add(transform.GetChild(i).gameObject);
        }
    }

}
