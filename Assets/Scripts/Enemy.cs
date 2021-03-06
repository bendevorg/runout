﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : LivingEntity {

  public enum State { Idle, Chasing, Attacking }
  public State currentState;
  public float delayBetweenAttacks;

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

  public Weapon weapon;

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
    animator.SetTrigger("Attack");
    weapon.attackTrails.SetActive(true);
    float timePassed = 0f;

    while (timePassed < delayBetweenAttacks) {
      timePassed += Time.deltaTime;
      yield return null;
    }
  }

  public void activateWeaponCollider() {
    weapon.collider.enabled = true;
  }

  public void EndAttack() {
    currentState = State.Chasing;
    weapon.collider.enabled = false;
    weapon.attackTrails.SetActive(false);
  }
}