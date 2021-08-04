using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingScript : MonoBehaviour
{
    public GameObject spriteMask;
    float oldScale = 0.01f;
    float finalScale = 0.01f;
    float levelUpTime;

    void Start() 
    {
        levelUpTime = Time.time;
    }

    void Update() 
    {
        float step = SmoothStep(Mathf.Min(Time.time - levelUpTime, 1f));
        float scale = finalScale * step + oldScale * (1 - step);
        transform.localScale = Vector3.one * scale;
        spriteMask.transform.localScale = Vector3.one * ((0.1f / scale) - 1f);
    }

    public void UpdateRange(float newRange) 
    {
        oldScale = transform.localScale.x;
        finalScale = newRange * 2f; //Diameter is twice greater than radius
        levelUpTime = Time.time;
    }

    float SmoothStep(float x) 
    {
        return (x * x * (3 - 2 * x));
    }
}
