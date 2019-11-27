using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class LampSpawn : MonoBehaviour
{

    public GameObject lampSpawner;
    public GameObject lamp;
    private bool cooldown = false;
    

    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
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

        if (cooldown == false)
        {
            if (inputDevice.GetButtonDown(VRButton.One))
            {
                Instantiate(lamp, lampSpawner.transform.position, lampSpawner.transform.rotation);
                Debug.Log("Lantern spawned");
                cooldown = true;
                StartCoroutine(CoolTimer());
            }
        }
    }

    private IEnumerator CoolTimer()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;
    }
}
