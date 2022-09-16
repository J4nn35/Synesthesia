using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour {

    // Make this a singleton class
    private static  readonly Conductor instance = new Conductor();
    public  static Conductor Instance {
        get {
            return instance;
        }
    }

    public float bpm;
    public float crotchet; // Time duration of a beat
    public float offset;
    public float songPosition;

    void Start() {
        
    }

    void Update() {
        
    }



}
