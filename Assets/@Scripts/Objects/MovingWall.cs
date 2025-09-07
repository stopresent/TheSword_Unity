using DG.Tweening;
using UnityEngine;
using static Define;
using static PlayerController;

public class MovingWall : MonoBehaviour
{
    const float adjustingDis = 0.01f;
    float _duration;
    bool _isMoving = false;
    float _offset = Define.TILE_SIZE;
    Vector3 _interpolateRayPos = new Vector3(0f, Define.TILE_SIZE / 2f, 0f);
    public Vector3 _cellPos;
    Vector3 _nextCellPos;
    public MoveDir _moveDir = MoveDir.None;
    void Start()
    {
        _cellPos = transform.position;
    }

    void Update()
    {
        
    }
    public bool Moving(Define.MoveDir moveDir, bool isDirecting)
    {
        if (_isMoving && !isDirecting)
        {
            return false;
        }

        _isMoving = true;
        _nextCellPos = Vector3.zero;
        switch (moveDir)
        {
            case MoveDir.Up:
                _nextCellPos = Vector3.forward * _offset;
                break;
            case MoveDir.Down:
                _nextCellPos = Vector3.back * _offset;
                break;
            case MoveDir.Left:
                _nextCellPos = Vector3.left * _offset;
                break;
            case MoveDir.Right:
                _nextCellPos = Vector3.right * _offset;
                break;
            case MoveDir.Back:
                _nextCellPos = Vector3.back * _offset;
                break;
        }

        // Checking Forward
        // If Obstacles, Stop
        if (isObstacled())
        {
            _isMoving = false;
            return false;
        }

        // Move
        _cellPos += _nextCellPos;
        transform.DOMove(_cellPos, _duration).SetEase(Ease.Linear).OnComplete(() =>
        {
            _isMoving = false;
        });

        return true;
    }

    public bool isObstacled()
    {
        bool somethingExist = false;

        RaycastHit hit;
        Physics.Raycast(transform.position + _interpolateRayPos, _nextCellPos, out hit, _offset * 1.3f);

        if (hit.collider != null)
        {
            // Checking Wall
            if (hit.collider.gameObject.layer == (int)Define.Layer.Wall)
            {
                somethingExist = true;
            }
            else if (hit.collider.gameObject.layer == (int)Define.Layer.MovingWall)
            {
                
            }
        }

        //Managers.Game.SaveGame();

        return somethingExist;
    }

    public enum TouchDir
    {
        None,
        Right,
        Left,
        FaceToFace,
    }

    public TouchDir GetTouchDirection(Transform otherObject, Vector3 otherObjectDir)
    {
        // 플레이어와 otherObject 간의 방향 벡터 계산
        Vector3 playerDir = (transform.position - otherObject.position).normalized;

        // otherObject의 Local Space X축 (Right)
        Vector3 rightDir = otherObject.right;

        // Y축 평면으로 투영
        Vector3 flattenedPlayerDir = new Vector3(playerDir.x, 0, playerDir.z).normalized;
        Vector3 flattenedRightDir = new Vector3(rightDir.x, 0, rightDir.z).normalized;

        // 정면 충돌 여부 확인
        float dotProduct = Vector3.Dot(otherObjectDir, flattenedPlayerDir);
        if (dotProduct > 0.98f) // 정면 기준 충돌
        {
            return TouchDir.FaceToFace;
        }
        else if (dotProduct > 0.7f)
        {
            if (flattenedPlayerDir.x > 0) // 오른쪽
            {
                return TouchDir.Right;
            }
            else if (flattenedPlayerDir.x < 0) // 왼쪽
            {
                return TouchDir.Left;
            }
        }

        return TouchDir.None; // 정면 충돌 아님
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == (int)Define.Layer.PedalSwitch)
        {
            // Create Red Key
            //GameObject potion = Managers.Resource.Instantiate("ConsumableItem");
            GameObject item = Instantiate(Resources.Load("ConsumableItem") as GameObject);
            item.transform.localPosition = Vector3.right * _offset;
            item.GetComponent<ConsumableItem>().id = 2;
            item.name = $"CItem{item.GetComponent<ConsumableItem>().id}";
        }
    }
}
