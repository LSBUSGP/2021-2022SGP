using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarContact : MonoBehaviour
{
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Radar");
    }
}