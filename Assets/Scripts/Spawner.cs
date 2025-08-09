using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private Pool _pool;
    [SerializeField] private List<Cube> _ñubes ;

    private Cube[] _newCubes = new Cube[6];

    private int _maxCubes = 6;
    private int _minCubes = 2;

    private float _divideScale = 2.0f;
    private float _divideProbability = 2.0f;
    private float _multipleRadius = 1.5f;
    private float _multipleForce = 2.0f;

    private void OnEnable()
    {
        foreach (Cube cube in _ñubes)
            cube.Exploded += Release;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _ñubes)
            cube.Exploded -= Release;
    }

    public IEnumerable<Cube> SpawnFromSeparate(Cube item)
    {
        float newScale = item.Scale / _divideScale;
        float newProbability = item.Probability / _divideProbability;
        float newRadius = item.ExplosionRadius * _multipleRadius;
        float newForce = item.ExplosionForce * _multipleForce;

        int countCubes = Random.Range(_minCubes, _maxCubes + 1);
            
        for (int i = 0; i < countCubes; i++)
        {
            _newCubes[i] =  Spawn(newScale, newProbability, newRadius, newForce, item.transform.position);
            _newCubes[i].Exploded += Release;
            _ñubes.Add(_newCubes[i]);
        }

        for (int i = countCubes; i < _maxCubes; i++)
            _newCubes[i] = null;

        return _newCubes.NotNull();
    }

    private void Release(Cube cube)
    {
        cube.Exploded -= Release;
        _ñubes.Remove(cube);
        _pool.Release(cube);     
    }

    private Cube Spawn(float scale, float probability, float radius, float force, Vector3 position)
    {
        Cube cube = _pool.GetObject();

        Vector3 newPosition = position + Random.onUnitSphere;
        cube.CubeRenderer.SetMaterial(_materials[Random.Range(0, _materials.Length)]);
        cube.Init(scale, probability, radius, force, newPosition);
        return cube;
    }
}
