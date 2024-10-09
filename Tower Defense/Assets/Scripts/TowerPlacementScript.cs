using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerPlacementScript : MonoBehaviour
{
    public GameObject bowTower;
    public GameObject canonTower;
    public GameObject iceTower;
    private GameObject selectedTower;
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void BowTowerPlacement()
    {
        Instantiate(bowTower, transform.position, Quaternion.identity, transform);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Collider2D>().enabled = false;
    }
    public void IceTowerPlacement()
    {
        Instantiate(iceTower, transform.position, Quaternion.identity, transform);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Collider2D>().enabled = false;
    }
    public void CanonTowerPlacement()
    {
        Instantiate(canonTower, transform.position, Quaternion.identity, transform);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Collider2D>().enabled = false;
    }
}
