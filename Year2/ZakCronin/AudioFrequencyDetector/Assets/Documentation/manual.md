Audio Frequency Detector Guide
==================
This documentation describes how to use the `Audio Frequency Detector` component in your project.

Behaviours
----------
-   \[`SpectrumAnalyzer`\]


SpectrumAnalyzer
------------------------
This behaviour allows audio to be visualised via scaling cubes.
    
### Script 
We create fields for our 4 cubes which are going to visualise the music and the user can customise the intensity of the scaling of these cubes.   
    
```    
{
    public GameObject cube01;
    public GameObject cube02;
    public GameObject cube03;
    public GameObject cube04;

    public float intensity = 20f;
    public float[] spec;

    public float specMag01;
    public float specMag02;
    public float specMag03;
    public float specMag04;
    public float specMag05;

``` 
Inside of the update function we reference the spectrum on the audiolistener on the camera, by default the component takes 64 samples but the script can be customised for larger samples. Once we work out the spectrum for each cube we then times it by the intensity so that the cube on scales upwards.

``` 
    void Update()
    {
        spec = AudioListener.GetSpectrumData(64,0,FFTWindow.Hamming);

        specMag01 = spec[1] + spec[15];
        specMag02 = spec[16] + spec[30];
        specMag03 = spec[31] + spec[45];
        specMag04 = spec[46] + spec[60];

        cube01.gameObject.transform.localScale = new Vector3(1f, specMag01 * intensity, 1f);
        cube02.gameObject.transform.localScale = new Vector3(1f, specMag02 * intensity, 1f);
        cube03.gameObject.transform.localScale = new Vector3(1f, specMag03 * intensity, 1f);
        cube04.gameObject.transform.localScale = new Vector3(1f, specMag04 * intensity, 1f);
    }
}
        
```      
