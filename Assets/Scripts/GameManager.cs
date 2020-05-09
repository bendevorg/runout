using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager gameManager = null;

  void Awake() {
    if (gameManager != null) {
      Destroy(gameObject);
    } else {
      gameManager = this;
      DontDestroyOnLoad(gameObject);
    }
  }
}
