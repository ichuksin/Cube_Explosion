using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void ExploideCube(Cube cube, IEnumerable<Cube> affectedCubes)
    {
        foreach (Cube affectedCube in affectedCubes)
            affectedCube.Rigidbody.AddExplosionForce(cube.ExplosionForce, cube.transform.position, cube.ExplosionRadius);
        
        cube.Exploid();
    }
}
