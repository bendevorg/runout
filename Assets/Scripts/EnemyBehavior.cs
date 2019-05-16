using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyBehavior : MonoBehaviour {

  private Animator animator;

  void Start() {
    animator = this.GetComponent<Animator>();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.M)) {
      animator.SetFloat("HitValue", Random.Range(0, 2));
      animator.SetTrigger("Hit");
    }
  }
}
