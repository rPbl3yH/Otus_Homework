using UnityEngine;

public class PlayerMoveController : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private MoveComponent _moveController;
    [SerializeField] private MoveInput _inputController;
    private RoadSide _roadSide;

    void IGameStartListener.OnGameStarted() {
        _roadSide = RoadSide.Middle;
        _inputController.OnMove += InputController_OnMovingSide;
    }

    void IGameFinishListener.OnGameFinished() {
        _inputController.OnMove -= InputController_OnMovingSide;
    }

    private void InputController_OnMovingSide(InputDirection inputDirection) {
        if(inputDirection == InputDirection.Left && _roadSide == RoadSide.Left) {
            return;
        }

        if(inputDirection == InputDirection.Right && _roadSide == RoadSide.Right) {
            return; 
        }

        UpdateRoadSide(inputDirection);

        var direction = inputDirection == InputDirection.Left ? Vector3.left : Vector3.right;
        _moveController.Move(direction);
    }

    private void UpdateRoadSide(InputDirection inputDirection) {
        if(_roadSide == RoadSide.Left) {
            _roadSide = RoadSide.Middle;
        }
        else if (_roadSide == RoadSide.Middle) {
            _roadSide = inputDirection == InputDirection.Left ? RoadSide.Left : RoadSide.Right;
        }
        else if (_roadSide == RoadSide.Right) {
            _roadSide = RoadSide.Middle;
        }
    }
}
