using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Mike : AbstractCharacter
{
    private List<Transform> _blocks = new List<Transform>();
    private bool _isHittingAllowed = false;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _subZeroInGun;

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

   

    protected override void Hit(Vector2 mousePosition)
    {
        if (!_isHittingAllowed) return;
        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        Vector2 throwingDirection = Camera.main.ScreenToWorldPoint(mousePosition) - position;

        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
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
}