using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private int _mouseButtonIndex = 0;

    public event UnityAction<Vector3> MouseButtonClick;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonIndex))
            MouseButtonClick?.Invoke(Input.mousePosition);
    }
}
