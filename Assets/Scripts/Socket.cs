using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Socket : MonoBehaviour
{
    [SerializeField] private SocketKind _kind;
    [SerializeField] internal Text _title;
    [SerializeField] private Image _executionIcon;
    [SerializeField] private Image _parameterIcon;
    [SerializeField] internal RectTransform _connectionAnchor;
    [SerializeField] private GraphicEventTrigger _graphicEventTrigger;

    private Type _type;
    private Vector3 _dragPosition;
    private Func<Socket, object> _func;
    private Action<Socket> _func2;

    public bool IsInitialized => _type != null;
    public Socket Connection { get; private set; }
    public bool IsConnected => Connection != null;
    public object Evaluate => _func(this);

    public void Execute()
    {
        _func2(this);
    }

    public Socket Initialize(string title, Type type, Func<Socket, object> func)
    {
        _func = func;
        _title.text = title;
        _type = type;
        SetupIcon();
        _graphicEventTrigger.OnDrag += OnDrag;
        _graphicEventTrigger.OnDrop += OnDrop;
        return this;
    }
    
    public Socket Initialize(string title, Type type, Action<Socket> func)
    {
        _func2 = func;
        _title.text = title;
        _type = type;
        SetupIcon();
        _graphicEventTrigger.OnDrag += OnDrag;
        _graphicEventTrigger.OnDrop += OnDrop;
        return this;
    }

    private void OnDrag(PointerEventData pointerEventData)
    {
        _dragPosition = GetMouseWorldPosition();
    }

    private void OnDrop(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag != null)
        {
            var incomingSocket = pointerEventData.pointerDrag.GetComponentInParent<Socket>();
            Connect(this, incomingSocket);
        }
    }

    private static void Connect(Socket a, Socket b) // TODO: Split into instance methods connect and disconnect
    {
        bool canConnect = a._type == b._type && a._kind != b._kind;

        if (!canConnect)
        {
            return;
        }
        
        // Disconnect
        if (a.Connection)
        {
            a.Connection.Connection = null;
        }

        if (b.Connection)
        {
            b.Connection.Connection = null;
        }

        a.Connection = null;
        b.Connection = null;

        // Connect
        a.Connection = b;
        b.Connection = a;
    }

    public void OnDrawGizmos()
    {
        Handles.Label(_connectionAnchor.position, Connection ? "Connected" : "Disconnected");
    }

    private static Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void SetupIcon()
    {
        var isExecutionSocket = _type == typeof(void);
        _executionIcon.enabled = isExecutionSocket;
        _parameterIcon.enabled = !isExecutionSocket;
    }
}