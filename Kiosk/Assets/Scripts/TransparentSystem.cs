using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class TransparentSystem : MonoBehaviour
{
    //[SerializeField] Material normalMtrl;
    //[SerializeField] Material transpMtrl;

    Camera mainCamera;

    GameObject lHand;
    GameObject rHand;

    GameObject lHandPalm;
    GameObject rHandPalm;

    int mask;

    private void Awake()
    {
        mask = 1 << LayerMask.NameToLayer("Obstacle");
    }

    private void Start()
    {
        mainCamera = Camera.main;
        var lsp = FindObjectOfType<LeapServiceProvider>();
        var handGroup = lsp.transform.Find("Hand Models");
        lHand = handGroup.transform.GetChild(0).gameObject;
        lHandPalm = lHand.transform.Find("L_Wrist").Find("L_Palm").gameObject;
        rHand = handGroup.transform.GetChild(1).gameObject;
        rHandPalm = rHand.transform.Find("R_Wrist").Find("R_Palm").gameObject;
    }

    void Update()
    {
        // 활성화 중인 손에 RayCast
        if(lHand.activeSelf)
        {
            Debug.Log("왼손 레이 체크중");
            Vector3 leftVec = lHandPalm.transform.position - mainCamera.transform.position;
            Ray lRay = new Ray(mainCamera.transform.position, leftVec);

            RaycastHit[] hits_left = Physics.RaycastAll(mainCamera.transform.position,
            leftVec.normalized, leftVec.magnitude, mask);

            Debug.DrawRay(lRay.origin, lRay.direction, Color.green);

            if (hits_left.Length > 0)
            {
                for (int i = 0; i < hits_left.Length; i++)
                    hits_left[i].transform.GetComponent<Obstacle>().OnTranslucent();
            }
        }
        
        if(rHand.activeSelf)
        {
            Debug.Log("오른손 레이 체크중");
            Vector3 rightVec = rHandPalm.transform.position - mainCamera.transform.position;
            Ray rRay = new Ray(mainCamera.transform.position, rightVec);


            RaycastHit[] hits_Right = Physics.RaycastAll(mainCamera.transform.position,
                rightVec.normalized, rightVec.magnitude, mask);


            Debug.DrawRay(rRay.origin, rRay.direction, Color.red);

            // 검출된 Obstacle 레이어 오브젝트의 반투명 기능 활성화
            if (hits_Right.Length > 0)
            {
                for (int i = 0; i < hits_Right.Length; i++)
                    hits_Right[i].transform.GetComponent<Obstacle>().OnTranslucent();
            }
        }
        
        

        // 손 강조 기능 활성화
        // ...

    }
}
