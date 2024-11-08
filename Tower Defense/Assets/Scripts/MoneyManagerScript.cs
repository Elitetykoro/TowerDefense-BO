using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyManagerScript : MonoBehaviour
{
    public float money;
    public float lives;
    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI livesText;
    private TextMeshProUGUI notEnoughMoneyText;
    void Start()
    {
        lives = 3;
        moneyText = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        notEnoughMoneyText = transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        livesText = transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        moneyText.text = ("Money: "+money);
        livesText.text = ("Lives: "+lives);
        transform.GetChild(0).transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().alpha -= 1;
        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
