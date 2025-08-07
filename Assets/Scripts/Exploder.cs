using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.ClickOnCube += ExploidCube;
    }

    private void OnDisable()
    {
        _playerInput.ClickOnCube += ExploidCube;
    }

    private void ExploidCube(Dynamite dynamite)
    {
        dynamite.Exploid();
        _pool.Release(dynamite);
    }
}
