using UnityEngine;

public class ShapeColor : MonoBehaviour
{
    [SerializeField] private ColorPalette _colorPalette;

    private MeshRenderer _meshRenderer;

    public Color Color => _meshRenderer.material.color;

    private void Start()
    {
        Color randomColor = _colorPalette.colors[Random.Range(0, _colorPalette.colors.Length)];

        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = randomColor;
    }
}
