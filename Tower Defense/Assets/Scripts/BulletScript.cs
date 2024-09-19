using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public EnemyScript enemyScript;
    private GameObject target = null;
    public float speed;
    public float bulletDamage;
    void Start()
    {
        target = GetComponentInParent<TowerPlacementScript>().targets[0].gameObject;
        bulletDamage = 10;
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