using UnityEngine;

public class BackGroundFollow : MonoBehaviour
{

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position;
        transform.position = targetPosition;
    }
}