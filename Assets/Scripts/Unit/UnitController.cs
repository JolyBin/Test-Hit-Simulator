using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityStandardAssets.Characters.ThirdPerson;

public class UnitController : MonoBehaviour
{
    [SerializeField] Waypoint[] _waypoints;
    [SerializeField] Rigidbody[] _rigidbodiesOnRagdoll;
    [SerializeField] GameObject _ragdollAvatar;
    [SerializeField] UnityEvent _onEndedWaypointsEvent;
    int _currentPointIndex = 0;
    Quaternion _rotation;

    NavMeshAgent _agent;
    ThirdPersonCharacter _character;

    void Start()
    {
        _rotation = transform.rotation;
        _agent = GetComponent<NavMeshAgent>();
        _character = GetComponent<ThirdPersonCharacter>();
        _agent.updateRotation = false;
    }

    void Update()
    {
        if (_agent.remainingDistance > _agent.stoppingDistance)
        {
            _character.Move(_agent.desiredVelocity, false, false);

        }
        else
        {
            _character.Move(Vector3.zero, false, false);

        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, Time.deltaTime * 5);
    }

    void SetStateRagdoll(bool value)
    {
        _ragdollAvatar.SetActive(value);
        foreach (Rigidbody rigidbody in _rigidbodiesOnRagdoll)
        {
            rigidbody.isKinematic = !value;
        }
    }

    [ContextMenu("׃לנט")]
    public void Die()
    {
        _agent.enabled = false;
        _character.enabled = false;
        this.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        SetStateRagdoll(true);
    }

    [ContextMenu("ָהט")]
    public void MoveToNextPoint()
    {
        Transform nextTransform = _waypoints[_currentPointIndex].transform;
        _agent.SetDestination(nextTransform.position);
        _rotation = nextTransform.rotation;
        _currentPointIndex++;
        if(_currentPointIndex >= _waypoints.Length)
        {
            _onEndedWaypointsEvent.Invoke();
        }
    }

    public void RestartWaypoints()
    {
        _currentPointIndex = 0;
        MoveToNextPoint();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, _waypoints[0].transform.position);
        for (int i = 0; i < _waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(_waypoints[i].transform.position, _waypoints[i + 1].transform.position);
        }
    }
}
