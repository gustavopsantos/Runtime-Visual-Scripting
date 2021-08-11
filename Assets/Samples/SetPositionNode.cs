using UnityEngine;

public class SetPositionNode : Node
{
    private Socket _target;
    private Socket _x;
    private Socket _y;
    private Socket _z;

    private Socket _next;

    private void Start()
    {
        SetTitle("Set Position");
        AddExecutionInput((socket) => SetPosition());
        _next = AddExecutionOutput((socket) => { socket.Connection?.Execute(); });
        _target = AddParameterInput<GameObject>((socket) => (GameObject) (socket.Connection ? socket.Connection.Evaluate : null), "Target");
        _x = AddParameterInput<float>((socket) => (float) (socket.Connection ? socket.Connection.Evaluate : default(float)), "X");
        _y = AddParameterInput<float>((socket) => (float) (socket.Connection ? socket.Connection.Evaluate : default(float)), "Y");
        _z = AddParameterInput<float>((socket) => (float) (socket.Connection ? socket.Connection.Evaluate : default(float)), "Z");
    }

    private void SetPosition()
    {
        var target = (GameObject) _target.Evaluate;
        
        if (target != null)
        {
            var position = new Vector3((float) _x.Evaluate, (float) _y.Evaluate, (float) _z.Evaluate);
            target.transform.position = position;
        }

        _next.Execute();
    }
}