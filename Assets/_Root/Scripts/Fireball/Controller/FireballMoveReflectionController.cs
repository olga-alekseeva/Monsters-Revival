using Abstractions.Basics;
using Abstractions.Controllers;
using Abstractions.Controllers.Fireball;
using Abstractions.Fireball;
using Abstractions.InputSystem;
using MonstersRevival;
using Newtonsoft.Json.Bson;
using Player;
using Settings;
using UnityEngine;

namespace Controllers
{
    internal sealed class FireballMoveReflectionController : IFireballMoveReflectionController
    {
        private IFireballModel _fireballModel;
        private IFireballView _fireballView;

        private Vector2 _lastVelocity;

        public FireballMoveReflectionController(IFireballModel fireballModel, IFireballView fireballView)
        {
            _fireballModel = fireballModel;
            _fireballView = fireballView;

            _lastVelocity = Vector2.zero;
        }

        public void Update(float deltaTime)
        {
            if (_fireballView.Rigidbody.velocity == Vector2.zero)
            {
                _fireballView.Rigidbody.velocity = _fireballModel.Direction.normalized * _fireballModel.Speed;
            }

            Vector2 normalSpeed = _fireballView.Rigidbody.velocity.normalized * _fireballModel.Speed;
            if (_fireballView.Rigidbody.velocity != normalSpeed)
            {
                _fireballView.Rigidbody.velocity = normalSpeed;
            }

            Vector2 currentVelocity = _fireballView.Rigidbody.velocity.normalized;
            if (_lastVelocity != Vector2.zero && currentVelocity != _lastVelocity)
            {
                _fireballView.Rigidbody.velocity = Quaternion.Euler(0, 0, Random.Range(-1f, 1f)) * _fireballView.Rigidbody.velocity;
                currentVelocity = _fireballView.Rigidbody.velocity.normalized;
            }
            _lastVelocity = currentVelocity;
        }
    }
}
