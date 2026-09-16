using System.Collections;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private ColorPalette _colorPalette;
    [SerializeField] private float _defaultChangeInterval = 5f;
    
    private MeshRenderer _meshRenderer;
    private float _changeInterval;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _changeInterval = Mathf.Clamp(
            Random.Range(_defaultChangeInterval - 2, _defaultChangeInterval + 2),
            1, 
            10);

        StartCoroutine(ChangeColor());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            Color startColor = _meshRenderer.material.color;
            Color randomColor = _colorPalette.colors[Random.Range(0, _colorPalette.colors.Length)];
            float time = 0f;
            float duration = .2f;

            while (time < duration)
            {
                time += Time.deltaTime;

                float t = time / duration;

                _meshRenderer.material.color = Color.Lerp(startColor, randomColor, t);

                yield return null;
            }

            _meshRenderer.material.color = randomColor;

            yield return new WaitForSeconds(_changeInterval);
        }
    }
}
