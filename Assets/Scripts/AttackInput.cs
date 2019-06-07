using UnityEngine;

public class AttackInput : MonoBehaviour {

  private Animator animator;

  private bool pressedAttack;

  [HideInInspector]
  public bool canAttack = true;
  public SphereCollider punchHitbox;

  private void Start() {
    animator = this.GetComponent<Animator>();
  }

  void Update() {
    ReadInput();

    if (pressedAttack && canAttack) {
      Attack();
    }
  }

  private void ReadInput() {
    pressedAttack = Input.GetButton("Fire1");
  }

  private void Attack() {
    canAttack = false;
    animator.SetTrigger("Attack");
  }

  // Triggered by animation event
  private void CreateAttackHitbox() {
    punchHitbox.enabled = true;
  }

  // Triggered by animation event
  private void DestroyAttackHitbox() {
    punchHitbox.enabled = false;
  }

  // Triggered by animation event
  private void EndAttack() {
    Debug.Log("end attack");
    canAttack = true;
  }
}
