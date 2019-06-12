using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundManager : MonoBehaviour {
    private AudioSource source;
    private AudioClip[] footstepsR;
    private AudioClip[] footstepsL;
    private AudioClip Footstep;
    private MovementInput movement;
    private float pitchOffset;
    private string lastSide;
    private float lowPitchRange = 1F;
    private float highPitchRange = 1.15F;
    private float lowVolRange = .10F;
    private float highVolRange = .20F;

    // Start is called before the first frame update
    void Start() {
        source = this.GetComponent<AudioSource>();
        footstepsR = Resources.LoadAll<AudioClip>("Sounds/Movement/Footsteps/Player/R");
        footstepsL = Resources.LoadAll<AudioClip>("Sounds/Movement/Footsteps/Player/L");
        movement = this.GetComponent<MovementInput>();
        lastSide = "R";
    }
    void PlayFootstep(string side) {
        if (!source.isPlaying || lastSide != side) {
            if (side == "R") {
                Footstep = footstepsR[Random.Range(0, footstepsR.Length)];
            } else {
                Footstep = footstepsL[Random.Range(0, footstepsL.Length)];
            }
            float pitchOffset = (movement.movementSpeed / 5);
            Debug.Log(pitchOffset);
            source.pitch = Random.Range(pitchOffset * lowPitchRange, pitchOffset * highPitchRange);
            float vol = Random.Range(lowVolRange, highVolRange);
            source.PlayOneShot(Footstep, vol);
        }
        lastSide = side;
    }
    // Update is called once per frame
    void Update() {

    }
}