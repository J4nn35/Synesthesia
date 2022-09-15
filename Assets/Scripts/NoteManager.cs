using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data {
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public NoteMetadata[] notes;

}
[Serializable]
public class NoteMetadata {
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NoteManager : MonoBehaviour {
    public int noteNum;
    private string songName;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();

    [SerializeField] private float NotesSpeed;
    [SerializeField] GameObject noteObj;

    private Transform trans;

    void OnEnable() {

        trans = GetComponent<Transform>();

        noteNum = 0;
        songName = "fifthPierrot";
        Load(songName);
    }

    private void Load(string SongName) {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = inputJson.notes.Length;

        for (int i = 0; i < inputJson.notes.Length; i++) {
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset + 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            GameObject note = Instantiate(noteObj, trans);
            float x = inputJson.notes[i].block*(3.0f/28.0f) - 0.375f; // Calulated using interpolation (0, -4/8) -> (7, 3/8)
            float z = NotesTime[i] * NotesSpeed;
            note.transform.position = new Vector3(x, 0.55f, z);
            note.gameObject.GetComponent<Note>().speed = NotesSpeed;

            NotesObj.Add(note);
            
        }
    }
}