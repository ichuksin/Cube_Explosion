using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;

    private Ray _ray;

    public event UnityAction<Cube> ClickOnCube;

    private void OnEnable()
    {
        _inputReader.MouseButtonClick += Raycast;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonClick += Raycast;
    }

    private void Raycast(Vector3 point)
    {
        _ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                ClickOnCube?.Invoke(cube);
            }
        }
    }
}
