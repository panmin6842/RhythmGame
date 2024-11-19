using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public GameObject noteController;
    
    void Start()
    {
        var noteManager = NoteManager.GetNoteManager();
        noteManager.NoteManagerInit();
        noteController.GetComponent<NoteController>().NoteControllerInit();
    }

}
