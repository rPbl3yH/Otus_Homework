using UnityEngine;

public class PlayerInputObserver : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private PlayerMoveController _moveController;
    [SerializeField] private PlayerInputController _inputController;
    private RoadSide _roadSide;

    void IGameStartListener.OnGameStarted() {
        _roadSide = RoadSide.Middle;
        _inputController.OnInputSide += InputController_OnMovingSide;
    }

    void IGameFinishListener.OnGameFinished() {
        _inputController.OnInputSide -= InputController_OnMovingSide;
    }

    private void InputController_OnMovingSide(bool isLeft) {
        if(isLeft && _roadSide == RoadSide.Left) {
            return;
        }

        if(!isLeft && _roadSide == RoadSide.Right) {
            return; 
        }

        UpdateRoadSide(isLeft);

        var direction = isLeft? Vector3.left : Vector3.right;
        _moveController.Move(direction);
    }

    private void UpdateRoadSide(bool isLeft) {
        if(_roadSide == RoadSide.Left) {
            _roadSide = RoadSide.Middle;
        }
        else if (_roadSide == RoadSide.Middle) {
            _roadSide = isLeft ? RoadSide.Left : RoadSide.Right;
        }
        else if (_roadSide == RoadSide.Right) {
            _roadSide = RoadSide.Middle;
        }
    }
}
