using System.Collections.Generic;
using UnityEngine;

public class towerListScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> towerList;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            towerList.Add(transform.GetChild(i).gameObject);
        }
    }
}
