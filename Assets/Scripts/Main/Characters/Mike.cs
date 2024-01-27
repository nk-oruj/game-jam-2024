using System.Collections.Generic;
using UnityEngine;

public class Mike : AbstractCharacter
{
    private List<Transform> _blocks = new List<Transform>();

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