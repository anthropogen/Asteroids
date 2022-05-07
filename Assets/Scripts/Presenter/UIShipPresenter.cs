using Asteroids.Model;
using TMPro;
using UnityEngine;

namespace Asteroids.Presenter
{
    public class UIShipPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text positionText;
        [SerializeField] private TMP_Text rotationText;
        [SerializeField] private TMP_Text speedText;
        [SerializeField] private TMP_Text laserCountText;
        [SerializeField] private TMP_Text laserTimeToRestoreText;
        private Ship ship;
        public void Init(Ship ship)
        {
            this.ship = ship;
            OnBulletsChanged(ship.LaserGun.Bullets, ship.LaserGun.MaxBullets);
            OnTimeToRestoreChanged(ship.LaserGun.Timer.CurrentTime, ship.LaserGun.Timer.TimeDelay);
            Subscribe(ship);
        }


        private void OnTimeToRestoreChanged(float current, float timeRestoring)
            => laserTimeToRestoreText.text = $"Restoring:{timeRestoring - current:0.0})";

        private void OnBulletsChanged(int current, int max)
            => laserCountText.text = $"Lasers{current}/{max}";

        private void OnSpeedChanged(float speed)
            => speedText.text = $"Speed:{Mathf.RoundToInt(speed)}";

        private void OnRotationChanged(Quaternion rotation)
            => rotationText.text = $"Rotation:{Mathf.RoundToInt(rotation.eulerAngles.z)}°";

        private void OnPositionChanged(Vector3 pos)
            => positionText.text = $"Position:{new Vector2(pos.x, pos.y)}";

        private void Subscribe(Ship ship)
        {
            ship.PositionChanged += OnPositionChanged;
            ship.RotationChanged += OnRotationChanged;
            ship.SpeedChanged += OnSpeedChanged;
            ship.LaserGun.BulletsChanged += OnBulletsChanged;
            ship.LaserGun.Timer.TimeChanged += OnTimeToRestoreChanged;
        }
        private void OnDisable()
        {
            ship.PositionChanged -= OnPositionChanged;
            ship.RotationChanged -= OnRotationChanged;
            ship.SpeedChanged -= OnSpeedChanged;
            ship.LaserGun.BulletsChanged -= OnBulletsChanged;
            ship.LaserGun.Timer.TimeChanged -= OnTimeToRestoreChanged;
        }
    }
}