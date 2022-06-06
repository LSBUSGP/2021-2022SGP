Image Compositing Shader Guide
==================
This documentation describes how to use the `Image Compositing Shader` component in your project.

Behaviours
----------
-   \[`ChromaKeyShader`\]
-   \[`DisplayWebCam`\]
-   \[`DisplayWebcamUI`\]

ChromaKeyShader
------------------------
This shader allows for Images/Videos/Gifs to have their backgrounds chroma keyed out.
    
### Properties
-   `Mask Color` The colour that the shader will remove.
-   `Threshold Sensitivty` how much of the image is removed.
-   `Smoothing` how much of the colour is removed. 


DisplayWebCam
------------------------
This behaviour allows the user to display their webcam inside Unity.
    
### Script    
In our start function we get a list of all the webcams the player currently has, the console will show what number the webcam is assigned to.
    
```    
{
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }
        
```     
    
We then render the webcam onto the plane the script is attatched to, since my Webcam is the 2nd one on the list I have used '1' in the script.

        
```     
        Renderer rend = this.GetComponentInChildren<Renderer>();
        WebCamTexture tex = new WebCamTexture(devices[1].name);
        rend.material.mainTexture = tex;
        tex.Play();
    }
}
```  

DisplayWebCamUI
------------------------
This behaviour allows the user to display their webcam on the UI in Unity.
    
### Script    
We reference the raw image we want the players camera to be on which can be assigned in the Inspector, the script is pretty much identical to the other one accept we reference the rawimage instead.
    
```    
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
```  
