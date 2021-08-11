public class UpdateNode : Node
{
    private Socket _exec;
    
    private void Start()
    {
        SetTitle("Update");
        _exec = AddExecutionOutput((socket) => { socket.Connection?.Execute(); });
    }

    private void Update()
    {
        _exec.Execute();   
    }
}