using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Handler _handler;

    public event Action<Cube> CubeCreated;

    private void OnEnable()
    {
        _handler.CubeSplitted += SpawnCubes;
    }

    private void OnDisable()
    {
        _handler.CubeSplitted -= SpawnCubes;
    }

    private void SpawnCubes (Cube cube)
    {
        int cubesAmount = UnityEngine.Random.Range(2, 7);
        int decressFactor = 2;
        float newSplitChance = cube.SplitChance / decressFactor;

        for (int i = 0; i < cubesAmount; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);
            newCube.Init(newSplitChance);
        }
    }
}
