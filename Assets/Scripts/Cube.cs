using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Cube : MonoBehaviour
{
    [SerializeField] private float _scale;
    [SerializeField] private float _probabilitySeparation;
    [SerializeField] private CubeRenderer _cubeRenderer;

    private Rigidbody _rigidbody;
    
    public float Probability => _probabilitySeparation;
    public float Scale => _scale;
    public Rigidbody Rigidbody => _rigidbody;
    public CubeRenderer CubeRenderer => _cubeRenderer;

    private void Awake()
    {
        _rigidbody = gameObject.transform.GetComponent<Rigidbody>();
    }

    public void Init(float scale, float probabilitySeparation, Vector3 position)
    {
        _scale = scale;
        _probabilitySeparation = probabilitySeparation;
        transform.localScale = Vector3.one * _scale;
        transform.position = position;
        Enable();
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
