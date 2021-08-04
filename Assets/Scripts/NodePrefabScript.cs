using UnityEngine;

public class NodePrefabScript : MonoBehaviour
{
    public TalentNodeClass talentNodeRef;
    public TalentTreeBehaviour treeBehaviour;
    public GameObject rangeDisplayObject;

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

    void Start()
    {
        treeBehaviour = Camera.main.transform.GetComponent<TalentTreeBehaviour>();
        UpdateRange(); 
    }

    void OnMouseOver()
    {
        // Must show a tooltip with node data!
        // int test = talentNodeRef.GetNodeLevel();
        // Debug.Log("Node level: " + test);  
    }
    void OnMouseDown()
    {
        if (treeBehaviour.TryNodeLvlUp(talentNodeRef))
        {
            UpdateRange();
        }
    }
    
}