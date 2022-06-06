using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWebcamUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.RawImage rawImage;
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }
        WebCamTexture tex = new WebCamTexture(devices[1].name);
        this.rawImage.texture = tex;
        tex.Play();
    }
}
