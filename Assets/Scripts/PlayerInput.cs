using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;

    public event UnityAction<Dynamite> ClickOnCube;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {     
            _ray = _camera.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit))
            {
                Transform transformHit = hit.transform;
                if (transformHit.TryGetComponent<Dynamite>(out Dynamite dinamite))
                {
                    ClickOnCube?.Invoke(dinamite);
                }
            }
        }
    }
}
