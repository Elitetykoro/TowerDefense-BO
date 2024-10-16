using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulletScript : MonoBehaviour
{
    public GameObject target;
    private Transform Parent;
    public float speed;
    public float damage;
    private Transform lastEnemyPosition;
    [SerializeField] private Sprite Arrow;
    private TowerScript tower;
    
    void Start()
    {
        target = gameObject;
        Parent = transform.parent.gameObject.transform;
        target = Parent.GetComponent<TowerScript>().targets[0].gameObject;
        
        speed = Parent.GetComponent<TowerScript>().bulletSpeed;
        damage = Parent.GetComponent<TowerScript>().bulletDamage;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position);
        transform.rotation *= Quaternion.Euler(new Vector3(0,0,90));
        lastEnemyPosition = target.transform;
        if (target == null)
        {
            transform.position = Vector3.MoveTowards(transform.position, lastEnemyPosition.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, lastEnemyPosition.position) <= 0.1f) Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tower = Parent.GetComponent<TowerScript>(); 
        if (target.GetComponent<EnemyScript>()?.health < 0)
        {
            Destroy(gameObject);
            tower.targets.Remove(collision.gameObject);
        }
        collision.GetComponent<EnemyScript>().health -= damage;
        Destroy(gameObject);
    }
}