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
                () =>
                {
                    var bullet = Instantiate(_bulletPrefab);
                    bullet.Init(ReturnBullet);
                    return bullet;
                },
                bullet => { bullet.gameObject.SetActive(true); },
                bullet => { bullet.gameObject.SetActive(false); },
                bullet => { Destroy(bullet.gameObject); }, false, _bulletAmount, _bulletAmount + 5);
        }

        public Bullet RequestBullet()
        {
            return _bulletPool.Get();
        }

        private void ReturnBullet(Bullet bullet)
        {
            _bulletPool.Release(bullet);
        }
    }
}