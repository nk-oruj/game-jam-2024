using System.Collections.Generic;
using UnityEngine;

public class Mike : AbstractCharacter
{
    private List<Transform> _blocks = new List<Transform>();
    private bool _isHittingAllowed = false;
    private bool _runToTarget = false;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _subZeroInGun;
    [SerializeField] private Transform _projectileSpawningPosition;
    [SerializeField] private Transform _runTarget;

    protected override void Start()
    {
        base.Start();
        GameManager.Instance.ParrotSwitchEvent += OnParrotSwitch;
    }

    private void Update()
    {
        if (_runToTarget)
        {
            Vector2 direction = new Vector2(_runTarget.position.x - transform.position.x, 0).normalized;
            Move(direction);
            if (Vector3.Distance(_runTarget.position, transform.position) < 0.5f)
            {
                _runToTarget = false;
                Move(Vector2.zero);
            }
        }
    }

    protected override void Move(Vector2 direction)
    {
        base.Move(direction);
        if (direction.x != 0)
        {
            if (_isAbilityPressed)
            {
                _view.Push();
            }
            else
            {
                _view.Run();
            }
        }
        else
        {
            _view.Idle();
        }
    }


    public void AllowHitting()
    {
        _isHittingAllowed = true;
        _subZeroInGun.SetActive(true);
    }
    protected override void StopAbility()
    {
        base.StopAbility();
        DetachBlocks();
    }

    private void AttachBlock(Transform block)
    {
        block.parent = transform;
        _blocks.Add(block);
    }

    private void DetachBlocks()
    {
        _blocks.ForEach(block => block.parent = null);
        _blocks.Clear();
    }

    private void OnParrotSwitch()
    {
        _runToTarget = true;
    }

    protected override void Hit(Vector2 mousePosition)
    {
        if (!_isHittingAllowed) return;
        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        Vector2 throwingDirection = Camera.main.ScreenToWorldPoint(mousePosition) - position;

        GameObject projectile = Instantiate(_projectile, _projectileSpawningPosition.position, transform.rotation);
        projectile.GetComponent<Bullet>().SetFlyingDirection(throwingDirection);
        _isHittingAllowed = false;
        _subZeroInGun.SetActive(false);

    }

    protected override void OnCollisionStay2D(Collision2D other)
    {
        base.OnCollisionStay2D(other);

        if (other.transform.CompareTag("MoveableBlock"))
        {
            if (_isAbilityPressed)
            {
                AttachBlock(other.transform);
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);

        if (other.transform.CompareTag("MoveableBlock"))
        {
            if (_isAbilityPressed)
            {
                AttachBlock(other.transform);
            }
        }
    }
}