using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour {

  public LayerMask layerMask;
  public float damage = 15f;

  public Vector3 hitPoint;

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      Ray ray = new Ray(transform.position, -transform.forward);
      RaycastHit hit;
      if (Physics.Raycast(
          transform.position + (transform.forward * 1f), -transform.forward,
          out hit,
          4f,
          layerMask
        )) {
        hitPoint = hit.point;
        other.GetComponent<LivingEntity>().TakeHit(damage, hitPoint, transform.forward);
      }
    }
  }

  private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Ray ray = new Ray(transform.position + (transform.forward * 5f), -transform.forward);
    Gizmos.DrawRay(ray);

    Gizmos.DrawSphere(hitPoint, .2f);
  }
}