using UnityEngine;

public class NodeRow : MonoBehaviour
{
    [field: SerializeField] public Socket Input { get; private set; }
    [field: SerializeField] public Socket Output { get; private set; }
}