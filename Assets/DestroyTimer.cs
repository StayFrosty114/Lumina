using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FuckYiannisMom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FuckYiannisMom()
    {
        yield return new WaitForSeconds(2);
        DestroyImmediate(gameObject, true);

    }
}
