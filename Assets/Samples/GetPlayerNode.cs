using UnityEngine;

public class GetPlayerNode : Node
{
    private void Start()
    {
        SetTitle("Get Player");
        AddParameterOutput<GameObject>((_) => GameObject.FindGameObjectWithTag("Player"));
    }
}