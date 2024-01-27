using System.Collections.Generic;
using UnityEngine;

public class Mike : AbstractCharacter
{
    private List<Transform> _blocks = new List<Transform>();
    [SerializeField] private GameObject _projectile;
    


    protected override void Move(Vector2 direction)
    {
        base.Move(direction);
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
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("MoveableBlock"))
        {
            if (_isAbilityPressed)
            {
                AttachBlock(other.transform);
            }
        }
    }

    protected override void Hit(Vector2 mousePosition)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y);
        Vector2 throwingDirection = Camera.main.ScreenToWorldPoint(mousePosition) - position;

        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        projectile.GetComponent<Bullet>().SetFlyingDirection(throwingDirection);
    }
}