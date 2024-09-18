using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //private TowerPlacementScript towerPlacementScript;
    private EnemyScript enemyScript;
    public GameObject target;
    public float speed;
    public float bulletDamage;
    void Start()
    {
        //target = towerPlacementScript.targets;
        target = GetComponentInParent<TowerPlacementScript>().targets[0].gameObject;

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyScript>().health -= bulletDamage;
        Destroy(gameObject);
    }
}
