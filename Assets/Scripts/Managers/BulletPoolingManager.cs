using UnityEngine;
using UnityEngine.Pool;

namespace Managers
{
    public class BulletPoolingManager : MonoBehaviour
    {
        public static BulletPoolingManager SharedInstance;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] int _bulletAmount = 10;

        private IObjectPool<Bullet> _bulletPool;

        private void Awake()
        {
            SharedInstance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            _bulletPool = new ObjectPool<Bullet>(
                () => Instantiate(_bulletPrefab),
                bullet => { bullet.gameObject.SetActive(true); },
                bullet => { bullet.gameObject.SetActive(false); },
                bullet => { Destroy(bullet.gameObject); }, false, _bulletAmount, _bulletAmount + 5);
        }

        public Bullet RequestBullet()
        {
            var bullet = _bulletPool.Get();
            bullet.Init(ReturnBullet);
            return bullet;
        }

        private void ReturnBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}