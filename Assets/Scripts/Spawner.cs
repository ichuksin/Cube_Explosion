using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Material[] _materials;
    [SerializeField] private Pool _pool;
    [SerializeField] private PlayerInput _playerInput;

    private int _minCubes = 2;
    private int _maxCubes = 7;

    private void OnEnable()
    {
        _playerInput.ClickOnCube += SpawnFromSeparate;
    }

    private void OnDisable()
    {
        _playerInput.ClickOnCube += SpawnFromSeparate;
    }

    public void SpawnFromSeparate(Dynamite item)
    {
        float newScale = item.Scale / 2;
        float newProbability = item.Probability / 2;

        float random = Random.value;
        if (random <= item.Probability)
        {
            int countCubes = Random.Range(_minCubes, _maxCubes);
            
            for (int i = 0; i < countCubes; i++)
                Spawn(newScale, newProbability, item.transform.position);
        }
    }

    private void Spawn(float scale, float probability, Vector3 position)
    {
        Dynamite dinamite = _pool.GetObject();
        GameObject gameObject = dinamite.gameObject;

        dinamite.Init(scale, probability);
        Vector3 newPosition = position + Random.onUnitSphere;
        gameObject.transform.position = newPosition;
        Material material = _materials[Random.Range(0,_materials.Length)];
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = material;
        gameObject.SetActive(true);

        Rigidbody rigidbody = gameObject.transform.GetComponent<Rigidbody>();
        rigidbody.AddExplosionForce(_explosionForce, position, _explosionRadius);
    }

}
