using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Projectile : MonoBehaviour {

    private BoundsCheck bndCheck;
    private Renderer rend;

    [Header("Set Dynamically")]
    public Rigidbody rigid;
    [SerializeField]
    private WeaponType _type;

    private float birthTime;
    private Vector3 birthPosition;
    private Vector3 birthVelocity;

    // This public property masks the field _type and takes action when it is set
    public WeaponType type
    {
        get
        {
            return (_type);
        }
        set
        {
            SetType(value);
        }
    }
    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        birthTime = Time.time;
        birthPosition = this.transform.position;
        birthVelocity = rigid.velocity;
    }

    private void Update()
    {
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        } else if (_type == WeaponType.phaser )
        {
            Vector3 tempPos = this.transform.position;

            float age = Time.time - birthTime;
            float theta = Mathf.PI * 2 * age / .6f;
            float sin = Mathf.Sin(theta);
            tempPos.x = birthPosition.x + 2 * sin;
            this.transform.position = tempPos;
        }
    }

    ///<summary>
    /// Sets the _type private field and colors this projectile to match the
    /// WeaponDefinition.
    /// </summary>
    /// <param name="eType">The WeaponType to use.</param>
    public void SetType(WeaponType eType)
    {
        // Set the _type
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    }
}
