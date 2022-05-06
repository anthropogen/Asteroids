using Asteroids.Model;
using System;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class Presenter : MonoBehaviour
    {
        private IUpdatable updatable;
        protected Transformable Model { get; private set; }
        protected event Action UpdateAction;
        public void Init(Transformable model)
        {
            this.Model = model;
            model.PositionChanged += OnPositionChanged;
            model.RotationChanged += OnRotationChanged;
            model.Destoyed += OnDestroyed;
            model.MoveTo(model.Position);
            model.Rotate(model.Rotation);
            if (model is IUpdatable)
                updatable = model as IUpdatable;
        }

        private void Update()
        {
            if (updatable != null)
                updatable.OnUpdate(Time.deltaTime);
            UpdateAction?.Invoke();
        }

        private void OnDisable()
        {
            if (Model == null)
                return;
            Model.PositionChanged -= OnPositionChanged;
            Model.RotationChanged -= OnRotationChanged;
            Model.Destoyed -= OnDestroyed;
        }

        protected virtual void OnRotationChanged(Quaternion newRotation)
            => transform.rotation = newRotation;

        protected virtual void OnPositionChanged(Vector3 newPosition)
            => transform.position = newPosition;

        protected virtual void OnDestroyed()
            => Destroy(gameObject);
    }
}
