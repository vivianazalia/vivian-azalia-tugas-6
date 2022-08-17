using Agate.MVC.Base;
using Sapi.SpaceInvader.Gameplay.Spawner.BulletSpawner;
using Sapi.SpaceInvader.Gameplay.Spawner.PlayerSpawner;

namespace Sapi.SpaceInvader.Gameplay
{
    public class GameplayInputConnector : BaseConnector
    {
        private PlayerSpawnerController _playerSpawnerController;
        private BulletSpawnerController _bulletSpawnerController;

        protected override void Connect()
        {
            Subscribe<InputMessage>(OnInputKeyPressed);
            Subscribe<ShootMessage>(OnPlaneCommandedShoot);
        }

        protected override void Disconnect()
        {
            Unsubscribe<InputMessage>(OnInputKeyPressed);
        }

        private void OnInputKeyPressed(InputMessage message)
        {
            _playerSpawnerController.OnInputKeyPressed(message.PlayerIndex, message.InputKey);
        }

        private void OnPlaneCommandedShoot(ShootMessage message)
        {
            _bulletSpawnerController.SpawnBullet(message.ShootPosition, message.IsFromAlly, message.BulletSpeed);
        }
    }
}