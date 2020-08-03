# XPaint

C# 矢量绘图示例程序

![](Doc/XPaint.png)

此项目打算完成简单的矢量版的画图板。
更复杂完善的功能（模仿Sketch），请查看另外一个项目 SvgEditor:

![](Doc/svgeditor.png)

# 布局

- 顶部：常用操作，如文件、上下移动图层、删除图层、放缩、对齐等
- 左侧：色彩、控件
- 右侧：属性编辑窗口


# 功能

## 图形

- [x] line
- [x] rect
- [x] roundrect
- [x] elips
- [x] arrow
- [ ] text
- [ ] arc
- [ ] curve
- [ ] star
- [ ] pie
- [ ] triangle
- [ ] polyline
- [ ] polygon
- [ ] path


## 图层处理

- [x] 图层列表
- [x] 在图层列表中点击，选中图层（可多选）
- [x] 在图层列表中显示当前选择图层
- [x] 在画板中多选图层
- [x] 取消选择图层
- [x] 全部选择图层 & Ctrl+A
- [x] 删除图层 Delete/Back
- [x] 旋转图层
- [x] 放缩图层
- [x] **局部刷新技术**
- [ ] 若有重叠情况，可右键菜单选择图层
- [ ] 锁定
- [ ] 隐藏
- [ ] 设置位置
- [ ] 锁定比例放缩
- [ ] 锚点连接线
- [ ] 点击 delete 删除图层
- [ ] 翻转图层（水平 & 垂直）

## 图形属性

- [x] 将任意图形都是依赖于 path 进行编辑
- [ ] corner：刚、对称曲线、自由曲线、圆角半径
- [ ] symbol
- [ ] 锚点


## 画布

- [ ] 无限画布
- [ ] 拖动画布：双指；空格+鼠标拖动；
- [ ] 放缩画布：双指缩放；ctrl+鼠标中键
- [ ] 对齐
- [ ] 辅助线
- [ ] 画板：可以放置在画布的任意位置、是图形的容器
- [ ] 背景色或透明色
- [ ] Ruler


## 文件处理

- [ ] 新建
- [ ] 保存为 .xpaint 文件（json+zip)
- [ ] 导出为 .sketch 文件
- [x] 导出为 .png 文件
- [ ] 导出为 .pdf 文件
- [ ] 导出为 .html 文件
- [ ] 导出选中图层
- [ ] 导入 .svg 文件
- [ ] 拖入 .xpaint 文件
- [ ] 拖入图片文件（jpg、png、bmp、tif）
- [ ] 拖动svg文件



## 键盘

- [ ] ctrl+A 全选
- [ ] 选中图层后，按住shift拖动图层，显示辅助线，并自动吸附
- [ ] 选中图层后，按住shift旋转图层，旋转时限制角度为45度的倍数
- [ ] 选中图层后，按住option/alt键盘拖动图层，复制图层
- [ ] 选中图层后，按 delete 删除选中图层


## 编辑

- [ ] 剪切\拷贝\黏贴
- [ ] 对齐
- [ ] 无限撤销


## 插件

- [ ] 插件接口
- [ ] 部署插件
- [ ] 插件市场
- [ ] 插件更新
- [ ] 协同（发布到网络位置）






