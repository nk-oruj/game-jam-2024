using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mike : AbstractCharacter
{
    private List<Transform> _blocks = new List<Transform>();
    protected override void Move(Vector2 direction)
    {
        base.Move(direction);

        CheckDirection(direction);
    }

    private void CheckDirection(Vector2 direction)
    {
        if (_blocks.Count > 0 && !CheckBlockDirection(_blocks[0])) {
            DetachBlocks();
        }
    }

    private bool CheckBlockDirection(Transform block)
    {
        return Mathf.Sign(_currentDirection.x) == Mathf.Sign(block.localPosition.x);
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
            Debug.Log(CheckBlockDirection(other.transform));

            if (CheckBlockDirection(other.transform))
            {
                AttachBlock(other.transform);
            }
        }
    }
}
