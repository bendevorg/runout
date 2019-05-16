using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

  private float inputX;
	private float inputZ;
	Vector3 moveDirection;

	public float rotationSpeed = 0.1f;
  public int movementSpeed = 5;

	public Camera playerCamera;

  private Animator animator;
	private CharacterController characterController;

  [HideInInspector]
  public bool canMove = true;

	void Start () {
    //  TODO: Remove this and put in a future game manager
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;

		animator = this.GetComponent<Animator>();
		playerCamera = Camera.main;
		characterController = this.GetComponent<CharacterController>();
	}
	
	void Update () {
    if (canMove) {
		  ReadInput();
      CalculateMovementIntent();
      Move();
      Rotate();
      Animate();
    }
	}

	private void ReadInput() {
		inputX = Input.GetAxis("Horizontal");
		inputZ = Input.GetAxis("Vertical");
	}

  private void CalculateMovementIntent() {
    //  Here I use camera as a base so the character always use the current
    //  point of view to move
    Vector3 forward = playerCamera.transform.forward;
		Vector3 right = playerCamera.transform.right;
    forward.y = 0;
    right.y = 0;

		moveDirection = forward.normalized * inputZ + right.normalized * inputX;
  }

	private void Move() {
    characterController.Move(moveDirection.normalized * Time.deltaTime * movementSpeed);
	}

  private void Rotate() {
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed);
  }

  private void Animate() {
    animator.SetFloat("Speed", moveDirection.sqrMagnitude);
  }
}
