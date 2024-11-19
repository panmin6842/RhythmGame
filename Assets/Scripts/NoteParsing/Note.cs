using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int measurePosition; //001 ������ġ
    public int linePosition; //A2 ������ġ
    public string notePosition; //00AA ��Ʈ��ġ
    public float noteTime; //��Ʈ ���� �ð�
    public float songStartTime; //���� ��� �ð�
    public float gap; //�ճ�Ʈ ����

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
