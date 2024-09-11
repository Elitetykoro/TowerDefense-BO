using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        while (true) 
        {
            StartCoroutine(Spawn());
        }


    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Enemy);
    }
}
