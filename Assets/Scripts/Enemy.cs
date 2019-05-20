using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : LivingEntity {

  public enum State {Idle, Chasing, Attacking};
  State currentState;

  public float delayBetweenAttacks;

  private Animator animator;

  void Start() {
    animator = this.GetComponent<Animator>();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.M)) {
      // animator.SetFloat("HitValue", Random.Range(0, 2));
      // animator.SetTrigger("Hit");
      StartCoroutine("Attack");
    }
  }
  
  IEnumerator Attack() {
    currentState = State.Attacking;
    animator.SetTrigger("Attack");
    float timePassed = 0f;

    while (timePassed < delayBetweenAttacks) {
      timePassed += Time.deltaTime;
      yield return null;
    }

    currentState = State.Chasing;
  }

}
