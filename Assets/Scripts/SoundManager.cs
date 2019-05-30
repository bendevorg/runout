using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
  private float volLowRange = .5f;
  private float volHighRange = .85f;
  private float lowPitchRange = .95f;
  private float highPitchRange = 1.05f;
  public AudioSource source;
  // Start is called before the first frame update
  void Start() {
    source = this.GetComponent<AudioSource>();
  }

  void PlayFootsteps(string clipName) {
    // source.pitch = Random.Range(lowPitchRange, highPitchRange);
    float vol = Random.Range(volLowRange, volHighRange);
    AudioClip footstep = Resources.Load<AudioClip>("Sounds/" + clipName);
    source.PlayOneShot(footstep, vol);
  }

}