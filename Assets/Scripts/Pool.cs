using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private Queue<Cube> _cubess = new Queue<Cube>();

    public Cube GetObject()
    {
        Cube cube;
        if (_cubess.Count == 0)
        {
            cube = Instantiate(_prefab);
        }
        else
        {
            cube = _cubess.Dequeue();
        }
        return cube;
    }

    public void Release(Cube dynamite)
    {
        _cubess.Enqueue(dynamite);
    }
}
