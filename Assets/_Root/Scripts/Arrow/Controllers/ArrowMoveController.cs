using Abstractions.Arrow;
using Abstractions.Basics;
using Abstractions.Controllers;
using UnityEngine;

namespace Controller
{
    internal sealed class ArrowMoveController : IArrowMoveController
    {
        private IMoveModel _moveModel;
        private IRigidbody _moveView;

        public ArrowMoveController(IMoveModel moveModel, IRigidbody moveView)
        {
            _moveModel = moveModel;
            _moveView = moveView;
        }


        public void Update(float deltaTime)
        {
            Vector2 nextPosition = _moveView.Rigidbody.transform.position + _moveView.Rigidbody.transform.up.normalized * _moveModel.MoveSpeed * deltaTime;
            _moveView.Rigidbody.velocity = Vector2.zero;
            _moveView.Rigidbody.MovePosition(nextPosition);
        }
    }
}

namespace Abstractions.Arrow
{
    internal interface IMoveModel
    {
        public float MoveSpeed { get; }
    }

}