using UnityEngine;
using UnityEngine.UI;
using toio;

// キューブの操作
public class ControlCube : MonoBehaviour
{
    public ConnectType connectType; // 接続種別
    public Text label; // ラベル

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
        // キューブのキー操作
        foreach (var cube in cm.syncCubes)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                cube.Move(-20, 20, 50);
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                cube.Move(20, -20, 50);
            } else if (Input.GetKey(KeyCode.UpArrow)) {
                cube.Move(50, 50, 50);
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                cube.Move(-50, -50, 50);
            }
        }

        // キューブのXY座標表示
        string text = "";
        foreach (var cube in cm.syncCubes)
        {
            text += "(" + cube.x + "," + cube.y + ")\n";
        }
        if (text != "") this.label.text = text;
    }
}