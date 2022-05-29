using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{

    [SerializeField] GameObject[] RoadPieces;
    Transform EndPoint;

    [SerializeField] int RoadLength = 5;
    int RoadCount;

    GameObject PreviousSegment;
    GameObject NewSegment;

    int RetryCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, RoadPieces.Length);
        NewSegment = Instantiate(RoadPieces[i], transform.position, Quaternion.identity, this.transform);

        CreateNewSegment();
    }

    void CreateNewSegment()
    {
        EndPoint = NewSegment.transform.GetChild(0);
        int i = Random.Range(0, RoadPieces.Length);


        if (!Physics.Raycast(EndPoint.position, EndPoint.forward, 20))
            NewSegment = Instantiate(RoadPieces[i], EndPoint.position, EndPoint.rotation, this.transform);
        else
            return;

        RoadCount++;

        if (transform.childCount < RoadLength)
            CreateNewSegment();
    }

    public void DestroySegment()
    {

        Destroy(transform.GetChild(0).gameObject);
        CreateNewSegment();

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(EndPoint.position,EndPoint.position + EndPoint.forward * 20);
    //}

}
