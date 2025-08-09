using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))] 
public class Cube : MonoBehaviour
{
    [SerializeField] private float _scale;
    [SerializeField] private float _probabilitySeparation;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private CubeRenderer _cubeRenderer;

    private Rigidbody _rigidbody;
    
    public float Probability => _probabilitySeparation;
    public float Scale => _scale;
    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;
    public Rigidbody Rigidbody => _rigidbody;
    public CubeRenderer CubeRenderer => _cubeRenderer;

    public event UnityAction<Cube> Exploded;
    
    public void Init(float scale, float probabilitySeparation, float explosionRadius, float explosionForce, Vector3 position)
    {
        _explosionRadius = explosionRadius;
        _explosionForce = explosionForce;
        _scale = scale;
        _probabilitySeparation = probabilitySeparation;
        transform.localScale = Vector3.one * _scale;
        transform.position = position;
        Enable();
    }

    public void Exploid()
    {
        Exploded?.Invoke(this);
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        _rigidbody = gameObject.transform.GetComponent<Rigidbody>();
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
