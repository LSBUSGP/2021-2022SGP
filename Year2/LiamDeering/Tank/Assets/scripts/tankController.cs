using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ld
{
    public class tankController : MonoBehaviour
    {
        public Transform cannoball;
        public static Vector3 currentPos;
        private string waitToShoot = "n";
        private void Start()
        {

        }

        private void Update()
        {
            currentPos = transform.position;

            if (Input.GetKey("a"))
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, -90, 0);
                GetComponent<Rigidbody>().velocity = transform.forward * 5.5f;
            }
            else
                if (Input.GetKey("d"))
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
                GetComponent<Rigidbody>().velocity = transform.forward * 5.5f;
            }
            else
                if (Input.GetKey("w"))
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().velocity = transform.forward * 5.5f;
            }
            else
                if (Input.GetKey("s"))
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
                GetComponent<Rigidbody>().velocity = transform.forward * 5.5f;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = transform.forward * 0;
            }

            if (Input.GetMouseButton(0) && (waitToShoot == "n"))
            {
                waitToShoot = "y";
                Instantiate(cannoball, new Vector3(transform.position.x, 1.57f, transform.position.z), transform.rotation);
                StartCoroutine(shotReset());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "shot2")
            {
                Destroy(gameObject);
            }
        }

        IEnumerator shotReset()
        {
            yield return new WaitForSeconds(.5f);
            waitToShoot = "n";
        }
    }
}