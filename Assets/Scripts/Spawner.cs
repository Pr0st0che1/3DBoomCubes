using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Controller _controller;

    public event Action CubesCreated;

    private void OnEnable()
    {
        _controller.CubeSplitted += SpawnCubes;
    }

    private void OnDisable()
    {
        _controller.CubeSplitted -= SpawnCubes;
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
