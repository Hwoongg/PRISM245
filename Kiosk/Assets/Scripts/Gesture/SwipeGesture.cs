using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

// Hand Property Description
// isRight, isLeft— 손이 왼손인지 오른손인지.
// Palm Position — Leap Motion 원점에서 밀리미터 단위로 측정 한 손바닥 중심.
// Palm Velocity — 초당 밀리미터 단위의 손바닥 속도 및 이동 방향.
// Palm Normal— 손바닥으로 형성된 평면에 수직 인 벡터. 벡터는 손바닥에서 아래쪽을 가리 킵니다.
// Direction — 손바닥 중앙에서 손가락을 가리키는 벡터입니다.
// grabStrength, pinchStrength- 손의 자세를 설명하십시오.
// Motion factors — 두 프레임 사이의 이동에 대한 상대 배율, 회전 및 평행 이동 계수를 제공합니다.

public class SwipeGesture : MonoBehaviour
{
    Controller controller;
    List<float> mo = new List<float>();
    public GameObject cube;
    //bool DTtime = false;
    float HandPalmPitch;
    int num = 0;

    void Start()
    {
        mo.Clear();
        controller = new Controller();
    }

    void Update()
    {
        if (controller.IsConnected)
        {
            Frame frame = controller.Frame(); // 마지막 프레임
            Frame previous = controller.Frame(1); // 마지막의 직전 프레임
            for (int h = 0; h < frame.Hands.Count; h++)
            {
                Hand leapHand = frame.Hands[0];
                Hand previous_leapHand = previous.Hands[0];
                Vector handOrigin = leapHand.PalmPosition;
                Vector previoushandOrigin = previous_leapHand.PalmPosition;
                HandPalmPitch = leapHand.PalmNormal.Pitch;
                if (System.Math.Abs(handOrigin.x - previoushandOrigin.x) > 5 
                    && System.Math.Abs(leapHand.PalmVelocity.x) > 30)
                {
                    Debug.Log("휘두름");
                    mo.Add(1);
                    int lastcount = mo.Count;
                    if (mo[lastcount - 2] != mo[lastcount - 1])
                    {
                        if (cube.activeSelf == true)
                        {
                            //Debug.Log("사라지게");
                            cube.SetActive(false);
                        }
                        else
                        {
                            //Debug.Log("생기게");
                            cube.SetActive(true);
                        }
                    }
                }
                else
                {
                    mo.Add(0);
                }
            }
        }
    }

    public void PrintActivateMessage()
    {
        print("A");
    }

    public void PrintDeactivateMessage()
    {
        if (HandPalmPitch > 1.4f)
        {
            Color[] co = new Color[3];
            co[0] = Color.red;
            co[1] = Color.blue;
            co[2] = Color.green;
            cube.GetComponent<MeshRenderer>().material.color = co[num % 3];
            num++;
        }

    }
}