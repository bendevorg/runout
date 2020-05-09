using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour {

  public float rotationSpeed = 0.1f;
  public float movementSpeed = 3f;
  Rigidbody rb;

  Animator animator;

  void Start() {
    rb = this.GetComponent<Rigidbody>();
    animator = this.GetComponent<Animator>();
  }

  public void Move(Vector3 moveDirection) {
    rb.MovePosition(transform.position + (moveDirection.normalized * Time.deltaTime * movementSpeed));
    Animate(moveDirection.x, Mathf.Abs(moveDirection.z));
  }

  public void Rotate(Vector3 target) {
    // transform.rotation = Quaternion.Lerp(
    //   transform.rotation, 
    //   new Quaternion(0, playerCamera.transform.rotation.y, 0, playerCamera.transform.rotation.w),
    //   rotationSpeed
    // );
    transform.LookAt(target, Vector3.up);
  }

  private void Animate(float inputX, float inputY) {
    animator.SetFloat("SpeedX", inputX);
    animator.SetFloat("SpeedY", inputY);
  }
}