using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private Pool _pool;
    private List<Cube> _newCubes = new List<Cube>();

    private int _maxCubes = 7;
    private int _minCubes = 2;

    public IEnumerable<Cube> SpawnFromSeparate(Cube item)
    {
        _newCubes.Clear();
        float newScale = item.Scale / 2;
        float newProbability = item.Probability / 2;

        int countCubes = Random.Range(_minCubes, _maxCubes);
            
        for (int i = 0; i < countCubes; i++)
        {
            _newCubes.Add(  Spawn(newScale, newProbability, item.transform.position));
        }
        return _newCubes;
    }

    private Cube Spawn(float scale, float probability, Vector3 position)
    {
        Cube cube = _pool.GetObject();

        Vector3 newPosition = position + Random.onUnitSphere;
        cube.CubeRenderer.SetMaterial(_materials[Random.Range(0, _materials.Length)]);
        cube.Init(scale, probability, newPosition);
        return cube;
    }
}
