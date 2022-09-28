using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("DeviceManager Init");
        ShowDevices();
    }

    private async void ShowDevices()
    {
        while (true)
        {
            // https://docs.unity3d.com/ScriptReference/WebCamTexture-devices.html
            WebCamDevice[] devices = WebCamTexture.devices; // Performance issue

            for (int i = 0; i < devices.Length; i++)
                Debug.Log(devices[i].name);
            await Task.Delay(1000);
        }
    }
}
