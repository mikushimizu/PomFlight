﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject TargetObject;
    public float Height = 6.0f;
    public float Distance = 30.0f;
    public float AngleX = 0.0f;
    public float AngleAttenRate = 5.0f;

    public bool EnableAtten = true;
    public float AttenRate = 3.0f;

    public bool EnableNoise = true;
    public float NoiseSpeed = 0.5f;
    public float MoveNoiseSpeed = 1.5f;
    public float NoiseCoeff = 1.3f;
    public float MoveNoiseCoeff = 2.2f;

    public bool EnableFieldOfViewAtten = true;
    public float FieldOfView = 50.0f;
    public float MoveFieldOfView = 60.0f;

    public float ForwardDistance = 3.0f;
    public float ForwardSpeed = 3.0f;

    private Camera cam;
    private Vector3 deltaTarget;
    private Vector3 nowPos;
    private float nowfov;

    private float addX;

    void Start () {
        cam = GetComponent<Camera>();
        nowfov = FieldOfView;
        nowPos = TargetObject.transform.position;
    }
	
	void Update () {
		var delta = TargetObject.transform.position - deltaTarget;
        deltaTarget = TargetObject.transform.position;

        // 減衰
        if (EnableAtten)
        {
            if (delta.x > 0.004f) addX += Time.deltaTime * ForwardSpeed;
            else if (delta.x < -0.004f) addX -= Time.deltaTime * ForwardSpeed;
            else addX = Mathf.Lerp(addX, 0.0f, Time.deltaTime * ForwardSpeed);
            addX = Mathf.Clamp(addX, -ForwardDistance, ForwardDistance);

            var add = new Vector3(addX, delta.y * 20.0f, 0.0f);
            nowPos = Vector3.Lerp(nowPos, TargetObject.transform.position + add, Mathf.Clamp(Time.deltaTime * AttenRate, 0.0f, 1.0f));
        }
        else nowPos = TargetObject.transform.position;

        // 手ブレ
        bool move = Mathf.Abs(delta.x) > 0.0f;
        var noise = new Vector3();
        if (EnableNoise)
        {
            var ns = (move ? MoveNoiseSpeed : NoiseSpeed);
            var nc = (move ? MoveNoiseCoeff : NoiseCoeff);

            var t = Time.time * ns;

            var n1 = Mathf.PerlinNoise(t, t + 5.0f) * nc;
            var n2 = Mathf.PerlinNoise(t + 10.0f, t + 15.0f) * nc;
            var n3 = Mathf.PerlinNoise(t + 25.0f, t + 20.0f) * nc;
            noise = new Vector3(n1, n2, n3 * 0.5f);
        }

        // FoV
        if (EnableFieldOfViewAtten) nowfov = Mathf.Lerp(nowfov, move ? MoveFieldOfView : FieldOfView, Time.deltaTime);
        else nowfov = FieldOfView;
        cam.fieldOfView = nowfov;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(AngleX + noise.x, noise.y, noise.z), Time.deltaTime * AngleAttenRate);
        transform.position = nowPos + new Vector3(0.0f, Height, -Distance);
	}
}
