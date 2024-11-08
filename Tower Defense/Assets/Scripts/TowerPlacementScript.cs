using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPlacementScript : MonoBehaviour
{
    private List<GameObject> towerGameobjectList;
    [SerializeField] private MoneyManagerScript moneyManager;

    [SerializeField] private GameObject bowTower;
    [SerializeField] private GameObject canonTower;
    [SerializeField] private GameObject iceTower;
    [SerializeField] private Sprite canonBulletSprite;
    [SerializeField] private Sprite bowBulletSprite;
    [SerializeField] private Sprite iceBulletSprite;
    public Sprite currentBulletType;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        towerGameobjectList = transform.parent.GetComponent<towerListScript>().towerList;
    }
    private void OnMouseDown()
    {
        for (int i = 0; i < towerGameobjectList.Count; i++) towerGameobjectList[i].transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void BowTowerPlacement()
    {
        TowerPlace(bowTower, bowBulletSprite, 100);
    }
    public void IceTowerPlacement()
    {
        TowerPlace(iceTower, iceBulletSprite, 110);
    }
    public void CanonTowerPlacement()
    {
        TowerPlace(canonTower, canonBulletSprite, 150);
    }
    private void TowerPlace(GameObject towerType, Sprite bulletType, float cost)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        if (moneyManager.money >= cost)
        {
            transform.GetComponent<Collider2D>().enabled = false;
            Instantiate(towerType, transform.position, Quaternion.identity, transform);
            moneyManager.money -= cost;
            currentBulletType = bulletType;
        }
        else Camera.main.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().alpha = 255;

    }
}
