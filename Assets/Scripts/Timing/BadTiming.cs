using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTiming : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.badTiming = true;
            timingManager.note = collision.gameObject;
            timingManager.noteCollider = true;
        }

        if (collision.tag == "LongNote")
        {
            timingManager.badTiming = true;
            timingManager.longNoteCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LongNote")
        {
            timingManager.badTiming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.badTiming = false;
        }

        if (collision.tag == "LongNote")
        {
            timingManager.badTiming = false;
        }
    }
}
