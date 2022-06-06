Radar Guide
==================
This documentation describes how to use the `Radar` component in your project.

Behaviours
----------
-   \[`PlayerMovement`\]
-   \[`Radar`\]
-   \[`RadarContact`\]

PlayerMovement
------------------------
This behaviour allows the player to move in Unity.
    
### Script 
We create fields for the speed and rotation speed that can be edited in the Inspector.
In our uupdate function we get the Horizontal and Vertical inputs, since we dont want to be able to move up and down, we set the y axis to 0   
    
```    
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationspeed;
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
 }
}     
        
```      

Radar
------------------------
This behaviour allows the user to display their webcam on the UI in Unity.
    
### Script    
We create a list of gameobjects that will be tracked on the radar, this can be added to in the Inspector, in order to use lists we must add the systems collections generic line at the top. We assign the radar prefab to all the objects so that they appear red on the radar. The border object will sit at the edge of the minimap meanwhile the radar objects will move when we are close to them, the switchdistance determines when that transition happens. And we also setup a blue icon for our player.

In our start void we get all the gameobjects in the last and track them
    
```    
using Systems.Collections.Generic;
{
    {
    public GameObject[] trackedObjects;
    List<GameObject> radarObjects;
    public GameObject radarPrefab;
    List<GameObject> borderObjects;
    public float switchDistance;
    public Transform helpTransform;

    private void Start()
    {
        createRadarObjects();
    }
```   

Checks to see if the distance between the player and the tracked objects is greater than the switch distance. Switches between border and radar object depending on if the distance is greater.

```   
    private void Update()
    {
        for (int i = 0; i < radarObjects.Count; i++)
        {
           if (Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
           {
                helpTransform.LookAt(radarObjects[i].transform);
                borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("Radar");
                radarObjects[i].layer = LayerMask.NameToLayer("Invisible");
            }
            else
            {
                borderObjects[i].layer = LayerMask.NameToLayer("Invisible"); ;
                radarObjects[i].layer = LayerMask.NameToLayer("Radar");
            }
        }
    }
    
```   

Instantiates and adds the radar objects to the tracked objects.

```
    void createRadarObjects()
    {
        radarObjects = new List<GameObject>();
        borderObjects = new List<GameObject>();
        foreach (GameObject o in trackedObjects)
        {
            GameObject k = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            radarObjects.Add(k);
            GameObject j = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            borderObjects.Add(j);
        }
    }
}
```  
RadarContact
------------------------
This behaviour allows the an object to be displayed on the Radar, although it will not work with the above script.
    
### Script    
Using the layer we created that tells our second camera what to look at, we can get objects with the radarcontact script to appear on the radar
    
```    
private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Radar");
    }
```   
