using UnityEngine;
using toio;

// キューブの回転
public class RotateCube : MonoBehaviour
{
    public ConnectType connectType; // 接続種別

    CubeManager cm; // キューブマネージャ

    // スタート時に呼ばれる
    async void Start()
    {
        // キューブの接続
        cm = new CubeManager(connectType);
        await cm.MultiConnect(1);
    }

    // フレーム毎に呼ばれる
    void Update()
    {
        // キューブの回転
        foreach (var cube in cm.syncCubes)
        {
            cube.Move(50, -50, 100);
        }
    }
}