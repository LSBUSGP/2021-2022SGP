using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemeyRadar : MonoBehaviour
{
   public float radarDistance = 20, blipSize = 15;
    public bool usePlayerDirection = true;
    public Transform player;
    public GameObject blipRedPrefab,blipGreenPrefab;
    public string redBlipTag = "Enemy", greenBlipTag = "NPC";
 
    private float radarWidth, radarHeight, blipWidth, blipHeight;
 
    void Start() {
        radarWidth  = GetComponent<RectTransform>().rect.width;
        radarHeight = GetComponent<RectTransform>().rect.height;
        blipHeight  = radarHeight * blipSize/100;
        blipWidth   = radarWidth * blipSize/100;
    }
 
    void Update() {
        RemoveAllBlips();
        DisplayBlips(redBlipTag, blipRedPrefab);
        DisplayBlips(greenBlipTag, blipGreenPrefab);        
    }
 
    private void DisplayBlips(string tag, GameObject prefabBlip) {
        Vector3 playerPos = player.position;
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
 
        foreach (GameObject target in targets) {
            Vector3 targetPos = target.transform.position;
            float distanceToTarget = Vector3.Distance(targetPos, playerPos);
 
            if(distanceToTarget <= radarDistance) {
 
                Vector3 normalisedTargetPosition = NormalisedPosition(playerPos, targetPos);
                Vector2 blipPosition = CalculateBlipPosition(normalisedTargetPosition);
                DrawBlip(blipPosition, prefabBlip);
            }
        }
    }
     
    private void RemoveAllBlips() {
        GameObject[] blips = GameObject.FindGameObjectsWithTag("RadarBlip");
        foreach (GameObject blip in blips)
            Destroy(blip);
    }
 
    private Vector3 NormalisedPosition(Vector3 playerPos, Vector3 targetPos) {
        float normalisedTargetX = (targetPos.x - playerPos.x)/radarDistance;
        float normalisedTargetZ = (targetPos.z - playerPos.z)/radarDistance;
         
        return new Vector3(normalisedTargetX, 0, normalisedTargetZ);
    }
 
    private Vector2 CalculateBlipPosition(Vector3 targetPos) {
      
        float angleToTarget = Mathf.Atan2(targetPos.x,targetPos.z) * Mathf.Rad2Deg;
 
        float anglePlayer = usePlayerDirection? player.eulerAngles.y : 0;
       
        float angleRadarDegrees = angleToTarget - anglePlayer - 90;
 
        float normalisedDistanceToTarget = targetPos.magnitude;
        float angleRadians = angleRadarDegrees * Mathf.Deg2Rad;
        float blipX = normalisedDistanceToTarget * Mathf.Cos(angleRadians);
        float blipY = normalisedDistanceToTarget * Mathf.Sin(angleRadians);
 
        blipX *= radarWidth*.5f;
        blipY *= radarHeight*.5f;

        blipX += (radarWidth*.5f) - blipWidth*.5f;
        blipY += (radarHeight*.5f) - blipHeight*.5f;
 
        return new Vector2(blipX, blipY);
    }
 
    private void DrawBlip(Vector2 pos, GameObject blipPrefab) {
        GameObject blip = (GameObject) Instantiate(blipPrefab);
        blip.transform.SetParent(transform);
        RectTransform rt = blip.GetComponent<RectTransform>();
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,pos.x, blipWidth);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,pos.y, blipHeight);
    }
}
