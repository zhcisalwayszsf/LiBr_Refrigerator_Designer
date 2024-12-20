溴化锂吸收式制冷机组设计工具
============================

# 简介

本软件用C#编写，用于设计**蒸汽型并联流程双效溴化锂吸收式制冷机组**时，计算其中各部件的传热系数和传热面积 。 旨在通过计算机迭代计算，简化假设传热系数计算传热面积，再核算传热系数的计算过程。

## 软件界面及功能

软件内有：冷凝器、吸收器、蒸发器、高压发生器、低压发生器、凝水回热器、高（低）温热交换器（管壳式换热器）、传热系数（k值）手动计算、LiBr物性参数计算，共9个计算工具。

 1. **冷凝器** ，用于计算冷凝器的传热面积、管内外表面传热系数、核算传热系数，管内（ ~~外~~ ~~如果有的话~~ ）流速；
 2. **吸收器** ，用于计算**喷淋式**吸收器的传热面积、管内外表面传热系数、核算传热系数，管内，外流速；
 3. **蒸发器** ，用于计算**喷淋式**蒸发器的传热面积、管内外表面传热系数、核算传热系数，管内，外流速；
 4. **高压发生器** ，用于计算**沉浸式**高压发生器（**蒸汽**热源）的传热面积、管内表面传热系数、核算传热系数，管内，外流速，需要自定管外表面传热系数Ko；
 5. **低压发生器** ，用于计算**沉浸式**低压发生器（**热水**热源）的传热面积、管内表面传热系数、核算传热系数，管内，外流速，需要自定管外表面传热系数**ao**；
 6. **凝水回热器** ，用于计算凝水回热器按照正三角排布管排时所需的半数管子数（**不建议使用**）；
 7. **管壳式换热器** ，用于计算采用**管壳式换热器**的高温和低温热交换器的传热系数和传热面积，管子数，管内流速，筒侧流体流速，等参数；
 8. **K值手动计算** ，用于计算传热管基于其**管内外传热系数~Ki~，Ko**（而非**表面**传热系数ai，ao）的传热系数，有多种选择模式（第四种热阻法应该是错误的，不建议使用）；
 9. **LiBr物性参数**， 用于手动计算溴化锂水溶液在特定热力学状态下的物性参数，普朗克数、动力粘度、导热系数等。
   ## 计算公式参考资料
  1. 吴业正 ... [等] 编著 吴业正主编.《制冷与低温技术原理》[M].西安.高等教育出版社,2015(4)139-176.
  2. 戴永庆.《溴化锂吸收式制冷技术及应用》[M].北京.机械工业出版社,200(5).83-109
  3. GB/T 18431-2014,蒸汽和热水型溴化锂吸收式冷水机组[S].
  4. 换热器原理与设计，（具体哪一本我忘记了，主要参考了管壳式换热器的部分）

## 软件界面
1. 主菜单  
![mainMenu](https://github.com/user-attachments/assets/8e16a694-72dd-46f5-98e6-889e43cba849#pic_center)
2. 高压发生器  
![1](https://github.com/user-attachments/assets/a8a26829-0585-4b33-b7d1-f7a4ef595b7a#pic_center)  
3.  管壳式换热器
![2](https://github.com/user-attachments/assets/a07814d1-d717-4392-add1-9776702a1195)

### 按钮介绍
1. 计算：用于计算。
2. 置于顶层：用于置顶窗口，方便记录数据。
3. 示例：对比示例，确定参数输入值（位置）。
4. 。。。。。。
