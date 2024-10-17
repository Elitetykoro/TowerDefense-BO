using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    [Header("Points")]
    public List<GameObject> points;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) points.Add(transform.GetChild(i).gameObject);
    }
}
