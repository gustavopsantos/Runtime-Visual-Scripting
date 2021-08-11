using UnityEngine;

public class Presenter<TView> : MonoBehaviour where TView : MonoBehaviour
{
    protected TView View { get; private set; }

    private void Awake()
    {
        View = GetComponentInChildren<TView>(true);
    }
}