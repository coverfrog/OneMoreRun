using System;
using System.Collections.Generic;
using Cf_Cam;
using Cf_Input;
using Cf_Pattern;
using UnityEngine;

/// <summary>
/// 싱글톤 으로 하위 객체를 호출만 하는 역할
/// 따로 함수를 만들지 말 것
/// </summary>
public class GlobalManager : Singleton<GlobalManager>
{
    [SerializeField] private InputHandler mInputHandler;
    [SerializeField] private CamHandler mCamHandler;
        
    public InputHandler Input => mInputHandler;
        
    public CamHandler Cam => mCamHandler;
}