using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny : AbstractCharacter
{
    public Transform TargetPosition;

    [SerializeField] private AudioClip _runClip;

    private enum BehaviorState
    {
        Idle,
        Walk
    }

    private BehaviorState _state = BehaviorState.Idle;
    private Vector2 _direction = Vector2.left;
    private bool _isFallen = false;
    private bool _isFalling = false;
    private bool _isStanding = false;
    private bool _isLusterHit = false;
    private int _heartPoints = 3;


    protected override void Start()
    {
        base.Start();
        GameManager.Instance.ParrotSwitchEvent += ParrotEscape;
        GameManager.Instance.TakeKeyEvent += () =>
        {
            _isStanding = true;
            AudioManager.Instance.PlayAudio(_runClip);
        };
    }

    private void Update()
    {
        if (_state == BehaviorState.Walk)
        {
            Move(_direction);
            _view.Run();
        }
    }

    private void FixedUpdate()
    {
        if (_isFalling)
        {
            Fall();
        }
        if (_isStanding)
        {
            Stand();
        }
    }

    public void ParrotEscape()
    {
        _state = BehaviorState.Walk;
    }

    public void Idle()
    {
        _state = BehaviorState.Idle;
        TakeDamage();
        _view.Idle();
    }

    private void Banana()
    {
        if (!_isFallen)
        {
            _state = BehaviorState.Idle;
            _view.Idle();
            _isFalling = true;
        }
    }

    private void Fall()
    {
        float step = 3f;

        transform.rotation = transform.rotation * Quaternion.Euler(Vector3.forward * step);

        if (transform.rotation.eulerAngles.z > 90f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            _isFallen = true;
            _isFalling = false;
        }
    }

    private void Stand()
    {
        float step = 3f;

        transform.rotation = transform.rotation * Quaternion.Euler(Vector3.back * step);

        if (Mathf.Abs(transform.rotation.eulerAngles.z) <= 3f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _isFallen = false;
            _isStanding = false;
            _direction = Vector2.right;
            _state = BehaviorState.Walk;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Banana();
        }
        else if (collision.gameObject.CompareTag("InteractableObject"))
        {
            if (collision.gameObject.GetComponent<Fridge>())
            {
                collision.gameObject.GetComponent<Fridge>().Interact(type);
            }
        }
        else if (collision.gameObject.CompareTag("PenguinHit"))
        {
            TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Luster"))
        {
            if (_isLusterHit) return;

            other.transform.parent.GetComponent<Trampoline>().MakeCoreTrigger();
            TakeDamage();

            _isLusterHit = true;
        }
    }

    public void TakeDamage()
    {
        _heartPoints--;
        if(_heartPoints <= 0)
        {
            GameManager.Instance.Win();
            _state = BehaviorState.Idle;
            _view.Idle();
            _isFalling = true;
        }
    }
}
