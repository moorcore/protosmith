using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodePrefabScript : MonoBehaviour
{
    public TalentNodeClass talentNodeRef;
    public TalentTreeBehaviour treeBehaviour;
    public GameObject rangeDisplayObject;
    public GameObject typeSpriteObject;
    public float onPressTime;

    public void SetTalentNodeRef(TalentNodeClass _talentNodeRef)
    {
        talentNodeRef = _talentNodeRef;
        transform.position = talentNodeRef.Position;
    }

    public void UpdateRange()
    {
        rangeDisplayObject.GetComponent<ScalingScript>().UpdateRange(talentNodeRef.GetNodeRadius());
    }

    public void UpdateRange(float range)
    {
        Debug.Log(range);
        rangeDisplayObject.GetComponent<ScalingScript>().UpdateRange(range);
    }

    public void UpdateTypeSprite()
    {
        
    }

    void Start()
    {
        onPressTime = 0;
        treeBehaviour = Camera.main.transform.GetComponent<TalentTreeBehaviour>();
        UpdateRange(); 
    }

    void Update()
    {
        if (onPressTime != 0)
            ChangeNodeColorOnClick();
    }

    void OnMouseOver()
    {
        // Must show a tooltip with node data!
        // int test = talentNodeRef.GetNodeLevel();
        // Debug.Log("Node level: " + test);  
    }

    void OnMouseDown()
    {
        Debug.Log("1");
        if (treeBehaviour.TryNodeLvlUp(talentNodeRef))
        {
            Debug.Log("2");
            onPressTime = Time.time;
            UpdateRange();
        }
    }

    void ChangeNodeColorOnClick()
    {
        float colorMult = Mathf.Sin((Time.time - onPressTime) * Mathf.PI);
        GetComponent<SpriteRenderer>().color = Color.green * colorMult;
        GetComponent<SpriteRenderer>().color = 
            new Color(Color.green.r * colorMult, Color.green.g * colorMult, Color.green.b * colorMult, 1f);
    }
    
}