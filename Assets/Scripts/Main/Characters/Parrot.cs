using System;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : AbstractCharacter
{
    [SerializeField] private GameObject _laser;
    
    private List<Transform> _blocks = new List<Transform>();

    private void AttachBlock(Transform block)
    {
        block.parent = transform;
        _blocks.Add(block);

        if (block.GetComponent<Rigidbody2D>())
        {
            block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void DetachBlocks()
    {
        _blocks.ForEach(block =>
        {
            block.parent = null;
            if (block.GetComponent<Rigidbody2D>())
            {
                block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        });
        _blocks.Clear();
    }
    

    protected override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);



        if (other.transform.CompareTag("MoveableBlock"))
        {
            if (_isAbilityPressed)
            {
                AttachBlock(other.transform.parent);
            }
        }
    }

    
    protected override void StopAbility()
    {
        base.StopAbility();
        DetachBlocks();
    }
    
    protected override void Hit(Vector2 mousePos)
    {
        base.Hit(mousePos);
        _laser.SetActive(true);
    }
    protected override void HitExit()
    {
        base.HitExit();
        _laser.SetActive(false);
    }
    
}
