using UnityEngine;

public class ShapeDestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ShapeColor>(out _))
        {
            Destroy(other.gameObject);
        }
    }
}
