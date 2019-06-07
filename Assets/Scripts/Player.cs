using UnityEngine;

public class Player : LivingEntity {

  Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.G)) {
      Debug.Log("Fly");
      rb.AddForce(-Vector3.forward * 5000f, ForceMode.Impulse);
    }
  }
}