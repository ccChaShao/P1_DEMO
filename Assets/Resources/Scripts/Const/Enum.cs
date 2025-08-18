
/// <summary>
/// 角色类型
/// </summary>
public enum CharacterType
{
    Player,         // 玩家（这里不区分玩家一二）
    Enemy,          // 敌人
    
    PlayerBullet,   // 玩家子弹
    EnemyBullet,    // 敌人子弹
}

public enum WeaponType
{
    LineShoot,          // 直线范围武器
    CircleShoot,        // 圆形散射范围武器
}

/// <summary>
/// 玩家类型
/// </summary>
public enum PlayerType
{
    MainPlayer,         // 主玩家
    SecondaryPlayer         // 第二玩家
}
