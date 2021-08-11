using UnityEngine;

public class CosNode : Node
{
    private void Start()
    {
        SetTitle("Cos");
        var rad = AddParameterInput<float>((socket) => (float) (socket.Connection ? socket.Connection.Evaluate : default(float)), "Rad");
        AddParameterOutput<float>((socket) => Mathf.Cos((float) rad.Evaluate), "Cos");
    }
}