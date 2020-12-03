using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;

public class UIManager : Singleton<UIManager>
{
    // 버튼 관리용 이중 리스트
    // 0 : 타이틀
    // 1 : 1차 2D 메뉴
    // 2 : 2차 2D 메뉴
    // 3~ : ...위와 같은 형태로 반복
    List<List<GameObject>> buttonObjects;
    public int depth = 0; // 현재 UI 깊이값. 이 값을 통해 활성화 될 버튼을 관리
    
    private UIManager()
    {
        buttonObjects = new List<List<GameObject>>();
    }

    public override void Start()
    {
        base.Start();
    }

    public void MoveUiDepth(int _depth)
    {
        depth = _depth;

        // 모든 버튼 비활성화
        for(int i=0; i < buttonObjects.Count; i++)
        {
            for(int j=0; j<buttonObjects[i].Count; j++)
            {
                // 초기형 코드. 오브젝트 활성화 방식으로 작동 가능한지부터 체크
                // 이후 버튼 기능 잠금으로 변경할 것
                buttonObjects[i][j].SetActive(false);
            }
        }

        // 현재 계층의 버튼 활성화
        for (int i = 0; i < buttonObjects[depth].Count; i++)
        {
            buttonObjects[depth][i].SetActive(true);
        }
    }

    public void AddButton(GameObject _go, int layer)
    {
        buttonObjects[layer].Add(_go);
    }
    
}
