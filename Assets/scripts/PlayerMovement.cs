using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Приватные переменные
    Quaternion _rotation = Quaternion.identity;
    [SerializeField] private Transform _Gun1;
    [SerializeField] private Transform _enemy;
    [SerializeField] private GameObject _Bullet;
    private Vector3 _direction;
    private Animator _anim;
    private Rigidbody _rb;
    private bool _isSprint;
    private bool _isFire;
    bool facingRight;

    #endregion

    #region Публичные переменные
    [HideInInspector] public float damage;
    public int Health;
    public Slider Slider;
    
    public GameObject light;
    public float TurnSpeed = 20f;
    public float speed = 2;
    public float speedSprint = 2;
    public float JumpForce = 3;
    public float BulletSpeed = 2;

    #endregion

    #region методы

    #region Cтандартные методы
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _direction = Vector3.zero;
        damage = 4;
    }
    private void FixedUpdate()
    {
        if (_isFire)
        {
            _isFire = false;
            Fire();
        }
        move();
    }
    void Update()
    {
        Slider.value = Health;
        _isSprint = Input.GetButton("Sprint");
        if (Input.GetButton("Sprint"))
            _anim.SetBool("Run", true);
        else 
        { 
            _anim.SetBool("Run", false); 
        }
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _direction.y = 0;
        _direction = transform.TransformDirection(_direction);
        _rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, _direction, TurnSpeed * Time.deltaTime, 0f));
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _anim.SetBool("Stop Jump", true);
            _anim.SetBool("Run Jump", true);
            _anim.SetBool("Move Jump", true);
        }
        else
        {
            _anim.SetBool("Stop Jump", false);
            _anim.SetBool("Run Jump", false);
            _anim.SetBool("Move Jump", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _isFire = true;
            light.SetActive(true);
            StartCoroutine(cooldawn());
        }
            



    }
    #endregion

    #region Мои методы
    private void move()
    {
        _rb.MovePosition(_rb.position + _direction.normalized * ((_isSprint) ? speed * speedSprint : speed) * Time.deltaTime);
        _rb.MoveRotation(_rotation);
        if (_direction != Vector3.zero)
        {
            _anim.SetBool("move", true);
        }

        else
        {
            _anim.SetBool("move", false);
        }
            

    }

    private void Fire()
    {
        GameObject BulletObject = Instantiate(_Bullet, _Gun1.position, _Gun1.rotation);
        Bullet Bullet = BulletObject.transform.gameObject.GetComponent<Bullet>();
        Bullet.Initialization(damage, 30f, BulletSpeed, _enemy);
        
    }

    private IEnumerator cooldawn()
    {
        yield return new WaitForSeconds(0.2f);
        light.SetActive(false);
    }

    


    #endregion

    #endregion
}