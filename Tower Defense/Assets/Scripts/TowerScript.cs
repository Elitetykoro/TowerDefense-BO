using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private float bulletTime = 0;
    private Vector3 offset = new Vector3(0,0,90);
    private CircleCollider2D collision;
    private Animator animator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private DropDownSelector selectedTower = new DropDownSelector();

    [Header("Tower Attributes")]
    [SerializeField] private float bulletDelay;
    [SerializeField] private float range;

    [Header("Bullet Attributes")]
    public float bulletSpeed;
    public float bulletDamage;

    public List<GameObject> targets;
    void Start()
    {
        collision = GetComponent<CircleCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        bulletTime += Time.deltaTime;
        collision.radius = range;

        for (int i = 0; i < targets.Count; i++) targets[i].tag = "target"; // Add tag to target

        

        if (bulletTime > bulletDelay && targets.Count != 0 && targets[0].gameObject != null)
        {
            if (selectedTower == DropDownSelector.IceTower) animator.Play("IceTowerAnimation");
            else if (selectedTower == DropDownSelector.CanonTower)
            {
                offset = new Vector3(0, 0, 0);
                animator.Play("CanonTowerAnimation");
            }
            else if (selectedTower == DropDownSelector.BowTower)
            {
                animator.Play("BowTowerAnim");
            }
            Instantiate(bullet, transform.position, Quaternion.identity, transform);
            if(selectedTower != DropDownSelector.IceTower) transform.rotation = Quaternion.LookRotation(Vector3.forward, targets[0].transform.position - transform.position);
            else if (selectedTower != DropDownSelector.IceTower) transform.rotation *= Quaternion.Euler(offset);
            
            bulletTime = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            targets.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            targets.Remove(collision.gameObject);
        }
    }
}
public enum DropDownSelector
{
    IceTower,
    BowTower,
    CanonTower
};