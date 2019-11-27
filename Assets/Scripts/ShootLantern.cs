using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class ShootLantern : MonoBehaviour
{

    public List<GameObject> fireworksList = new List<GameObject>();

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

        if (inputDevice.GetButtonDown(VRButton.Trigger))
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
        // Debug.Log("Hit lantern");
        Instantiate(fireworksList[Random.Range(0, fireworksList.Count)], lamp.transform.position, lamp.transform.rotation);
        DestroyImmediate(lamp, true);
    }
}
