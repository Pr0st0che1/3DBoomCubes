using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycast _onCubeHit;

    void Update()
    {
        float roll = Random.value;

        if (roll <= clickedCube.SplitChance)
        {

        }
    }
}
