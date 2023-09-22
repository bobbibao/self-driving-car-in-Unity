using System.Collections.Generic;
using UnityEngine;

public class NeuralNetworkDisplay : MonoBehaviour
{
    public GameObject nodePrefab;
    public LineRenderer connectionPrefab; 

    private List<GameObject> nodes = new List<GameObject>();
    private List<LineRenderer> connections = new List<LineRenderer>();

    
    private List<float> nodeValues = new List<float> { 0.8f, 0.6f, 0.3f, 0.9f };
    private List<Vector3> nodePositions = new List<Vector3>
    {
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0)
    };
    private List<Vector3> connectionStarts = new List<Vector3>
    {
        new Vector3(0, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0)
    };
    private List<Vector3> connectionEnds = new List<Vector3>
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0)
    };

    void Start()
    {
        // Create nodes
        for (int i = 0; i < nodeValues.Count; i++)
        {
            GameObject node = Instantiate(nodePrefab, nodePositions[i], Quaternion.identity);
            nodes.Add(node);
        }

        // Create connections
        for (int i = 0; i < connectionStarts.Count; i++)
        {
            LineRenderer connection = Instantiate(connectionPrefab, Vector3.zero, Quaternion.identity);
            connections.Add(connection);
        }
    }

    void Update()
    {
        // Update node visual representation (e.g., change color or size based on values)
        for (int i = 0; i < nodes.Count; i++)
        {
            Color nodeColor = new Color(nodeValues[i], 1 - nodeValues[i], 0); // Example: Color based on node value
            nodes[i].GetComponent<Renderer>().material.color = nodeColor;
        }

        // Update connections between nodes
        for (int i = 0; i < connections.Count; i++)
        {
            connections[i].SetPosition(0, connectionStarts[i]);
            connections[i].SetPosition(1, connectionEnds[i]);
        }
    }
}
