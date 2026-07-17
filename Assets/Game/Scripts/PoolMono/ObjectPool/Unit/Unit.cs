using UnityEngine;

namespace Game.Scripts.PoolMono.ObjectPool.Unit
{
    public class Unit : PhysicalBody<Unit>
    {
        private const int Damage = 25;
        private Coroutine _startTimeLife;
        private Vector3[] _positions;
        private Quaternion[] _rotations;

        [field: SerializeField] public UnitDeath Death { get; private set; }
        [field: SerializeField] public GameObject Root { get; private set; }

        public Animator Animator { get; private set; }
        public Collider Collider { get; private set; }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Collider = GetComponent<Collider>();

            Death.gameObject.SetActive(true);
            var transforms = Death.GetComponentsInChildren<Transform>();
            Death.gameObject.SetActive(false);
            _positions = new Vector3[transforms.Length];
            _rotations = new Quaternion[transforms.Length];

            for (int i = 0; i < transforms.Length; i++)
            {
                _positions[i] = transforms[i].position;
                _rotations[i] = transforms[i].rotation;
            }
        }

        private void OnEnable()
        {
            _startTimeLife = StartCoroutine(StartTimeLife());
        }

        private void OnDisable()
        {
            if (_startTimeLife != null)
                StopCoroutine(_startTimeLife);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent(out IDamagable.IDamagable damagable))
            {
                Attack(damagable);
            }
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        public override void ResetSettings()
        {
            base.ResetSettings();
            Collider.enabled = true;
            Root.SetActive(true);
            Animator.enabled = true;

            var rigidbodies = Death.GetComponentsInChildren<Rigidbody>();
            var transforms = Death.GetComponentsInChildren<Transform>();

            foreach (var rigidbody in rigidbodies)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }

            for (int i = 0; i < transforms.Length; i++)
            {
                transforms[i].position = _positions[i];
                transforms[i].rotation = _rotations[i];
            }

            Death.gameObject.SetActive(false);
        }

        private void Attack(IDamagable.IDamagable damagable) =>
            damagable.TakeDamage(Damage);
    }
}