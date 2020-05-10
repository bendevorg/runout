using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
// [RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class MovementInput : MonoBehaviour {

  private float inputX;
  private float inputZ;
  private bool jump;
  Vector3 moveDirection;

  public float rotationSpeed = 0.1f;
  public int movementSpeed = 5;
  public int jumpForce = 5;

  public Camera playerCamera;

  private Animator animator;
  private Rigidbody rb;
  private LivingEntity livingEntity;
  private CapsuleCollider collider;

  [HideInInspector]
  public bool canMove = true;

  void Start() {
    //  TODO: Remove this and put in a future game manager
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;

    animator = this.GetComponent<Animator>();
    playerCamera = Camera.main;
    rb = this.GetComponent<Rigidbody>();
    livingEntity = this.GetComponent<LivingEntity>();
    livingEntity.OnHit += Knockback;
    collider = this.GetComponent<CapsuleCollider>();
  }

  void Update() {
    if (canMove) {
      ReadInput();
      CalculateMovementIntent();
    }
  }

  void FixedUpdate() {
    if (canMove) {
      Move();
      Rotate();
      Animate();
    }
  }

  private void ReadInput() {
    inputX = Input.GetAxis("Horizontal");
    inputZ = Input.GetAxis("Vertical");
    jump = Input.GetKeyDown(KeyCode.Space);
  }

  private bool IsGrounded() {
    return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
  }

  private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Ray ray = new Ray(transform.position, -Vector3.up * 0.1f);
    Gizmos.DrawRay(ray);
  }

  private void CalculateMovementIntent() {
    //  Here I use camera as a base so the character always use the current
    //  point of view to move
    Vector3 forward = playerCamera.transform.forward;
    Vector3 right = playerCamera.transform.right;
    forward.y = 0;
    right.y = 0;

    moveDirection = forward.normalized * inputZ + right.normalized * inputX;
    if (jump && IsGrounded()) {
      animator.SetTrigger("Jump");
      Jump();
    }
  }

  private void Move() {
    rb.MovePosition(transform.position + (moveDirection.normalized * Time.deltaTime * movementSpeed));
  }

  private void Rotate() {
    transform.rotation = Quaternion.Lerp(
      transform.rotation,
      new Quaternion(0, playerCamera.transform.rotation.y, 0, playerCamera.transform.rotation.w),
      rotationSpeed
    );
  }

  private void Jump() {
    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
  }

  public void Knockback(float damage, float weight, Vector3 hitPoint, Vector3 hitDirection) {
    rb.AddForceAtPosition((damage / 2.75f) * new Vector3(hitDirection.x / weight, .15f / weight, hitDirection.z / weight), hitPoint, ForceMode.Impulse);
  }

  private void Animate() {
    animator.SetFloat("SpeedX", inputX);
    animator.SetFloat("SpeedY", inputZ);
  }
}
