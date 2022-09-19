using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChartInfo {
    public string name;
    public uint maxBlock;
    public float BPM;
    public float offset;
    public NoteInfo[] notes;
}

[System.Serializable]
public class NoteInfo {
    public uint LPB;
    public uint num;
    public uint block;
    public uint type;
    public NoteInfo[] notes;
}

public class Conductor : MonoBehaviour {

    // Make this a singleton class
    private static Conductor instance;
    public static Conductor Instance {
        get {
            return instance ?? (instance = (new GameObject("Conductor").AddComponent<Conductor>()));
        }
    }

    public ChartInfo chartInfo;

    void Start() {
        Load("fifthPierrot");
    }

    void Update() {
        
    }

    void Load(string songName) {
        
        var rawChart = Resources.Load<TextAsset>(songName).ToString();
        chartInfo = JsonUtility.FromJson<ChartInfo>(rawChart);

    }

}
