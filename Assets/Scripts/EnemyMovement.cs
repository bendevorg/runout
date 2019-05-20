using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyMovement : MonoBehaviour {

  public float rotationSpeed = 0.1f;
  public float movementSpeed = 3f;
  CharacterController characterController;

  void Start() {
    characterController = this.GetComponent<CharacterController>();
  }

  public void Move(Vector3 moveDirection) {
    characterController.Move(moveDirection.normalized * Time.deltaTime * movementSpeed);
	}

  public void Rotate(Vector3 target) {
    // transform.rotation = Quaternion.Lerp(
    //   transform.rotation, 
    //   new Quaternion(0, playerCamera.transform.rotation.y, 0, playerCamera.transform.rotation.w),
    //   rotationSpeed
    // );
    transform.LookAt(target, Vector3.up);
  }
}
