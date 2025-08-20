# 基于Uunity DOTS1.0 吸血鬼幸存者DEMO

  
## 核心插件说明：  
DOTS —— 核心框架  
HybridCLR —— 用于C#程序集热更  
Input System —— 用于多平台输入监控  
Cinemachine —— 用于缓动跟随玩家  

  
## 核心脚本模块说明：
  
游戏入口节点：  
通过partial进行不同模块的逻辑处理：GM模块、加载模块、业务管理器模块  
<img width="310" height="109" alt="image" src="https://github.com/user-attachments/assets/a570d0db-f176-44d2-82d4-12e659ee6e35" /> \n
  
  
## ======== 玩家基础移动 ========  
MONO:  
- layerInputController —— 用于监听输入，同时更新玩家entity位置  
ECS:  
- PlayerInputSystem —— 用于分发system之间的输入信号  
- VCameraProxySystem —— 用于system同步外部相机跟随代理  
- CharacterMoveSystem —— 统一处理所有character entity（玩家、敌人、武器）的位移  
- PositionUpdateSystem —— 统一处理所有move entity的位置更新  

  
## ======== BOIDS 算法 ========  
ECS：  
- FishSchoolSystem —— 鱼群算法核心算法系统  
- FishSpawnerSystem —— 鱼群生成系统  
- FishClearerSystem —— 鱼群销毁系统
流程：
  
通过GM创建指令entity  
<img width="843" height="1088" alt="image" src="https://github.com/user-attachments/assets/0b50bea9-54f8-4a39-8159-fab63638f636" />

FishSpawnerSystem接收指令，按需生成fish，同时通过缓冲区销毁指令
<img width="986" height="796" alt="image" src="https://github.com/user-attachments/assets/788d5883-6dfb-482e-b417-d0ffbdc59439" />

FishSchoolSystem通过jobsystem每帧更新带有fishtag的entity状态    
<img width="841" height="452" alt="image" src="https://github.com/user-attachments/assets/e85c11a4-dc9a-45a9-81d2-b17dc6462f46" />
