using System.Collections.Generic;
using UnityEngine;

public class ProbabilityDivider: MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.ClickOnCube += TryDeride;
    }

    private void OnDisable()
    {
        _playerInput.ClickOnCube += TryDeride;
    }

    private void TryDeride(Cube cube)
    {
        float probabylitiValue = Random.value;
        if (probabylitiValue <= cube.Probability)
        {
            IEnumerable<Cube> newCubes =  _spawner.SpawnFromSeparate(cube);
            _exploder.ExploidCube(cube, newCubes);
        }
        else
        {
            cube.Disable();
        }
    }
}
