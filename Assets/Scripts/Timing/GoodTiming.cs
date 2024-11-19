using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTiming : MonoBehaviour
{
    [SerializeField] TimingManager timingManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.goodTiming = true;
            timingManager.note = collision.gameObject;
            timingManager.noteCollider = true;
        }
        if (collision.tag == "LongNote")
        {
            timingManager.goodTiming = true;
            timingManager.longNoteCollider = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "LongNote")
        {
            timingManager.goodTiming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            timingManager.goodTiming = false;
        }
        if (collision.tag == "LongNote")
        {
            timingManager.goodTiming = false;
        }
    }
}
