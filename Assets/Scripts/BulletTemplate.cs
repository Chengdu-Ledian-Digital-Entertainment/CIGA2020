using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹模板类
/// </summary>
[CreateAssetMenu(fileName = "Bullet", menuName = "SO/Bullet")]
public class BulletTemplate : ScriptableObject
{
    /// <summary>
    /// 子弹飞行速度
    /// </summary>
    public float flySpeed;
    /// <summary>
    /// 子弹颜色
    /// </summary>
    public Color color;
    /// <summary>
    /// 子弹伤害
    /// </summary>
    public int damage;
}
