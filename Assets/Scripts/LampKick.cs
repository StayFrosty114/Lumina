﻿using System.Collections;
using UnityEngine;

public class LampKick : MonoBehaviour
{
    private Rigidbody rb;

    private float kickForce = 250f;
    public bool pushing = false;
    public bool shootable = false;
    Vector3 pushForce;

    // Start is called before the first frame update
    private void Awake()
    {
        pushForce = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(0f, 0.5f), UnityEngine.Random.Range(0f, 0.5f));
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(UnityEngine.Random.Range(-50f, 50f), UnityEngine.Random.Range(0f, 50f), kickForce);
        // Debug.Log("Kick the fucker");
        shootable = false;
        pushing = true;
        StartCoroutine(PushTimer());
        Invoke("Shootable", 5);
        Invoke("Stop", 10);
    }

    private IEnumerator PushTimer()
    {
        while (pushing)
        {
            // Debug.Log(pushing);
            rb.AddForce(pushForce);
            yield return new WaitForEndOfFrame();
        }
    }

    private void Stop()
    {
        pushing = false;
    }

    private void Shootable()
    {
        shootable = true;
    }
}
