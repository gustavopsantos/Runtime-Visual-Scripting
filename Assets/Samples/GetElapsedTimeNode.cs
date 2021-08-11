using UnityEngine;

public class GetElapsedTimeNode : Node
{
    private void Start()
    {
        SetTitle("Get Elapsed Time");
        AddParameterOutput<float>((_) => Time.time);
    }
}