using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;


public class CustomGes1 : MonoBehaviour
{
    Controller controller;
    float HandPalmPitch;
    float HandPalmRoll;
    float HandPalmYam;
    float HandWristRot;

    void Update()
    {
        controller = new Controller();
        Frame frame = controller.Frame(); // 컨트롤러가 기록한 장면의 순간 스냅샷이 포함됨
        List<Hand> hands = frame.Hands;
        if (frame.Hands.Count > 0)
        {
            Hand fristHand = hands[0]; // 손 정보 획득

            // 손의 아이디 정보가 있다면 아래의 코드 사용 가능
            // Hand knownHand = frame.Hand (handID);
        }

        HandPalmPitch = hands[0].PalmNormal.Pitch;
        HandPalmRoll = hands[0].PalmNormal.Roll;
        HandPalmYam = hands[0].PalmNormal.Yaw;

        HandWristRot = hands[0].WristPosition.Pitch;

        Debug.Log("Pitch : " + HandPalmPitch);
        Debug.Log("Roll : " + HandPalmRoll);
        Debug.Log("Yam : " + HandPalmYam);

        if (HandPalmYam > -2f && HandPalmYam < 3.5f)
        {
            Debug.Log("앞");
            this.transform.Translate(0, 0, 1 * Time.deltaTime);
        }
        else if (HandPalmYam < -2.2f)
        {
            Debug.Log("뒤");
            this.transform.Translate(0, 0, -1 * Time.deltaTime);
        }
    }
}