using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatTiming : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.greatTiming = true;
            timingManager.note = collision.gameObject;
            timingManager.noteCollider = true;
        }
        if (collision.tag == "LongNote")
        {
            timingManager.greatTiming = true;
            timingManager.longNoteCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LongNote")
        {
            timingManager.greatTiming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.greatTiming = false;
        }
        if (collision.tag == "LongNote")
        {
            timingManager.greatTiming = false;
        }
    }
}
