using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private float bulletTime = 0;
    private Vector3 offset = new Vector3(0,0,90);
    private CircleCollider2D collision;
    private Animator animator;
    [SerializeField] private AudioClip bowShootSFX;
    [SerializeField] private AudioClip iceShootSFX;
    [SerializeField] private AudioClip canonShootSFX;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
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
                audioSource.clip = iceShootSFX;
                audioSource.Play();
            }
            else if (selectedTower == DropDownSelector.CanonTower)
            {
                animator.Play("CanonTowerAnimation");
                offset = new Vector3(0,0,0);
                audioSource.clip = canonShootSFX;
                audioSource.Play();
            }
            else if (selectedTower == DropDownSelector.BowTower)
            {
                animator.Play("BowTowerAnim");
                audioSource.clip = bowShootSFX;
                audioSource.Play();
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