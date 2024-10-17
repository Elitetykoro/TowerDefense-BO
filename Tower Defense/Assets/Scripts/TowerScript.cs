using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private float bulletTime = 0;
    private Vector3 offset = new Vector3(0,0,90);
    private CircleCollider2D collision;
    private Animator animator;

    [SerializeField] private GameObject bullet;

    [Header("Tower Attributes")]
    [SerializeField] private DropDownSelector selectedTower = new DropDownSelector();
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

        if (bulletTime > bulletDelay && targets.Count != 0 && targets[0].gameObject != null && transform.childCount == 0)
        {
            if (selectedTower == DropDownSelector.IceTower)
            {
                offset = new Vector3(0, 0, 0);
                animator.Play("IceTowerAnimation");
            }
            else if (selectedTower == DropDownSelector.CanonTower)
            {
                animator.Play("CanonTowerAnimation");
                offset = new Vector3(0,0,0);
            }
            else if (selectedTower == DropDownSelector.BowTower)
            {
                animator.Play("BowTowerAnim");
            }
            Instantiate(bullet, transform.position, Quaternion.identity, transform);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, targets[0].transform.position - transform.position);
            transform.rotation *= Quaternion.Euler(offset);

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