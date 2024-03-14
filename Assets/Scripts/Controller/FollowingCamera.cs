using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 카메라가 일정 거리를 유지한 채로 플레이어 추적하는 기능
/// </summary>
public class FollowingCamera : MonoBehaviour
{
    public float distanceAway = 7.0f;
    public float distanceUp = 4.0f;

    public Transform follow;

    // Update 처리가 끝났을때 호출하는 라이프 사이클
    // 주로 추적 카메라 구현시 사용
    private void LateUpdate()
    {
        // 카메라 위치를 distanceUp 만큼 위로 distanceAway 만큼 앞에 위치 시킴
        transform.position = follow.position + Vector3.up * distanceUp - Vector3.forward * distanceAway;
    }
}