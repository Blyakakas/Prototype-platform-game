using System.Collections;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] private float _minSizeX;
    [SerializeField] private float _minSizeZ;
    [SerializeField] private Vector3 _increaseSize;
    [SerializeField] private int sizeChangeScore = 10;
    [SerializeField] private float _generationDelay;

    [SerializeField] private Platform _platform;
    [SerializeField] private Platform _currentPlatform;

    private void Awake()
    {
        StartCoroutine(Generate());
    }
    private IEnumerator Generate()
    {
        Platform newPlatform = Instantiate(_platform, _currentPlatform.GetRandomAnchor().position, Quaternion.identity);
        _currentPlatform = newPlatform;
        yield return new WaitForSeconds(_generationDelay);
        StartCoroutine(Generate());
    }
}
