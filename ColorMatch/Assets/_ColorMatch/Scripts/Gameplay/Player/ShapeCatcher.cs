using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ShapeCatcher : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private MeshRenderer _basketMeshRenderer;
    private Vignette _vignette;

    private void Awake()
    {
        _basketMeshRenderer = GetComponent<MeshRenderer>();
        _volume.profile.TryGet(out _vignette);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out ShapeColor shapeColor))
            return;

        if (shapeColor.Color == _basketMeshRenderer.material.color)
        {
            ScoreData.Instance.ChangeScore(1);
            StartCoroutine(ShowCatchFeedback(Color.green));
        }
        else
        {
            ScoreData.Instance.ChangeScore(-1);
            StartCoroutine(ShowCatchFeedback(Color.red));
        }

        Destroy(other.gameObject);
    }

    private IEnumerator ShowCatchFeedback(Color color)
    {
        _vignette.color.value = color;

        yield return new WaitForSeconds(.1f);

        _vignette.color.value = Color.white;
    }
}
