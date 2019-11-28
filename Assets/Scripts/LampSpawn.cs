using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class LampSpawn : MonoBehaviour
{

    public GameObject lampSpawner;
    public GameObject lamp;
    private bool spawning;
    

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        StartCoroutine(SpawnLamp());
    }

    // Update is called once per frame
    void Update()
    {
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        // Get the primary input device (the controller)
        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
            return;
    }

    private IEnumerator SpawnLamp()
    {
        while (spawning)
        {
            Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }

}
