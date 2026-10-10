using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    public event Action<Cube> OnCubeHit;

    private void OnEnable()
    {
        _inputReader.MouseClicked += PerformRaycast;
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= PerformRaycast;
    }

    public void PerformRaycast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube clickedCube))
            {
                OnCubeHit?.Invoke(clickedCube);
                Debug.Log("Попадание");
            }
        }
    }
}
