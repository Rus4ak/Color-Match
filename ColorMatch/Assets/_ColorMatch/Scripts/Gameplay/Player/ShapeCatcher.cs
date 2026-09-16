using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ShapeCatcher : MonoBehaviour
{
    [SerializeField] private Volume _globalVolume;
    [SerializeField] private AudioClip _successSound;
    [SerializeField] private AudioClip _wrongSound;

    private MeshRenderer _basketMeshRenderer;
    private Vignette _vignette;
    private AudioSource _audioSource;

    private void Awake()
    {
        _basketMeshRenderer = GetComponent<MeshRenderer>();
        _globalVolume.profile.TryGet(out _vignette);
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out ShapeColor shapeColor))
            return;

        if (shapeColor.Color == _basketMeshRenderer.material.color)
        {
            ScoreData.Instance.ChangeScore(1);
            _audioSource.PlayOneShot(_successSound);
            StartCoroutine(ShowCatchFeedback(Color.green));
        }
        else
        {
            ScoreData.Instance.ChangeScore(-1);
            _audioSource.PlayOneShot(_wrongSound);
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
