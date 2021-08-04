using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TalentTreeBehaviour : MonoBehaviour
{
    public GameObject nodePrefab;
    List<TalentNodeClass> nodeList;
    private float _dps;
    private int _treeLevel;
    public int skillPoints;

    void Start()
    {
        _treeLevel = 1;
        skillPoints = 10;
        nodeList = new List<TalentNodeClass>();
        InitializeTree();
    }

    public int GetTreeLevel()
    {
        return _treeLevel;
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    public float GetDPS()
    {
        return _dps;
    }

    TalentNodeClass InitializeNode(NodeType nodeType, Vector2 position)
    {
        TalentNodeClass newNode = new TalentNodeClass(nodeType, position);

        var nodeGameObject = Instantiate(nodePrefab);
        nodeGameObject.GetComponent<NodePrefabScript>().SetTalentNodeRef(newNode);
        nodeList.Add(newNode);

        return newNode;
    }

    void InitializeTree()
    {
        int nodeCount = _treeLevel * 24;

        for (int i = 1; i <= nodeCount; i++)
        {
            Vector2 nodePosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * (i / 3f);
            InitializeNode(NodeType.IncreaseAttack, nodePosition);
        }
        InitializeBaseNode();
    }

    void InitializeBaseNode()
    {
        TalentNodeClass newNode = new TalentNodeClass(NodeType.Start, Vector2.zero);
        var nodeGameObject = Instantiate(nodePrefab);
        nodeGameObject.GetComponent<NodePrefabScript>().SetTalentNodeRef(newNode);
        nodeList.Add(newNode);
        newNode.isUnlocked = true;
        NodeLvlUp(newNode);
        nodeGameObject.GetComponent<NodePrefabScript>().UpdateRange(newNode.GetNodeRadius());
    }

    public bool TryNodeLvlUp(TalentNodeClass node)
    {
        /*  
        Checks if the node is within the abailable range
        Checks if there's enough skillpoints to upgrade the node
        Expands the range within which we can activate nodes
        Levels up
        */
        int skillPointCost = node.GetSkillPointsCost();
        if (node.isUnlocked && 
            GetSkillPoints() >= skillPointCost)
        {
            NodeLvlUp(node);
            skillPoints -= skillPointCost;
            return true;
        }

        return false;
    }

    public void NodeLvlUp(TalentNodeClass node)
    {
        node.nodeLevel++;
        nodeList.Where(n => !n.isUnlocked).ToList().ForEach(n => {
            if (Vector2.Distance(node.Position, n.Position) <= node.GetNodeRadius())
            {
                n.isUnlocked = true;
            }
        });
    }
}
