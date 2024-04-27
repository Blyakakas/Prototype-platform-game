using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Rigidbody))]
public class Platform : MonoBehaviour, IDieable
{
    [SerializeField] private GameObject _coin;

    [SerializeField] private Transform _leftAnchor;
    [SerializeField] private Transform _forwardAnchor;
    [SerializeField] private float _yDieZone;

    private int _coinRarity = 5;
    private Rigidbody _rigidbody;

    public static Action OnScoreAdded;

    private void Start()
    {
        _rigidbody  = GetComponent<Rigidbody>();

        if (UnityEngine.Random.Range(0, _coinRarity) == 1)
            _coin.SetActive(true);
    }

    private void Update()
    {
        CheckForDeath();
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerMovement player))
        {
            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;
            OnScoreAdded?.Invoke();
        }
    }

    public Transform GetRandomAnchor()
    {
        return UnityEngine.Random.Range(0,2) == 1 ? _leftAnchor : _forwardAnchor;
    }

    public void CheckForDeath()
    {
        if (transform.position.y <= _yDieZone)
            Destroy(gameObject);
    }
}
