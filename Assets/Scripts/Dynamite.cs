using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Dynamite : MonoBehaviour, IExposable
{
    [SerializeField] private float _scale;
    [SerializeField] private float _probabilitySeparation;
    
    public float Probability => _probabilitySeparation;
    public float Scale => _scale;

    public void Init(float scale, float probabilitySeparation)
    {
        _scale = scale;
        _probabilitySeparation = probabilitySeparation;
        transform.localScale = Vector3.one * _scale;
    }

    public void Explosion()
    {
        gameObject.SetActive(false);    
    }
 }
