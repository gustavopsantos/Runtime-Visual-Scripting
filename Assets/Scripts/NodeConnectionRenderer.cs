using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NodeConnectionRenderer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        foreach (var socket in FindAllConnectedOutputSocket())
        {
            var point0 = socket._connectionAnchor.position;
            var point1 = socket.Connection._connectionAnchor.position;
            var tangent0 = point0 + Vector3.right * 3;
            var tangent1 = point1 - Vector3.right * 3;
            Handles.DrawBezier(point0, point1, tangent0, tangent1, Color.white, Texture2D.whiteTexture, 5);
        }
    }

    private IEnumerable<Socket> FindAllConnectedOutputSocket()
    {
        return FindObjectsOfType<NodeRow>()
            .Select(row => row.Output)
            .Where(outputSocket => outputSocket.Connection != null);
    }
}