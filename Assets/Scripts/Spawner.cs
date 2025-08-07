using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private Pool _pool;
    private List<Dynamite> _newCubes = new List<Dynamite>();

    private int _maxCubes = 7;
    private int _minCubes = 2;

    public IEnumerable<Dynamite> SpawnFromSeparate(Dynamite item)
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

    private Dynamite Spawn(float scale, float probability, Vector3 position)
    {
        Dynamite dinamite = _pool.GetObject();

        Vector3 newPosition = position + Random.onUnitSphere;
        dinamite.Init(scale, probability, newPosition, _materials[Random.Range(0, _materials.Length)]);
        return dinamite;
    }
}
