using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;

public class UIManager : Singleton<UIManager>
{
    // 버튼 관리용 이중 리스트 (보류)
    // 0 : 타이틀
    // 1 : 1차 2D 메뉴
    // 2 : 2차 2D 메뉴
    // 3~ : ...위와 같은 형태로 반복
    //List<List<GameObject>> buttonObjects;
    [HideInInspector] public int depth = 0;

    // 열릴 메뉴 인덱스 보관용 변수
    // 0 : 상호작용
    // 1 : 미디어
    // 2 : 상영시간표
    [HideInInspector] public int open2DMenuIdx;

    private UIManager()
    {
        //buttonObjects = new List<List<GameObject>>();
    }

    public override void Start()
    {
        base.Start();
    }

    //public void MoveUiDepth(int _depth)
    //{
    //    depth = _depth;

    //    // 모든 버튼 비활성화
    //    for(int i=0; i < buttonObjects.Count; i++)
    //    {
    //        for(int j=0; j<buttonObjects[i].Count; j++)
    //        {
    //            // 초기형 코드. 오브젝트 활성화 방식으로 작동 가능한지부터 체크
    //            // 이후 버튼 기능 잠금으로 변경할 것
    //            buttonObjects[i][j].SetActive(false);
    //        }
    //    }

    //    // 현재 계층의 버튼 활성화
    //    for (int i = 0; i < buttonObjects[depth].Count; i++)
    //    {
    //        buttonObjects[depth][i].SetActive(true);
    //    }
    //}

    //public void AddButton(GameObject _go, int layer)
    //{
    //    buttonObjects[layer].Add(_go);
    //}
    
}
