using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour {

  public float rotationSpeed = 0.1f;
  public float movementSpeed = 3f;
  CharacterController characterController;

  Animator animator;

  void Start() {
    characterController = this.GetComponent<CharacterController>();
    animator = this.GetComponent<Animator>();
  }

  public void Move(Vector3 moveDirection) {
    ApplyGravity();
    characterController.Move(moveDirection.normalized * Time.deltaTime * movementSpeed);
    Animate(moveDirection.x, Mathf.Abs(moveDirection.z));
  }

  private void ApplyGravity() {
    if (!characterController.isGrounded) {
      characterController.Move(GameManager.gameManager.gravity * -1 * Time.deltaTime);
    }
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
