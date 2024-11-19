using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class NoteData : MonoBehaviour
{
    public int measurePosition; //001마디 위치
    public int linePosition; //A2 라인위치
    public string notePosition; //00AA 노트 위치
    public float noteTime; //노트 생성 시간
    public float songStartTime; //음악 재생 시간
}
