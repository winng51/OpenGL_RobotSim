# OpenGL_RobotSim

## Attention

- This is a simplified primary demo of the [RobotSim](https://github.com/StrongerSuperman/OpenGL_RobotSim) implemented with **SharpGL**

  这是通过**SharpGL**实现的示例程序[RobotSim](https://github.com/StrongerSuperman/OpenGL_RobotSim)的简化版

- The exe file is located on the dir `SharpGLWinformsApplication1\bin\debug`

  exe文件位于`SharpGLWinformsApplication1\bin\debug`目录中

- This demo just realize a simple joint movement based on the theory **Method of DH Parameters** ,and the robot model is *UR10

  该演示仅基于**DH**理论实现了简单的关节运动，并且机器人模型为*UR10*

- If you want to change the robot model, you must obtain the DH parameters and the corresponding robot-joint's model(.STL file)

  如果要更改机器人模型，则必须获取DH参数和相应的机器人关节模型（.STL文件）

## changes

Based on the original

在原版的基础上

- Added the environment setting of the visual window

  添加了可视化窗口的环境布景

- Added random action button to randomly adjust the value of six joints

  添加了随机动作按钮随机调节六个关节的数值

- Added Save Action button to save a set of values, including joint values, own position and lens position

  添加了保存动作按钮可以保存一组数值，包括关节数值、自身位置和镜头位置

- Added restore action button to restore saved values

  添加了恢复动作按钮可以恢复保存的数值

- Made some modifications to the UI design

  对UI设计进行了一些修改

## demo

![图片](https://github.com/winng51/OpenGL_RobotSim/blob/master/demo.png?raw=true)
