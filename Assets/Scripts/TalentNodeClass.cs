using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentNodeClass
{
    public bool isUnlocked;
    private Vector2 _position;
    public NodeType nodeType { get; set; }
    public int nodeLevel;
    private int _powerMultiplier;
    private GameObject _nodeObj;
    public Vector2 Position
    {
        get { return _position; }
        set 
        { 
            _position = value; 
            _powerMultiplier = (int)(Vector2.Distance(_position, Vector2.zero) / 3.0f);
        }
    }

    public GameObject GetNodeObj() 
    {
        return _nodeObj;
    }

    public void SetNodeObj(GameObject gameObj)
    {
        _nodeObj = gameObj;
    }

    public float GetNodeRadius()
    {
        return nodeLevel == 0 ? 0.01f : nodeLevel * 3;
    }

    public int GetSkillPointsCost()
    {
        return (nodeLevel + 1) * 2;
    }

    public TalentNodeClass(NodeType _nodeType, Vector2 position)
    {
        nodeType = _nodeType;
        _position.Set(position.x, position.y);
    }

    public float GetNodePower()
    {
        return nodeLevel * _powerMultiplier;
    }

    public int GetNodeLevel()
    {
        return nodeLevel;
    }
}



public enum NodeType
{
    IncreaseAttack,
    IncreaseRange,
    IncreaseAttackPct,
    IncreaseAttackSpd,
    Start
}
