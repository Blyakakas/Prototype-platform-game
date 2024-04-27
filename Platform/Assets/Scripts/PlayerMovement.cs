using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IDieable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yDieZone;
    [SerializeField] private float _decreaseSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedAddDelay;

    private bool _isForwardDirection = true;

    private void Start()
    {
            StartCoroutine(SpeedChange());
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            ChangeDirection();
        Move();
        CheckForDeath();
    }
    private IEnumerator SpeedChange()
    {
        _speed += _decreaseSpeed;
        yield return new WaitForSeconds(_speedAddDelay);
        if(_speed < _maxSpeed)
            StartCoroutine(SpeedChange());
    }

    public void CheckForDeath()
    {
        if(transform.position.y <= _yDieZone)
            SceneManager.LoadScene(0);
    }

    private void ChangeDirection()
    {
        _isForwardDirection = !_isForwardDirection;
    }

    private void Move()
    {
        Vector3 direction = _isForwardDirection ? transform.forward : -transform.right;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}

