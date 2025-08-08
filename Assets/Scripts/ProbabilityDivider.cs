using System.Collections.Generic;
using UnityEngine;

public class ProbabilityDivider: MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.ClickOnCube += TryDevide;
    }

    private void OnDisable()
    {
        _raycaster.ClickOnCube += TryDevide;
    }

    private void TryDevide(Cube cube)
    {
        float probabylitiValue = Random.value;

        IEnumerable<Cube> newCubes = new List<Cube>();

        if (probabylitiValue <= cube.Probability)
            newCubes =  _spawner.SpawnFromSeparate(cube);
 
        _exploder.ExploideCube(cube, newCubes);
    }
}
