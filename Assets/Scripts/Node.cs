using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Node : Presenter<NodeView>
{
    private readonly Dictionary<string, Socket> _sockets = new Dictionary<string, Socket>();

    protected void SetTitle(string title)
    {
        View.Title.text = title;
    }

    protected Socket AddExecutionInput(Action<Socket> func, string title = "")
    {
        return GetUninitializedSocket(row => row.Input).Initialize(title, typeof(void), func);
    }

    protected Socket AddExecutionOutput(Action<Socket> func, string title = "")
    {
        return GetUninitializedSocket(row => row.Output).Initialize(title, typeof(void), func);
    }

    protected Socket AddParameterInput<T>(Func<Socket, T> func, string title = "")
    {
        return GetUninitializedSocket(row => row.Input).Initialize(title, typeof(T), (socket) => func(socket));
    }

    protected Socket AddParameterOutput<T>(Func<Socket, T> func, string title = "")
    {
        return GetUninitializedSocket(row => row.Output).Initialize(title, typeof(T), (socket) => func(socket));
    }

    private Socket GetUninitializedSocket(Func<NodeRow, Socket> selector)
    {
        var rows = GetComponentsInChildren<NodeRow>(true);
        var inputs = rows.Select(selector).ToArray();

        return inputs.Count(row => !row.IsInitialized) > 0
            ? inputs.First(row => !row.IsInitialized)
            : selector(Instantiate(Resources.Load<NodeRow>(nameof(NodeRow)), transform.Find("Content")));
    }
}