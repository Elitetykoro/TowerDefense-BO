using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> Points;
    private int targetPoint = 0;

    void Start()
    {
        
    }

    void Update()
    {
        EnemyMoveTowardPoint();
        transform.rotation = Quaternion.Lerp(Quaternion.identity,Points[targetPoint].transform.rotation,1);
        //if (transform.position == Points[targetPoint + 1].transform.position && targetPoint <= Points.Count)
        //{
        //    Debug.Log("you have arrived");
        //    targetPoint++;
        //}
        //else if (targetPoint >= Points.Count) Debug.Log("You have reached the end");
    }
    void EnemyMoveTowardPoint()
    {
        if (Points[targetPoint].transform.rotation ==  Quaternion.Euler(0,0,-90))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else if (Points[targetPoint].transform.rotation == Quaternion.Euler(0, 0, 180))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        else if (Points[targetPoint].transform.rotation == Quaternion.Euler(0, 0, 90))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        else if (Points[targetPoint].transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            transform.position += Vector3.up * Time.deltaTime;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you have arrived");
        targetPoint++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("you have arrived");
        targetPoint++;
    }
}
