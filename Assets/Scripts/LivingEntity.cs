using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable {

	public delegate void TookHit(float _damage, Vector3 hitPoint, Vector3 hitDirection);
	public event TookHit OnHit;

	public float damage { get; protected set; }

	public virtual void TakeHit(float _damage, Vector3 hitPoint, Vector3 hitDirection) {
		TakeDamage(_damage);
		OnHit(_damage, hitPoint, hitDirection);
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