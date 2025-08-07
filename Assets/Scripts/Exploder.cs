using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    public void ExploidCube(Dynamite dynamite, IEnumerable<Dynamite> affectedCubes)
    {
        dynamite.Exploid(affectedCubes);
        _pool.Release(dynamite);
    }
    
    public void ExploidCube(Dynamite dynamite)
    {
        dynamite.Exploid();
        _pool.Release(dynamite);
    }
}
