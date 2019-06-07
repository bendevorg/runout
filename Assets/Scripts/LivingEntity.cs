using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LivingEntity : MonoBehaviour, IDamageable {

	Rigidbody rb;

	void Start() {
		rb = this.GetComponent<Rigidbody>();
	}

	public float damage { get; protected set; }

	public virtual void TakeHit(float _damage, Vector3 hitPoint, Vector3 hitDirection) {
		TakeDamage(_damage);
		TakeKnockback(hitPoint, hitDirection);
	}

	public virtual void TakeDamage(float _damage) {
		damage += _damage;

		// if (health <= 0 && !dead) {
		// 	Die();
		// }
	}

	public virtual void TakeKnockback(Vector3 hitPoint, Vector3 hitDirection) {
		Debug.Log("Knockback");
		// rb.AddForceAtPosition(-transform.forward * 1000f, hitPoint, ForceMode.Impulse);
		// rb.AddForce(-transform.forward * 100f, ForceMode.Impulse);
	}
}