using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable {

	public delegate void TookHit(float damage, float weight, Vector3 hitPoint, Vector3 hitDirection);
	public event TookHit OnHit;

	public float damage { get; protected set; } = 0f;
	public float weight = 3f;

	public virtual void TakeHit(float _damage, Vector3 hitPoint, Vector3 hitDirection) {
		TakeDamage(_damage);
		OnHit(damage, weight, hitPoint, hitDirection);
	}

	public virtual void TakeDamage(float _damage) {
		damage += _damage;

		// if (health <= 0 && !dead) {
		// 	Die();
		// }
	}

	// public virtual void TakeKnockback(Vector3 hitPoint, Vector3 hitDirection) {
	// 	Debug.Log("Knockback");
	// 	Debug.Log(rb);
	// 	rb.AddForceAtPosition(-transform.forward * 1000f, hitPoint, ForceMode.Impulse);
	// 	// rb.AddForce(-transform.forward * 100f, ForceMode.Impulse);
	// }
}