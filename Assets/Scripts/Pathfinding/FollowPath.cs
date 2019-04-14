using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private Path path;

    [SerializeField]
    private float moveSpeed = 5f;

    private Vector2 direction;

    private Transform nextNode;
    private int nextNodeIndex = 0;

    private void Start()
    {
        nextNode = path.Nodes[0];

        CalculateDirection();
    }

    private void Update()
    {
        MoveToNode(nextNode);
        CheckPathProgress();
    }

    private void CalculateDirection()
    {
        direction = (nextNode.position - transform.position).normalized;
    }

    private bool CalculateProximityToNextNode()
    {
        return (nextNode.position - transform.position).magnitude < 0.1f;
    }

    private void SetNextNode()
    {
        nextNodeIndex++;
        nextNode = path.Nodes[nextNodeIndex];
    }

    private void MoveToNode(Transform node)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void CheckPathProgress()
    {
        if (CalculateProximityToNextNode())
        {
            if (nextNodeIndex < path.Nodes.Count - 1)
            {
                SetNextNode();
                CalculateDirection();
            }
        }
    }
}
