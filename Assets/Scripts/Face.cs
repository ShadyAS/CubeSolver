using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FacePosition
{
    FRONT,
    BACK,
    RIGHT,
    LEFT,
    UP,
    DOWN
}

public class Face : MonoBehaviour
{
    [SerializeField] Node pivot;
    [SerializeField] List<Node> nodes = new List<Node>();

    [SerializeField] FacePosition position;

    public Node Pivot { get => pivot; set => pivot = value; }
    public List<Node> Nodes { get => nodes; set => nodes = value; }

    public void UpdatesNodes()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].UpdateCube();
        }
    }
}
