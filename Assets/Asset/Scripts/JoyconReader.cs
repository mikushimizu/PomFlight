using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JoyconReader : MonoBehaviour
{
    //[pilkul] 行の開始地点がずれてるね。インデントって知ってる？ねえ？ん？
    //[pilkul] staticはなるべく使わないというスタンスで
    private static readonly Joycon.Button[] m_buttons =
		Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];
    //Updated upstream
    //[pilkul] m_ の意味わかってるか？コピペか？バレバレなんだよなぁ
    //Stashed changes
	private List<Joycon> m_joycons;
	private Joycon m_joyconL;
	private Joycon m_joyconR;
	private Joycon.Button? m_pressedButtonL;
	private Joycon.Button? m_pressedButtonR;
    public static int countL;
    public static int countR;
    
    //[pilkul] 配列じゃダメなんか
    public Player player1;
    public Player player2;

	private void Start()
	{
	//[pilkul] インデントサボりじゃん
		SetControllers();
        countL = 0;
        countR = 0;
    }

	private void Update()
	{
		m_pressedButtonL = null;
		m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0)
        {
            return;
        }

		SetControllers();

		foreach (var button in m_buttons)
		{
			if (m_joyconL.GetButton(button))
			{
				m_pressedButtonL = button;
			}
			if (m_joyconR.GetButton(button))
			{
				m_pressedButtonR = button;
			}
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			//[pilkul] 数字の直打ちはなるべく避ける、変数を1個作るかコメントをつけて数字の意味がわかるようにする
			m_joyconL.SetRumble(160, 320, 0.6f, 200);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			//[pilkul] 数字の直打ちはなるべく避ける、変数を1個作るかコメントをつけて数字の意味がわかるようにする
			m_joyconR.SetRumble(160, 320, 0.6f, 200);
		}
	}

	private void OnGUI()
	{
		var style = GUI.skin.GetStyle("label");
		//[pilkul] 数字の直打ちはなるべく避ける、変数を1個作るかコメントをつけて数字の意味がわかるようにする
		style.fontSize = 24;

		if (m_joycons == null || m_joycons.Count <= 0)
		{
			GUILayout.Label("Joy-Con が接続されていません");
			return;
		}

		if (!m_joycons.Any(c => c.isLeft))
		{
			GUILayout.Label("Joy-Con (L) が接続されていません");
			return;
		}

		if (!m_joycons.Any(c => !c.isLeft))
		{
			GUILayout.Label("Joy-Con (R) が接続されていません");
			return;
		}

		GUILayout.BeginHorizontal(GUILayout.Width(960));

		foreach (var joycon in m_joycons)
		{
			var isLeft = joycon.isLeft;
			var name = isLeft ? "Joy-Con (L)" : "Joy-Con (R)";
			var key = isLeft ? "Z キー" : "X キー";
			var button = isLeft ? m_pressedButtonL : m_pressedButtonR;
			var stick = joycon.GetStick();
			var gyro = joycon.GetGyro();
			var accel = joycon.GetAccel();
			var orientation = joycon.GetVector();

			GUILayout.BeginVertical(GUILayout.Width(480));
			GUILayout.Label(name);
			GUILayout.Label(key + "：振動");
			GUILayout.Label("押されているボタン：" + button);
			GUILayout.Label(string.Format("スティック：({0}, {1})", stick[0], stick[1]));
			GUILayout.Label("ジャイロ：" + gyro);
			GUILayout.Label("加速度：" + accel);
            if(accel.x >= 3.0f) //加速度が3.0f以上のときジョイコンをしっかり振ったと判定
            {
                switch (name)
                {
                    case "Joy-Con (L)":
                        countL++;
                        player1.gameObject.GetComponent<Player>().AddForce();
                        break;

                    case "Joy-Con (R)":
                        countR++;
                        player2.gameObject.GetComponent<Player>().AddForce();
                        break;
                }
            }

            Debug.Log("countL:" + countL + ", countR:" + countR);
            GUILayout.Label("傾き：" + orientation);
			GUILayout.EndVertical();
		}
		GUILayout.EndHorizontal();
	}

	private void SetControllers()
	{
		m_joycons = JoyconManager.Instance.j;
		if (m_joycons == null || m_joycons.Count <= 0) return;
		m_joyconL = m_joycons.Find(c => c.isLeft);
		m_joyconR = m_joycons.Find(c => !c.isLeft);
	}
}
