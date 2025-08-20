基于Uunity DOTS1.0 吸血鬼幸存者DEMO

核心插件说明：
DOTS —— 核心框架
      Entities
      Job System
      Burst
      ...
HybridCLR —— 用于C#程序集热更
Input System —— 用于多平台输入监控
Cinemachine —— 用于缓动跟随玩家

核心脚本模块说明：

游戏入口节点：
通过partial进行不同模块的逻辑处理：GM模块、加载模块、业务管理器模块
<img width="310" height="109" alt="image" src="https://github.com/user-attachments/assets/a570d0db-f176-44d2-82d4-12e659ee6e35" />

======== 玩家基础移动 ========
MONO:
      PlayerInputController —— 用于监听输入，同时更新玩家entity位置
ECS:
      PlayerInputSystem —— 用于分发system之间的输入信号
      VCameraProxySystem —— 用于system同步外部相机跟随代理
      CharacterMoveSystem —— 统一处理所有character entity（玩家、敌人、武器）的位移
      PositionUpdateSystem —— 统一处理所有move entity的位置更新

======== BOIDS 算法 ========
