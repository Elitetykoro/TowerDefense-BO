using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotEnoughMoneyScript : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        text.alpha -= Time.deltaTime;
    }
}
