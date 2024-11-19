using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissTiming : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.missTiming = true;
            timingManager.note = collision.gameObject;
            timingManager.noteCollider = true;
        }
        if (collision.tag == "LongNote")
        {
            timingManager.missTiming = true;
            timingManager.longNoteCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LongNote")
        {
            timingManager.missTiming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.missTiming = false;
        }
        if (collision.tag == "LongNote")
        {
            timingManager.missTiming = false;
        }
    }
}
