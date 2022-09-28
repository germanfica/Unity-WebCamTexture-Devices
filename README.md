# WebCamTexture Devices

A separate unity project was created to investigate the WebCamTexture Devices performance issue. The objetive is to be able to display the connected devices every certain period of time. It is necessary to know if any device was disconnected.

## Performance issue

A performance issue has been found in WebCamTexture.devices.

![WebCamTexture-devices-performance-issue](/Images/WebCamTexture.devices-performance-issue.png)

## Specs of the PC used

```
Device name	William
Processor	AMD Ryzen 5 3600 6-Core Processor                 3.59 GHz
Installed RAM	16.0 GB
System type	64-bit operating system, x64-based processor
Pen and touch	Pen support

Edition	Windows 11 Pro
Version	21H2
Installed on	25/06/2022
OS build	22000.978
Experience	Windows Feature Experience Pack 1000.22000.978.0

BaseBoard Manufacturer	ASRock
BaseBoard Product	B450M-HDV R4.0

Display name	Radeon RX 570 Series
Display driver version	30.0.13023.4001
```

## Script

```C#
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
```
