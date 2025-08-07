using UnityEngine;

public class CubeRenderer : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;

    public void SetMaterial(Material material)
    {
        _renderer.material = material;
    }
}
