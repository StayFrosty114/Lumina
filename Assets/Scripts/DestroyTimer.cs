using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        DestroyImmediate(gameObject, true);

    }
}
