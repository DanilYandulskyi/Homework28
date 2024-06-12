using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Mover))]
public class EnemyTarget : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    [SerializeField] private Vector3 _direction = Vector3.right;

    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();

        StartCoroutine(Rotate());
    }

    private void Update()
    {
        _mover.MoveInDirection(_direction);
    }

    public IEnumerator Rotate()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_waitTime);

        while (gameObject.activeSelf)
        {
            yield return waitTime;
            _direction = -_direction;
        }
    }
}