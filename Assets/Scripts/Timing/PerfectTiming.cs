using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectTiming : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Note")
        {
            timingManager.perfectTiming = true;
            timingManager.noteCollider = true;
            timingManager.note = collision.gameObject;
        }

        if (collision.tag == "LongNote")
        {
            timingManager.perfectTiming = true;
            timingManager.longNoteCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LongNote")
        {
            timingManager.perfectTiming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.perfectTiming = false;
        }

        if (collision.tag == "LongNote")
        {
            timingManager.perfectTiming = false;
        }
    }
}
