using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;

    public float SplitChance => _splitChance;

    public void Init(float newChance)
    {
        _splitChance = newChance;
    }
}
