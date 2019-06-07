using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : LivingEntity {

  public enum State { Idle, Chasing, Attacking }
  public State currentState;
  public float delayBetweenAttacks;
  public bool canMove = true;

  [HideInInspector]
  public Transform target;
  LivingEntity targetEntity;
  public bool hasTarget;

  public float attackDistanceThreshold = .5f;
  [HideInInspector]
  public float myCollisionRadius;
  [HideInInspector]
  public float targetCollisionRadius;

  private Animator animator;

  void Awake() {
    if (GameObject.FindGameObjectWithTag("Player") != null) {
      hasTarget = true;

      target = GameObject.FindGameObjectWithTag("Player").transform;
      targetEntity = target.GetComponent<LivingEntity>();

      myCollisionRadius = GetComponent<CapsuleCollider>().radius;
      targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
    }
  }

  protected virtual void Start() {
    animator = this.GetComponent<Animator>();
  }

  public IEnumerator Attack() {
    currentState = State.Attacking;
    canMove = false;
    animator.SetTrigger("Attack");
    float timePassed = 0f;

    while (timePassed < delayBetweenAttacks) {
      timePassed += Time.deltaTime;
      yield return null;
    }
  }

  public void EndAttack() {
    currentState = State.Chasing;
  }
}