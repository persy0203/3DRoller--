using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mycobot.csharp;

public class SyncJoin : MonoBehaviour
{
    //FPS
    public float fps = 1.0f;
    private float currentTime = 0f;
    //参照
    public ArticulationBody[] jointArticulationBodies;
    private MyCobot mc;

    // Start is called before the first frame update
    void Start()
    {
        //myCobotとの接続
        mc = new MyCobot("COM3");
        mc.Open();
    }

    // Update is called once per frame
    void Update()
    {
        // FPSの調整
        currentTime += Time.deltaTime;
        if (currentTime < fps) return;

        //関節の角度の取得
        int[] angles = new int[6];
        for (var i = 0; i < jointArticulationBodies.Length; i++)
        {
            angles[i] = (int)this.jointArticulationBodies[i].xDrive.target;
        }
        print("angles>>>" + angles[0] + "," + angles[1] + "," + angles[2] + "," + angles[3] + "," + angles[4] + "," + angles[5]);

        //関節の角度の同期
        mc.SendAngles(angles, 50);

        //FPSの調整
        currentTime = 0f;
    }

    void OnDestroy()
    {
        //myCobotとの切断
        mc.Close();
    }
}
