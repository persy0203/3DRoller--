using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using Mycobot.csharp;

public class Main : MonoBehaviour
{
    void Start()
    {
        // myCobotとの接続
        MyCobot mc = new MyCobot("/dev/cu.SLAB_USBtoUART"); // 自身のUSBポートを指定
        mc.Open();
        Thread.Sleep(5000);

        // 関節の角度の変更
        mc.SendOneAngle(1, 10, 80);
        Thread.Sleep(100);

        // myCobotとの切断
        mc.Close();
    }
}