﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace XPaint
{
    public class XCanvas : Panel
    {
        #region private const
        
        // canvas half width
        private static readonly int CW = 60;

        // canvas half height
        private static readonly int CH = 40;
        
        #endregion

        #region private var

        private XKernel kernel;

        private Size imageSize;
        private Size canvasSizeMin;
        private Size canvasSizeActual;
        private Rectangle rectImageOutLine;
        private Rectangle rectImage;

        #endregion

        #region constructors

        public XCanvas()
        {
            base.SetStyle(ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer, true);
            base.ResizeRedraw = true;
            base.BorderStyle = BorderStyle.FixedSingle;
            base.AutoScrollMinSize = Size.Empty;
            initialValue();
        }

        private void initialValue()
        {
            kernel = new XKernel(new Size(600, 480));
            imageSize = kernel.FinalBitmap.Size;

            WhenImageSizeChanged();
            RecalculateCanvas();                        

            kernel.FinalBitmapChanged += new EventHandler(RefleshFinalBitmapChanged);
            kernel.SelectedShapesChanged += new EventHandler(kernel_SelectedObjectsChanged);
            kernel.Selecting += new EventHandler(kernel_SelectToolInSelecting);
            kernel.CursorTypeChanged += new EventHandler(kernel_CursorTypeChanged);

            kernel.SetTool(ToolType.Line);//mmmmmmmmmmmmmmmmmmmmmmmmm
        }                               

        #endregion

        #region event handler

        private void RefleshFinalBitmapChanged(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        private void kernel_SelectedObjectsChanged(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        private void kernel_SelectToolInSelecting(object sender, EventArgs e)
        {
            base.Invalidate();
        }

        private void kernel_CursorTypeChanged(object sender, EventArgs e)
        {
            switch (kernel.CursorType)
            {
                case ToolCursorType.EllipseTool:
                    base.Cursor = XCursors.ToolEllipse;
                    break;
                case ToolCursorType.LineTool:
                    base.Cursor = XCursors.ToolLine;
                    break;
                case ToolCursorType.RectTool:
                    base.Cursor = XCursors.ToolRect;
                    break;
                case ToolCursorType.HandTool:
                    base.Cursor = XCursors.Pan;
                    break;
                case ToolCursorType.ShapeSelect_Move:
                    base.Cursor = Cursors.SizeAll;
                    break;
                case ToolCursorType.ShapeSelect_DragLineVertex:
                    base.Cursor = XCursors.Select2;
                    break;
                case ToolCursorType.ShapeSelect_Scale:
                    base.Cursor = XCursors.Size0;
                    break;
                case ToolCursorType.ShapeSelect_Rotate:
                    base.Cursor = XCursors.Rotate;
                    break;
                case ToolCursorType.ShapeSelect_Default:
                    base.Cursor = XCursors.Select;
                    break;
                case ToolCursorType.Default:
                    base.Cursor = Cursors.Default;
                    break;
                case ToolCursorType.CustomTool:
                    //..
                    break;

            }
        }

        #endregion

        #region override methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(Point.Empty, ClientSize));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            //
            e.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
            e.Graphics.FillRectangle(Brushes.White, rectImage);
            e.Graphics.DrawRectangle(Pens.DarkGray, rectImageOutLine);
            e.Graphics.DrawImage(kernel.FinalBitmap, rectImage.Location);
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(
                rectImage.Location.X + AutoScrollPosition.X,
                rectImage.Location.Y + AutoScrollPosition.Y);

            // 绘制选择区域矩形
            if (kernel.IsInSelecting)
            {
                kernel.DrawSelectingRect(e.Graphics);
            }
            // 绘制已选择对象矩形
            if (kernel.SelectedShapesCount > 0)
            {
                kernel.DrawSizableRects(e.Graphics);
            }

            e.Graphics.ResetTransform();
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            RecalculateCanvas();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            kernel.MouseDown(TranslatePointForKernelImage(e.Location));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            kernel.MouseMove(TranslatePointForKernelImage(e.Location));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            kernel.MouseUp(TranslatePointForKernelImage(e.Location));
        }

        #endregion

        #region private methods

        private Point TranslatePointForKernelImage(Point pos)
        {
            pos.Offset(-rectImage.Location.X - AutoScrollPosition.X, 
                -rectImage.Location.Y - AutoScrollPosition.Y);
            return pos;
        }

        private void RecalculateCanvas()
        {
            int w = (ClientSize.Width - imageSize.Width) / 2;
            int h = (ClientSize.Height - imageSize.Height) / 2;
            int cw = Math.Max(w, CW);
            int ch = Math.Max(h, CH);
            canvasSizeActual = new Size(imageSize.Width + cw * 2, imageSize.Height + ch * 2);

            rectImage = new Rectangle(new Point(cw, ch), imageSize);
            rectImageOutLine = new Rectangle(cw - 1, ch - 1, imageSize.Width + 1, imageSize.Height + 1);
        }

        private void WhenImageSizeChanged()
        {
            canvasSizeMin = new Size(imageSize.Width + CW * 2, imageSize.Height + CH * 2);
            base.AutoScrollMinSize = canvasSizeMin;
        }

        #endregion

        #region private properties
        


        #endregion

        #region public properties

        public XKernel Kernel
        {
            get { return kernel; }
        }

        #endregion

        #region public methods



        #endregion
    }
}