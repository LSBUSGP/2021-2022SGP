using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float firerate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Requiremets")]
    public string playerTag = "Player";

    public Transform partToRoate;
    public float turnspeed = 10f;

    [Header("bullets")]
    public GameObject bulletPrefab;
    public Transform firePoint;

   


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }

    void updateTarget()
    {
        GameObject[] playertar = GameObject.FindGameObjectsWithTag(playerTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach(GameObject Player in playertar)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
            if (distanceToPlayer < shortestDistance )
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = Player;
            }
        }


        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRoatation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRoate.rotation, lookRoatation, Time.deltaTime * turnspeed).eulerAngles;
        partToRoate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0)
        {
            shoot();
            fireCountDown = 1f / firerate;
        }

        fireCountDown -= Time.deltaTime;
        
    }

    void shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.seek(target);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
