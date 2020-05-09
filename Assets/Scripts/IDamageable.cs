using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
  void TakeHit(float _damage, Vector3 hitPoint, Vector3 hitDirection);
  void TakeDamage(float _damage);
  // void TakeKnockback(Vector3 hitPoint, Vector3 hitDirection);
}