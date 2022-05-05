using Asteroids.Model;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class Presenter : MonoBehaviour
    {
        private Transformable model;
        private IUpdatable updatable;
        public void Init(Transformable model)
        {
            this.model = model;
            model.PositionChanged += OnPositionChanged;
            model.RotationChanged += OnRotationChanged;
            model.Destoyed += OnDestroyed;
            if (model is IUpdatable)
                updatable = model as IUpdatable;
        }

        private void Update()
        {
            if (updatable != null)
                updatable.OnUpdate(Time.deltaTime);
        }

        private void OnDisable()
        {
            if (model == null)
                return;
            model.PositionChanged -= OnPositionChanged;
            model.RotationChanged -= OnRotationChanged;
            model.Destoyed -= OnDestroyed;
            Debug.Log("Disable");

        }

        private void OnRotationChanged(Quaternion newRotation)
            => transform.rotation = newRotation;

        private void OnPositionChanged(Vector3 newPosition)
            => transform.position = newPosition;

        private void OnDestroyed()
            => Destroy(gameObject);
    }
}
