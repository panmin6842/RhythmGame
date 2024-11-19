using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private Queue<NoteData> noteDataAA; //단일노트
    //롱노트는 라인마다
    private Queue<NoteData> noteDataBB1;
    private Queue<NoteData> noteDataBB2;
    private Queue<NoteData> noteDataBB3;
    private Queue<NoteData> noteDataBB4;

    public NoteData noteData;

    public GameObject model;
    public GameObject note;
    public GameObject noteModel;

    public List<GameObject> listNoteAZ;
    public List<GameObject> listNoteB;

    private string resourceNote;

    public float xPosition = 0.0f;
    public float startPos = 0.0f;

    public void NoteControllerInit()
    { 
        noteDataAA = NoteManager.GetNoteManager().GetNoteDataAA();
        noteDataBB1 = NoteManager.GetNoteManager().GetNoteDataBB1();
        noteDataBB2 = NoteManager.GetNoteManager().GetNoteDataBB2();
        noteDataBB3 = NoteManager.GetNoteManager().GetNoteDataBB3();
        noteDataBB4 = NoteManager.GetNoteManager().GetNoteDataBB4();
        listNoteAZ = new List<GameObject>();
        listNoteB = new List<GameObject>();
        startPos = 10.0f;
        SetNote();
    }

    public void SetNote()
    {
        //AA노트 세팅
        foreach(var data in noteDataAA)
        {
            if(data.linePosition == 1)
            {
                //ZZ
                model = Resources.Load("Prefabs/Note") as GameObject;
                note = Instantiate<GameObject>(model, new Vector3(100, 0, 0), Quaternion.identity); //첫번째 위치에 생성
                note.transform.SetParent(transform);

                var noteNote = note.AddComponent<Note>();
                noteNote.linePosition = data.linePosition;
                noteNote.measurePosition = data.measurePosition;
                noteNote.notePosition = data.notePosition;
                noteNote.noteTime = data.noteTime;
                noteNote.songStartTime = data.songStartTime;
                noteNote.gap = 0;

                listNoteAZ.Add(note);
            }
            else
            {
                //AA
                Xposition(data.linePosition);
                model = Resources.Load(resourceNote) as GameObject;
                var vp = new Vector3(Xposition(data.linePosition), 16f, 0);
                note = Instantiate<GameObject>(model, vp, Quaternion.identity); //첫번째 위치에 생성
                note.transform.SetParent(transform);
                note.tag = "Note";

                var noteNote = note.AddComponent<Note>();
                noteNote.linePosition = data.linePosition;
                noteNote.measurePosition = data.measurePosition;
                noteNote.notePosition = data.notePosition;
                noteNote.noteTime = data.noteTime;
                noteNote.songStartTime = data.songStartTime;
                noteNote.gap = 0;

                listNoteAZ.Add(note);
            }
        }

        //BB노트
        for(int i = 0; i < noteDataBB1.Count; i++)
        {
            var longHead = noteDataBB1.Dequeue();
            var longEnd = noteDataBB1.Dequeue();
            var gap = startPos * (longEnd.noteTime - longHead.noteTime);
            Xposition(longHead.linePosition);
            model = Resources.Load(resourceNote) as GameObject;
            var vp = new Vector3(Xposition(longHead.linePosition), 16f, 0);
            note = Instantiate<GameObject>(model, vp, Quaternion.identity);
            note.transform.SetParent (transform);
            note.transform.localScale = new Vector3(note.transform.localScale.x, 0.4f + gap, 1.0f);
            note.tag = "LongNote";
            note.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
            note.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);

            var noteNote = note.AddComponent<Note>();
            noteNote.linePosition = longHead.linePosition;
            noteNote.measurePosition = longHead.measurePosition;
            noteNote.notePosition = longHead.notePosition;
            noteNote.noteTime = longHead.noteTime;
            noteNote.songStartTime = longHead.songStartTime;
            noteNote.gap = 0;

            listNoteB.Add(note);
        }
        for (int i = 0; i < noteDataBB2.Count; i++)
        {
            var longHead = noteDataBB2.Dequeue();
            var longEnd = noteDataBB2.Dequeue();
            var gap = startPos * (longEnd.noteTime - longHead.noteTime);
            Xposition(longHead.linePosition);
            model = Resources.Load(resourceNote) as GameObject;
            var vp = new Vector3(Xposition(longHead.linePosition), 16f, 0);
            note = Instantiate<GameObject>(model, vp, Quaternion.identity);
            note.transform.SetParent(transform);
            note.transform.localScale = new Vector3(note.transform.localScale.x, 0.4f + gap, 1.0f);
            note.tag = "LongNote";
            note.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
            note.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);

            var noteNote = note.AddComponent<Note>();
            noteNote.linePosition = longHead.linePosition;
            noteNote.measurePosition = longHead.measurePosition;
            noteNote.notePosition = longHead.notePosition;
            noteNote.noteTime = longHead.noteTime;
            noteNote.songStartTime = longHead.songStartTime;
            noteNote.gap = 0;

            listNoteB.Add(note);
        }
        for (int i = 0; i < noteDataBB3.Count; i++)
        {
            var longHead = noteDataBB3.Dequeue();
            var longEnd = noteDataBB3.Dequeue();
            var gap = startPos * (longEnd.noteTime - longHead.noteTime);
            Xposition(longHead.linePosition);
            model = Resources.Load(resourceNote) as GameObject;
            var vp = new Vector3(Xposition(longHead.linePosition), 16f, 0);
            note = Instantiate<GameObject>(model, vp, Quaternion.identity);
            note.transform.SetParent(transform);
            note.transform.localScale = new Vector3(note.transform.localScale.x, 0.4f + gap, 1.0f);
            note.tag = "LongNote";
            note.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
            note.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);

            var noteNote = note.AddComponent<Note>();
            noteNote.linePosition = longHead.linePosition;
            noteNote.measurePosition = longHead.measurePosition;
            noteNote.notePosition = longHead.notePosition;
            noteNote.noteTime = longHead.noteTime;
            noteNote.songStartTime = longHead.songStartTime;
            noteNote.gap = 0;

            listNoteB.Add(note);
        }
        for (int i = 0; i < noteDataBB4.Count; i++)
        {
            var longHead = noteDataBB4.Dequeue();
            var longEnd = noteDataBB4.Dequeue();
            var gap = startPos * (longEnd.noteTime - longHead.noteTime);
            Xposition(longHead.linePosition);
            model = Resources.Load(resourceNote) as GameObject;
            var vp = new Vector3(Xposition(longHead.linePosition), 16f, 0);
            note = Instantiate<GameObject>(model, vp, Quaternion.identity);
            note.transform.SetParent(transform);
            note.transform.localScale = new Vector3(note.transform.localScale.x, 0.4f + gap, 1.0f);
            note.tag = "LongNote";
            note.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
            note.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);

            var noteNote = note.AddComponent<Note>();
            noteNote.linePosition = longHead.linePosition;
            noteNote.measurePosition = longHead.measurePosition;
            noteNote.notePosition = longHead.notePosition;
            noteNote.noteTime = longHead.noteTime;
            noteNote.songStartTime = longHead.songStartTime;
            noteNote.gap = 0;

            listNoteB.Add(note);
        }
        for (int i = 0; i < listNoteAZ.Count; i++)
        {
            listNoteAZ[i].GetComponent<Note>().NoteInit();
        }
        for (int i = 0; i < listNoteB.Count; i++)
        {
            listNoteB[i].GetComponent<Note>().NoteInit();
        }
    }

    public float Xposition(int key)
    {
        switch(key)
        {
            //음악정보
            case 01:
                {
                    xPosition = 0.1f;
                    break;
                }
                //일반노트
            case 11:
                {
                    xPosition = -2.4566f;
                    resourceNote = "Prefabs/Line1Note";
                    break;
                }
            case 12:
                {
                    xPosition = -0.79f;
                    resourceNote = "Prefabs/Line2Note";
                    break;
                }
            case 13:
                {
                    xPosition = 0.86f;
                    resourceNote = "Prefabs/Line3Note";
                    break;
                }
            case 14:
                {
                    xPosition = 2.53f;
                    resourceNote = "Prefabs/Line4Note";
                    break;
                }
            //롱노트
            case 51:
                {
                    xPosition = -2.4566f;
                    resourceNote = "Prefabs/Line1Note";
                    break;
                }
            case 52:
                {
                    xPosition = -0.79f;
                    resourceNote = "Prefabs/Line2Note";
                    break;
                }
            case 53:
                {
                    xPosition = 0.86f;
                    resourceNote = "Prefabs/Line3Note";
                    break;
                }
            case 54:
                {
                    xPosition = 2.53f;
                    resourceNote = "Prefabs/Line4Note";
                    break;
                }
        }
        return xPosition;
    }

}
