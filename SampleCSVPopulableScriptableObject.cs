﻿using System.Collections;
using System.Collections.Generic;
using UnityCSV2SO;
using UnityCSV2SO.PrimitiveData;
using UnityEngine;
[CreateAssetMenu(fileName = "SampleCSVPopulableScriptableObject", menuName = "CSVData/SampleCSVPopulableScriptableObject")]
public class SampleCSVPopulableScriptableObject : CSVPopulableScriptableObject
{
    public float moveSpeed; 
    public float crouchMoveSpeed;
    public float slideMoveSpeed;
    public float wallrunSpeedStart;
    public float wallrunSpeedEnd;
    public float wallRunTime;
    public float wallRunJump;
    public float wallClimbMultiplier;
    public float jumpSpeed;

#if UNITY_EDITOR
    public override string CSVKey => "Player";

    public override void UpdateSelf(ScriptableObject refToUpdate, ScriptableObject newValues)
    {
        throw new System.NotImplementedException();
    }

    protected override void SetValue<T>(string value, string key, ref T reference)
    {
        throw new System.NotImplementedException();
    }

    protected void PopulateData(PrimitiveDataDictionary dataDictionary)
    {

        void LogError() => Debug.LogError("Couldn't find value!");

        if (!dataDictionary.TryGetFloat("MoveSpeed", out moveSpeed)) { LogError(); }
        if (!dataDictionary.TryGetFloat("CrouchMoveSpeed", out crouchMoveSpeed)) { LogError(); }
        if (!dataDictionary.TryGetFloat("SlideMoveSpeed", out slideMoveSpeed)) { LogError(); }
        if (!dataDictionary.TryGetFloat("WallRunStartSpeed", out wallrunSpeedStart)) { LogError(); }
        if (!dataDictionary.TryGetFloat("WallRunEndSpeed", out wallrunSpeedEnd)) { LogError(); }
        if (!dataDictionary.TryGetFloat("WallRunTime", out wallRunTime)) { LogError(); }
        if (!dataDictionary.TryGetFloat("WallRunJump", out wallRunJump)) { LogError(); }
        if (!dataDictionary.TryGetFloat("WallClimbMultiplier", out wallClimbMultiplier)) { LogError(); }
        if (!dataDictionary.TryGetFloat("JumpSpeed", out jumpSpeed)) { LogError(); }
    }
#endif
}
