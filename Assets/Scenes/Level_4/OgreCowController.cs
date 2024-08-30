using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreCowController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private AnimationCurve _movementStability;
    [SerializeField] private float _maxStepUpHeight;
    [SerializeField] private float _maxStepDownHeight;
    [SerializeField] private int _groundSamples;
    [SerializeField] private float _obstacleOffset;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _obstacleLayerMask;

    private void Update()
    {
        var targetMovement = transform.position - _player.transform.position;
        targetMovement.y = 0;
        var targetMovementMagnitude = targetMovement.magnitude;
        targetMovement /= targetMovementMagnitude;

        targetMovement *= _movementSpeed * Time.deltaTime;

        var targetPosition = transform.position;

        var targetRating = float.MaxValue;

        var movementStability = _movementStability.Evaluate(targetMovementMagnitude);
        
        if (CheckMovementDirection(targetMovement, out var hitPosition))
        {
            targetPosition = hitPosition;
            targetRating = Vector3.Angle(targetMovement, transform.forward) * movementStability;
        }

        for (int i = 1; i <= _groundSamples; i++)
        {
            var angle = i / (_groundSamples + 1f);
            angle *= 180f;

            var rightCheck = Quaternion.Euler(0f, angle, 0f) * targetMovement;
            var rightRating = angle + Vector3.Angle(rightCheck, transform.forward) * movementStability;

            if (rightRating < targetRating && CheckMovementDirection(rightCheck, out hitPosition))
            {
                targetPosition = hitPosition;
                targetRating = rightRating;
            }

            var leftCheck = Quaternion.Euler(0f, -angle, 0f) * targetMovement;
            var leftRating = angle + Vector3.Angle(leftCheck, transform.forward) * movementStability;

            if (leftRating < targetRating && CheckMovementDirection(leftCheck, out hitPosition))
            {
                targetPosition = hitPosition;
                targetRating = leftRating;
            }
        }

        var lookDirection = targetPosition - transform.position;
        lookDirection.y = 0;
        lookDirection.Normalize();

        if (lookDirection.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        transform.position = targetPosition;
    }

    private bool CheckMovementDirection(Vector3 movement, out Vector3 hitPosition)
    {
        hitPosition = Vector3.zero;
        
        var origin = transform.position + movement + Vector3.up * _maxStepUpHeight;

        if (Physics.Raycast(origin, Vector3.down, out var hit, _maxStepUpHeight + _maxStepDownHeight, _groundLayerMask))
        {
            if (!Physics.Raycast(transform.position + Vector3.up * _obstacleOffset, (hit.point - transform.position).normalized, Vector3.Distance(transform.position, hit.point) + 1e-2f, _obstacleLayerMask))
            {
                hitPosition = hit.point;
            
                return true;
            }
        }

        return false;
    }
}
