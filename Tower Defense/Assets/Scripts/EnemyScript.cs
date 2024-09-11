using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<GameObject> Points;
    [SerializeField] GameObject FinishPoint;
    private int targetPoint = 0;
    private float speed = 1f;


    void Update()
    {
        EnemyMoveTowardPoint();
    }
    void EnemyMoveTowardPoint()
    {
        if (Points.Count >= targetPoint)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.identity, Points[targetPoint].transform.rotation, 1);
            transform.position = Vector3.MoveTowards(transform.position, Points[targetPoint + 1].transform.position, speed * Time.deltaTime);
            if (transform.position == Points[targetPoint + 1].transform.position)
            {
                Debug.Log("you have arrived");
                targetPoint++;
            }
            
        }
        else Debug.Log("Klaar");
        if (FinishPoint.transform.position == transform.position)
        {
            Destroy(gameObject);
        }
    }
}
