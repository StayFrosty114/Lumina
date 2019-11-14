using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Liminal;
using Liminal.SDK.VR;
using Liminal.SDK.Input;
using Liminal.SDK.VR.Input;

public class ShootLantern : MonoBehaviour
{
    [SerializeField]
    GameObject fireWorkSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the currently active VR device
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        // Get the primary input device (the controller)
        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
            return;

        if (inputDevice.GetButtonDown(VRButton.One))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var hitResult = VRDevice.Device.PrimaryInputDevice.Pointer.CurrentRaycastResult;
        if (hitResult.gameObject != null)
        {
            if (hitResult.gameObject.CompareTag("Lamp"))
            {
                Boom(hitResult.gameObject);
            }
        }
    }

    private void Boom(GameObject lamp)
    {
        Debug.Log("Hit lantern");
        Instantiate(fireWorkSpawner, lamp.transform.position, lamp.transform.rotation);
        DestroyImmediate(lamp, true);
    }
}
