using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    public event Action<Cube> OnCubeHit;

    public void PerformRaycast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube clickedCube))
            {
                OnCubeHit?.Invoke(clickedCube);
            }
        }
    }
}
