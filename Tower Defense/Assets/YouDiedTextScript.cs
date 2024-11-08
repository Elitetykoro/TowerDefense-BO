using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class YouDiedTextScript : MonoBehaviour
{
    private float time;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            text.text = "Y";
            if (time > 1.5f)
            {
                text.text = "Yo";
                if (time > 2f)
                {
                    text.text = "You";
                    if (time > 2.5f)
                    {
                        text.text = "You d";
                        if (time > 3f)
                        {
                            text.text = "You de";
                            if (time > 3.25f)
                            {
                                text.text = "You d";
                                if (time > 3.5f)
                                {
                                    text.text = "You di";
                                    if (time > 3.9f)
                                    {
                                        text.text = "You die";
                                        if (time > 4f)
                                        {
                                            text.text = "You died";
                                            if (time > 5f)
                                            {
                                                SceneManager.LoadScene(0);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
