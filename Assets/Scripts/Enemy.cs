using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : LivingEntity {

  public enum State {Idle, Chasing, Attacking};
  State currentState;
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

  void Awake() {
    if (GameObject.FindGameObjectWithTag ("Player") != null) {
			hasTarget = true;
			
			target = GameObject.FindGameObjectWithTag ("Player").transform;
			targetEntity = target.GetComponent<LivingEntity> ();
			
			myCollisionRadius = GetComponent<CapsuleCollider>().radius;
			targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
		}
  }

  protected virtual void Start() {
    animator = this.GetComponent<Animator>();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.M)) {
      // animator.SetFloat("HitValue", Random.Range(0, 2));
      // animator.SetTrigger("Hit");
      StartCoroutine("Attack");
    }
  }
  
  public IEnumerator Attack() {
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
