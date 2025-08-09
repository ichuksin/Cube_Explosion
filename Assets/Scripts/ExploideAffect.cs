using System.Collections.Generic;
using UnityEngine;

public class ExploideAffect : MonoBehaviour
{
    public IEnumerable<Cube> GetAffected(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, cube.ExplosionRadius);

        List<Cube> cubes = new List<Cube>();

        foreach (Collider hit in hits)
            if (hit.TryGetComponent<Cube>(out Cube affectedCube))
                cubes.Add(affectedCube);

        return cubes;    
    }
}
