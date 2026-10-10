using System;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> CubeSplitted;

    private void OnEnable()
    {
        _raycaster.OnCubeHit += IsSplitted;
    }

    private void OnDestroy()
    {
        _raycaster.OnCubeHit -= IsSplitted;
    }

    private void IsSplitted(Cube cube)
    {
        float roll = UnityEngine.Random.value;

        if (roll <= cube.SplitChance)
        {
            CubeSplitted?.Invoke(cube);
            Destroy(cube);
        }
        else
        {
            Destroy(cube);
        }
    }
}
