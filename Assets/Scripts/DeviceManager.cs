using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    private CancellationTokenSource cancellationTokenSource;

    void Start()
    {
        Debug.Log("DeviceManager Init");
        cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        ShowDevices(cancellationToken);
    }

    private async void ShowDevices(CancellationToken cancellationToken)
    {
        while (true)
        {
            // https://docs.unity3d.com/ScriptReference/WebCamTexture-devices.html
            WebCamDevice[] devices = WebCamTexture.devices; // Performance issue

            for (int i = 0; i < devices.Length; i++)
                Debug.Log(devices[i].name);
            await Task.Delay(1000, cancellationToken);
        }
    }

    private void OnDisable()
    {
        cancellationTokenSource.Cancel(); // Doing this will cancel any currently running task that passed in the CancellationToken reference.
    }
}
