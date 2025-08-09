using System.Collections.Generic;
using UnityEngine;

public class ProbabilityDivider: MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private ExploideAffect _exploideAffect;

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

        IEnumerable<Cube> affectedCubes ;

        if (probabylitiValue <= cube.Probability)
            affectedCubes =  _spawner.SpawnFromSeparate(cube);
        else
            affectedCubes = _exploideAffect.GetAffected(cube);

        _exploder.ExploideCube(cube, affectedCubes);
    }
}
