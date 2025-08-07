using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Dynamite : MonoBehaviour, IExplodibal
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _scale;
    [SerializeField] private float _probabilitySeparation;
    [SerializeField] private MeshRenderer _renderer;
    
    private Rigidbody _rigidbody;
    private bool _IsInitialized = false;
    public float Probability => _probabilitySeparation;
    public float Scale => _scale;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = gameObject.transform.GetComponent<Rigidbody>();
    }
    public void Init(float scale, float probabilitySeparation, Vector3 position, Material material)
    {
        _scale = scale;
        _probabilitySeparation = probabilitySeparation;
        transform.localScale = Vector3.one * _scale;
        transform.position = position;
        
        _renderer.material = material;
        
        _IsInitialized = true;
        
        gameObject.SetActive(true);
    }
    public void TakeExplosivePower(float explosionForce,Vector3 position, float explosionRadius)
    {
        if (_IsInitialized)
        {
            _rigidbody.AddExplosionForce(explosionForce, position, explosionRadius);
            _IsInitialized = false;
        }
    }

    public void Exploid(IEnumerable<Dynamite> affectedCubes)
    {
        foreach (Dynamite dynamite in affectedCubes)
        {
            dynamite.TakeExplosivePower(_explosionForce, transform.position, _explosionRadius);
        }
        gameObject.SetActive(false);    
    }
    
    public void Exploid()
    {
        gameObject.SetActive(false);
    }
}
