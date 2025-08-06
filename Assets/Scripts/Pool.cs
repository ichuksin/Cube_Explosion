using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Dynamite _prefab;

    private Queue<Dynamite> _pools = new Queue<Dynamite>();

    public Dynamite GetObject()
    {
        Dynamite dynamite;
        if (_pools.Count == 0)
        {
            dynamite = Instantiate(_prefab);
        }
        else
        {
            dynamite = _pools.Dequeue();
        }
        return dynamite;
    }

    public void Release(Dynamite dynamite)
    {
        dynamite.gameObject.SetActive(false);
        _pools.Enqueue(dynamite);
    }
}
