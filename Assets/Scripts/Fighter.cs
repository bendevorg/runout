using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Fighter : Enemy {

  Vector3 moveDirection;
  EnemyMovement movement;

  protected override void Start() {
    base.Start();
    movement = this.GetComponent<EnemyMovement>();
  }

  void FixedUpdate() {
    if (hasTarget) {
      float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
      if (currentState != State.Attacking &&
        sqrDstToTarget < Mathf.Pow(attackDistanceThreshold + myCollisionRadius + targetCollisionRadius, 2)
      ) {
        StartCoroutine(Attack());
      } else if (currentState != State.Attacking) {
        moveDirection = (target.position - transform.position).normalized;
        movement.Move(moveDirection);
      }
      movement.Rotate(target.position);
    }
  }
}