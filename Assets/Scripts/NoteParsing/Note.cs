using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int measurePosition; //001 마디위치
    public int linePosition; //A2 라인위치
    public string notePosition; //00AA 노트위치
    public float noteTime; //노트 생성 시간
    public float songStartTime; //음악 재생 시간
    public float gap; //롱노트 길이

    private GameObject noteModel;
    public float nextTime;
    private bool isMove;
    
    public void NoteInit()
    {
        //noteModel = transform.GetChild(0).gameObject;
        isMove = true;
    }
    private void FixedUpdate()
    {
        if(isMove)
        {
            TimeCheck();
        }
    }
    public void TimeCheck()
    {
        nextTime += Time.deltaTime;
        if(nextTime > noteTime)
        {
            //noteModel.SetActive(true);
            NoteMove();
        }
    }
    public void NoteMove()
    {
        transform.position += new Vector3(0, -0.1f, 0);
        if(transform.position.y + (gap/2) + 1.0f < -30)
        {
            isMove = false;
            //noteModel.SetActive(false);
        }
    }
}
