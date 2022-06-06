using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWebCam : MonoBehaviour
{
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }
        Renderer rend = this.GetComponentInChildren<Renderer>();
        WebCamTexture tex = new WebCamTexture(devices[1].name);
        rend.material.mainTexture = tex;
        tex.Play();
    }
}
