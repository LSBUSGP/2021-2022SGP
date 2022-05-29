using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    [SerializeField] float Spd;
    bool Turning;
    Rigidbody rb;
    Vector3 TargetRotation;
    Vector3 TargetPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
    
            rb.velocity = transform.forward * Spd;
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 90,0);
            transform.position = collision.transform.position;
        }
        else if (collision.gameObject.tag == "Left")
        {
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y - 90,0);
            transform.position = collision.transform.position;
        }

        if (collision.gameObject.tag == "Destroy")
        {
            FindObjectOfType<SpawnRoad>().DestroySegment();
        }
    }

}
