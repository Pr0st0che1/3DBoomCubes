using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosiveRadius = 2f;
    [SerializeField] private float _explosiveForce = 1f;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.CubesCreated += Explode;
    }

    private void OnDisable()
    {
        _spawner.CubesCreated -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
            explodableObjects.AddExplosionForce(_explosiveForce, transform.position, _explosiveRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosiveRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits) 
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
