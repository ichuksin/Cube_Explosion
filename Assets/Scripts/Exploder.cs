using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Pool _pool;

    public void ExploidCube(Cube cube, IEnumerable<Cube> affectedCubes)
    {
        foreach (Cube affectedCube in affectedCubes)
        {
            affectedCube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
        
        cube.Disable();
        _pool.Release(cube);
    }
}
