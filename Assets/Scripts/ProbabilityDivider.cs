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

    private void TryDeride(Dynamite dynamite)
    {
        float probabylitiValue = Random.value;
        if (probabylitiValue <= dynamite.Probability)
        {
            IEnumerable<Dynamite> newDynamits =  _spawner.SpawnFromSeparate(dynamite);
            _exploder.ExploidCube(dynamite, newDynamits);
        }
        else
        {
            _exploder.ExploidCube(dynamite);
        }
    }
}
