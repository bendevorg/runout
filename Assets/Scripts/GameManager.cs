using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager gameManager = null;
  public Vector3 gravity;

  void Awake() {
    if (gameManager != null) {
      Destroy(gameObject);
    } else {
      gameManager = this;
      DontDestroyOnLoad(gameObject);
    }
  }
}
