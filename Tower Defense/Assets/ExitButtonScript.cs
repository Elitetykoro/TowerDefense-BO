using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    private void OnMouseUp()
    {
        Application.Quit();
    }
}
