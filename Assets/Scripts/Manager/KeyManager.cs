using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] TimingManager line1TimingManager;
    [SerializeField] TimingManager line2TimingManager;
    [SerializeField] TimingManager line3TimingManager;
    [SerializeField] TimingManager line4TimingManager;

    // Start is called before the first frame update
    void Start()
    {
        line1TimingManager.keyCode = KeyCode.D;
        line2TimingManager.keyCode = KeyCode.F;
        line3TimingManager.keyCode = KeyCode.K;
        line4TimingManager.keyCode = KeyCode.L;
    }
}
