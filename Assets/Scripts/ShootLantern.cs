using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class ShootLantern : MonoBehaviour
{
    private bool playing;
    private float currentTime;
    public List<GameObject> fwList = new List<GameObject>();
    private LampKick lampKick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region VRController
        // Get the currently active VR device
        var vrDevice = VRDevice.Device;
        if (vrDevice == null)
            return;

        // Get the primary input device (the controller)
        var inputDevice = vrDevice.PrimaryInputDevice;
        if (inputDevice == null)
            return;
        #endregion

        if (inputDevice.GetButtonDown(VRButton.Trigger) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot();
        }

        currentTime += 1 * Time.deltaTime;
    }

    private void Shoot()
    {
        var hitResult = VRDevice.Device.PrimaryInputDevice.Pointer.CurrentRaycastResult;
        if (hitResult.gameObject != null)
        {
            if (hitResult.gameObject.GetComponent<LampKick>())
            {
                lampKick = hitResult.gameObject.GetComponent<LampKick>();
                if (lampKick.pushing == false)
                {
                    Boom(hitResult.gameObject);
                }
            }
        }
    }

    private void Boom(GameObject lamp)
    {
        // Debug.Log("Hit lantern");

        if (currentTime < 10)
        {
            Instantiate(fwList[Random.Range(0, 3)], lamp.transform.position, lamp.transform.rotation);
        }
        else if (currentTime >= 10 && currentTime < 20)
        {
            Instantiate(fwList[Random.Range(0, 7)], lamp.transform.position, lamp.transform.rotation);
        }
        else
        {
            Instantiate(fwList[Random.Range(0, fwList.Count)], lamp.transform.position, lamp.transform.rotation);
        }
        DestroyImmediate(lamp, true);
    }
}
