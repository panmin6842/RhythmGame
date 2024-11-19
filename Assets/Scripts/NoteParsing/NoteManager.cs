
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager
{
    public static NoteManager instance;
    public static NoteManager GetNoteManager()
    {
        if(NoteManager.instance == null)
        {
            NoteManager.instance = new NoteManager();
        }
        return NoteManager.instance;
    }

    private Dictionary<int, string> dicBmsData;
    private Dictionary<string, string> dicHeaderData;

    private Queue<NoteData> noteDataAA; //단일노트
    //롱노트는 라인마다
    private Queue<NoteData> noteDataBB1;
    private Queue<NoteData> noteDataBB2;
    private Queue<NoteData> noteDataBB3;
    private Queue<NoteData> noteDataBB4;

    private NoteData noteData;

    private int headKey;
    private int noteKey;
    private float tikTime;

    private NoteManager() //초기화
    {
        dicBmsData = new Dictionary<int, string>();
        dicHeaderData = new Dictionary<string, string>();
        noteDataAA = new Queue<NoteData>();
        noteDataBB1 = new Queue<NoteData>();
        noteDataBB2 = new Queue<NoteData>();
        noteDataBB3 = new Queue<NoteData>();
        noteDataBB4 = new Queue<NoteData>();
    }


    public void NoteManagerInit()
    {
        this.ReadBMSfile();
    }

    private void ReadBMSfile()
    {
        string[] bmsData = File.ReadAllLines(Application.dataPath + "/practice3.bms"); //bms파일 가져오기
        for(int i = 0; i < bmsData.Length; i++)
        {
            dicBmsData.Add(i, bmsData[i]);
        }
        Debug.Log("BMS 파일 불러옴");
        this.SetHeaderData();
    }

    private void SetHeaderData()
    {
        foreach(var pair in this.dicBmsData)
        {
            var key = pair.Key;
            var data = pair.Value;
            if(data == "*---------------------- HEADER FIELD")
            {
                this.headKey = key;
                for (int i = this.headKey; i < this.dicBmsData.Count; i++)
                {
                    if(dicBmsData[i].StartsWith("#")) //지정한 문자로 시작 구분
                    {
                        string[] arrNote = dicBmsData[i].Split('#'); //#으로 시작되는 문자열 저장
                        string[] stageData = arrNote[1].Split(' '); //잘라서 저장
                        this.dicHeaderData.Add(stageData[0], stageData[1]);
                    }
                    else if (dicBmsData[i] == "*---------------------- MAIN DATA FIELD")
                    {
                        goto EXIT;
                    }
                }
            }
        }
        EXIT:
        {
            Debug.Log("헤더 데이터 로드");
            SetNoteData();
        }
    }
    public Dictionary<string, string> GetHeaderData()
    {
        return dicHeaderData;
    }
    private void SetNoteData()
    {
        foreach(var pair in GetHeaderData())
        {
            var bpm = pair.Key;
            var data = pair.Value;
            if(bpm == "BPM")
            {
                float musicBPM = float.Parse(data);
                tikTime = (4 * 60) / musicBPM;
                break;
            }
        }
        foreach(var pair in dicBmsData)
        {
            var key = pair.Key;
            var data = pair.Value;
            if (data == "*---------------------- MAIN DATA FIELD")
            {
                noteKey = key;
                for (int j = noteKey; j < dicBmsData.Count; j++)
                {
                    if(dicBmsData[j].StartsWith("#"))
                    {
                        string[] arrNote = dicBmsData[j].Split('#');
                        string[] arrData = arrNote[1].Split(':');
                        //00111
                        //00AA000000000000000000000000AA00
                        int tempMeasurePosition = int.Parse(arrData[0].Substring(0, 3)); //001
                        int tempLinePosition = int.Parse(arrData[0].Substring(3, 2)); //11
                        string tempNotePosition = arrData[1]; //00AA000000000000000000000000AA00

                        switch(tempLinePosition)
                        {
                            case 01:
                                {
                                    for(int i = 0; i < tempNotePosition.Length / 2; i++)
                                    {
                                        if(tempNotePosition.Substring(i * 2, 2).StartsWith("Z"))
                                        {
                                            //음악 정보
                                            float tempNoteTime = ((tempMeasurePosition) * (tikTime)) + ((i) * (tikTime) / (tempNotePosition.Length / 2)); //ZZ
                                            noteData = new NoteData();
                                            noteData.songStartTime = tempNoteTime;
                                            noteData.measurePosition = tempMeasurePosition;
                                            noteData.linePosition = tempLinePosition;
                                            noteData.noteTime = 10000.0f;
                                            noteData.notePosition = tempNotePosition;
                                            noteDataAA.Enqueue(noteData);
                                        }
                                    }
                                }
                                break;
                            case 11:
                                {
                                    NomalNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition);
                                }
                                break;
                            case 12:
                                {
                                    NomalNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition);
                                }
                                break;
                            case 13:
                                {
                                    NomalNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition);
                                }
                                break;
                            case 14:
                                {
                                    NomalNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition);
                                }
                                break;
                            case 51: //여기부터 롱노트
                                {
                                    LongNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition, noteDataBB1);
                                }
                                break;
                            case 52: //여기부터 롱노트
                                {
                                    LongNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition, noteDataBB2);
                                }
                                break;
                            case 53: //여기부터 롱노트
                                {
                                    LongNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition, noteDataBB3);
                                }
                                break;
                            case 54: //여기부터 롱노트
                                {
                                    LongNoteEnqueue(tempMeasurePosition, tempLinePosition, tempNotePosition, noteDataBB4);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }

    void NomalNoteEnqueue(int tempMeasurePosition, int tempLinePosition, string tempNotePosition)
    {
        for (int i = 0; i < tempNotePosition.Length / 2; i++)
        {
            if (tempNotePosition.Substring(i * 2, 2).StartsWith("A"))
            {
                //일반노트
                float tempNoteTime = ((tempMeasurePosition) * (tikTime) + ((i) * (tikTime) / (tempNotePosition.Length / 2))); //AA
                noteData = noteData = new NoteData();
                noteData.measurePosition = tempMeasurePosition;
                noteData.linePosition = tempLinePosition;
                noteData.noteTime = tempNoteTime;
                noteData.notePosition = tempNotePosition;
                noteData.songStartTime = 10000.0f;
                noteDataAA.Enqueue(noteData);
            }
        }
    }

    void LongNoteEnqueue(int tempMeasurePosition, int tempLinePosition, string tempNotePosition, Queue<NoteData> noteDataBB)
    {
        for (int i = 0; i < tempNotePosition.Length / 2; i++)
        {
            if (tempNotePosition.Substring(i * 2, 2).StartsWith("B"))
            {
                //일반노트
                float tempNoteTime = ((tempMeasurePosition) * (tikTime) + ((i) * (tikTime) / (tempNotePosition.Length / 2))); //AA
                noteData = noteData = new NoteData();
                noteData.measurePosition = tempMeasurePosition;
                noteData.linePosition = tempLinePosition;
                noteData.noteTime = tempNoteTime;
                noteData.notePosition = tempNotePosition;
                noteData.songStartTime = 10000.0f;
                noteDataBB.Enqueue(noteData);
            }
        }
    }

    public Queue<NoteData> GetNoteDataAA()
    {
        return noteDataAA;
    }
    public Queue<NoteData> GetNoteDataBB1()
    {
        return noteDataBB1;
    }
    public Queue<NoteData> GetNoteDataBB2()
    {
        return noteDataBB2;
    }
    public Queue<NoteData> GetNoteDataBB3()
    {
        return noteDataBB3;
    }
    public Queue<NoteData> GetNoteDataBB4()
    {
        return noteDataBB4;
    }
}
