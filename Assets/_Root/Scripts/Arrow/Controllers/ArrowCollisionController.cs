using Abstractions.Arrow;
using Abstractions.Basics;
using Abstractions.Controllers;
using Settings;
using UnityEngine;

namespace Controllers.Arrow
{
    internal sealed class ArrowCollisionController : IArrowCollisionController
    {
        private IArrowModel _model;
        private IArrowView _view;

        public ArrowCollisionController(IArrowModel model, IArrowView view)
        {
            _model = model;
            _view = view;
            _view.ActionOnCollisionEnter += OnCollisionEnter2D;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag(TagNames.PLAYER))
            {
                IDamageable damageable = collision.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.SetDamage(_model);
                }
            }
            GameObject.Destroy(_view.GameObject);
        }
    }
}
