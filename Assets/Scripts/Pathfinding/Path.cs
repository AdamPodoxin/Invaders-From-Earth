using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> Nodes { get; } = new List<Transform>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            Nodes.Add(child);
        }
    }

    public Transform GetClosestNodeFromPosition(Vector3 position)
    {
        Transform closestNode = Nodes[0];
        float closestMagnitude = (position - closestNode.position).magnitude;

        foreach (Transform node in Nodes)
        {
            if ((position - node.position).magnitude < closestMagnitude)
            {
                closestNode = node;
                closestMagnitude = (position - node.position).magnitude;
            }
        }

        return closestNode;
    }

    public Transform GetClosestNodeFromPosition(Vector3 position, bool includeFirstNode)
    {
        Transform closestNode;

        if (includeFirstNode) closestNode = Nodes[0];
        else closestNode = Nodes[1];

        float closestMagnitude = (position - closestNode.position).magnitude;

        foreach (Transform node in Nodes)
        {
            if (!includeFirstNode)
            {
                if (node.Equals(Nodes[0])) continue;
            }

            if ((position - node.position).magnitude < closestMagnitude)
            {
                closestNode = node;
                closestMagnitude = (position - node.position).magnitude;
            }
        }

        return closestNode;
    }

    public Transform GetClosestNodeFromPosition(Vector3 position, Transform excludeNode)
    {
        Transform closestNode = Nodes[0];
        float closestMagnitude = (position - closestNode.position).magnitude;

        foreach (Transform node in Nodes)
        {
            if (node.Equals(excludeNode)) continue;

            if ((position - node.position).magnitude < closestMagnitude)
            {
                closestNode = node;
                closestMagnitude = (position - node.position).magnitude;
            }
        }

        return closestNode;
    }
}
