using UnityEngine;

public class ShapeCatcher : MonoBehaviour
{
    private MeshRenderer _basketMeshRenderer;

    private void Awake()
    {
        _basketMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out ShapeColor shapeColor))
            return;

        if (shapeColor.Color == _basketMeshRenderer.material.color)
            ScoreData.Instance.ChangeScore(1);
        else
            ScoreData.Instance.ChangeScore(-1);

        Destroy(other.gameObject);
    }
}
