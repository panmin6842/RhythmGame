using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public bool perfectTiming;
    public bool greatTiming;
    public bool goodTiming;
    public bool badTiming;
    public bool missTiming;
    public bool noteCollider;
    public bool longNoteCollider;

    //롱노트 터치 중
    private bool longPerfect;
    private bool longGreat;
    private bool longGood;
    private bool longBad;
    private bool longMiss;

    public GameObject note;
    public KeyCode keyCode;

    [SerializeField] GameObject touchGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            touchGround.SetActive(true);
            if (perfectTiming && noteCollider)
            {
                Debug.Log("Perfect");
                Destroy(note);
                noteCollider = false;
            }
            else if (greatTiming && noteCollider)
            {
                Debug.Log("Great");
                Destroy(note);
                noteCollider = false;
            }
            else if (goodTiming && noteCollider)
            {
                Debug.Log("Good");
                Destroy(note);
                noteCollider = false;
            }
            else if (badTiming && noteCollider)
            {
                Debug.Log("Bad");
                Destroy(note);
                noteCollider = false;
            }
            else if (missTiming && noteCollider)
            {
                Debug.Log("Miss");
                Destroy(note);
                noteCollider = false;
            }

            if (perfectTiming && longNoteCollider)
            {
                Debug.Log("LongNotePerfect");
                longPerfect = true;
            }
            else if(greatTiming && longNoteCollider)
            {
                Debug.Log("LongNoteGreat");
                longGreat = true;
            }
            else if (goodTiming && longNoteCollider)
            {
                Debug.Log("LongNoteGood");
                longGood = true;
            }
            else if (badTiming && longNoteCollider)
            {
                Debug.Log("LongNoteBad");
                longBad = true;
            }
            else if (missTiming && longNoteCollider)
            {
                Debug.Log("LongNoteMiss");
                longMiss = true;
            }
        }

        if(Input.GetKey(keyCode))
        {
            if(longPerfect)
            {
                Debug.Log("LongNotePerfect");
            }
            else if(longGreat)
            {
                Debug.Log("LongNoteGreat");
            }
            else if (longGood)
            {
                Debug.Log("LongNoteGood");
            }
            else if (longBad)
            {
                Debug.Log("LongNoteBad");
            }
            else if (longMiss)
            {
                Debug.Log("LongNoteMiss");
            }
        }

        if(Input.GetKeyUp(keyCode))
        {
            touchGround.SetActive(false);

            if(perfectTiming && greatTiming && goodTiming && badTiming && missTiming&& longNoteCollider && longPerfect)
            {
                Debug.Log("LongNoteMiss");
                longPerfect = false;
                longNoteCollider = false;
            }
            else if (perfectTiming && greatTiming && goodTiming && badTiming && !missTiming && longNoteCollider && longPerfect)
            {
                Debug.Log("LongNoteBadExit");
                longPerfect = false;
                longNoteCollider = false;
            }
            else if (perfectTiming && greatTiming && goodTiming && !badTiming && !missTiming && longNoteCollider && longPerfect)
            {
                Debug.Log("LongNoteGoodExit");
                longPerfect = false;
                longNoteCollider = false;
            }
            else if (perfectTiming && greatTiming && !goodTiming && !badTiming && !missTiming && longNoteCollider && longPerfect)
            {
                Debug.Log("LongNoteGreatExit");
                longPerfect = false;
                longNoteCollider = false;
            }
            else if (perfectTiming && !greatTiming && !goodTiming && !badTiming && !missTiming && longNoteCollider && longPerfect)
            {
                Debug.Log("LongNotePerfectExit");
                longPerfect = false;
                longNoteCollider = false;
            }
        }
    }
}
