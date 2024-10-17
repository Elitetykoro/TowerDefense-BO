using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManagerScript : MonoBehaviour
{
    public float money;
    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI notEnoughMoneyText;
    void Start()
    {
        moneyText = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        notEnoughMoneyText = transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        moneyText.text = ("Money: "+money);
    }
    void NotEnoughMoneyFunction()
    {
        notEnoughMoneyText.alpha -= Time.deltaTime;
    }
}
