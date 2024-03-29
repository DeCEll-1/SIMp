﻿using SIMp.Classes;
using SIMp.Forms;
using SIMp.Render;
using SSSystemGenerator.Classes;
using SSSystemGenerator.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace SSSystemGenerator.Forms
{
    public partial class Map : Form
    {
        public float zoomValue { get; set; } = 0f;

        public PointF renderCenter { get; set; } = new PointF(0f, 0f);

        #region to remove flicker ///// https://stackoverflow.com/questions/4690426/why-do-my-winforms-controls-flicker-and-resize-slowly
        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
            RefreshPanel();
        }
        #endregion


        public PBRenderer PanelDrawer { get; set; } = null;

        #region mouse

        private void Pnl_Map_MouseUp(object sender, MouseEventArgs e)
        {
            //pnl_Map.MouseHover -= Pnl_Map_MouseMove;
            pb_Map.MouseUp -= Pnl_Map_MouseUp;

            if (e.Button == MouseButtons.Right)
            {
                endLocation = new PointF(e.X, e.Y);

                renderCenter = Helper.CombineCoordinates(renderCenter, Helper.SubtractCoordinates(endLocation, startLocation));//hope this works!

                //center = endLocation;


            }
            else if (e.Button == MouseButtons.Left)
            {
                Point mouseClickLocation = new Point(e.X, e.Y);


                //offset 
                mouseClickLocation = new Point((int)(mouseClickLocation.X - renderCenter.X), (int)(mouseClickLocation.Y - renderCenter.Y));

                //mouseClickLocation = pb_Map.PointToScreen(mouseClickLocation);

                mouseClickLocation = new Point((int)(mouseClickLocation.X / (zoomValue + 1)), (int)(mouseClickLocation.Y / (zoomValue + 1)));

                foreach (Systems system in Statics.systemList)
                {
                    system.highlights.ForEach(hl =>
                    {

                        if (hl.type == hlTypeEnum.Selection)
                        {
                            hl.isActive = false;
                        }

                    });
                }

                foreach (Systems system in Statics.systemList)
                {//https://www.jeffreythompson.org/collision-detection/point-circle.php
                    //php is dead copium
                    double distX = mouseClickLocation.X - system.location.X;
                    double distY = mouseClickLocation.Y - system.location.Y;
                    double distance = Math.Sqrt((distX * distX) + (distY * distY));
                    if (distance <= system.radius)
                    {//the click is in radius
                        system.highlights.FirstOrDefault(hl => hl.type == hlTypeEnum.Selection).isActive = true;

                        SystemForm systemForm = new SystemForm();

                        systemForm = (SystemForm)this.MdiParent.MdiChildren.FirstOrDefault(mdiKids =>
                           mdiKids.GetType() == systemForm.GetType()
                        );

                        if (systemForm == null) systemForm = new SystemForm();

                        systemForm.MdiParent = this.MdiParent;

                        systemForm.Show();

                        systemForm.BringToFront();

                        systemForm.inputSystem(system);

                        break;
                    }
                }
            }

            RefreshPanel();
        }

        public bool moveEnabled { get; set; }

        public PointF startLocation { get; set; } = new PointF(0, 0);
        public PointF endLocation { get; set; } = new PointF(0, 0);

        //private void Pnl_Map_MouseMove(object sender, EventArgs e)
        //{//change center point
        // //get current coordinates
        // //get the last coordinates
        // //subtract bla bla
        // //change center
        // //re render

        //    if (!moveEnabled) return;

        //    MouseEventArgs mouseEventArgs = (e as MouseEventArgs);

        //    PointF mouseCoordinates = new PointF(mouseEventArgs.X, mouseEventArgs.Y);

        //    center = Helper.SubtractCoordinates(center, mouseCoordinates);//hope this works!

        //    RefreshPanel();
        //}

        #region zoom

        private void pnl_Map_MouseWheel(object sender, MouseEventArgs e)
        {//https://stackoverflow.com/questions/45325726/move-shapes-on-a-panel-by-mouse
         //zoomValue = e.Delta > 0 ? zoomValue == 0 ? zoomValue = 1 : zoomValue * zoomValue : -(float)Math.Sqrt(zoomValue);

            zoomValue += e.Delta > 0 ? 0.3f : -0.3f;

            try
            {
                //TrackBar_Zoom.Value = (int)(zoomValue * 100f);
            }//"value must be in min-max uwu :3"
            catch (Exception ex)
            {
            }

            if (zoomValue <= -1f || zoomValue > float.MaxValue)
            {
                zoomValue = -0.99f;
                RefreshPanel();
                return;
            }



            #region i hate zooming
            //get current center
            //get location
            //subtract location/2 to center when zooming 2x

            //if (e.Delta > 0)
            //{
            //    //renderCenter = Helper.SubtractCoordinates(renderCenter, new PointF(e.X / (e.Delta / 100f), e.Y / (e.Delta / 100f)));//hope this works!
            //    renderCenter = Helper.SubtractCoordinates(renderCenter, new PointF(pnl_Map.Width * ((e.Delta / 100f) - 1), pnl_Map.Height * ((e.Delta / 100f) - 1)));//hope this works!
            //}
            //else
            //{
            //    renderCenter = Helper.CombineCoordinates(renderCenter, new PointF(e.X, e.Y));//hope this works!
            //}

            PanelDrawer.rendererValues.mouseEventArgs = e;

            PanelDrawer.rendererValues.zooming = true;

            //renderCenter = new PointF(-(e.X * (zoomValue)), -(e.Y * (zoomValue))); 
            #endregion

            RefreshPanel();
        }

        private void pnl_Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                startLocation = new PointF(e.X, e.Y);

                moveEnabled = true;
                //pnl_Map.MouseMove += Pnl_Map_MouseMove;
            }
            else if (e.Button == MouseButtons.Left)
            {



            }
            pb_Map.MouseUp += Pnl_Map_MouseUp;
        }

        #region zoomButtons

        private void btn_ResetMapVisuals_Click(object sender, EventArgs e)
        {
            zoomValue = 0f;

            renderCenter = new PointF(0f, 0f);

            RefreshPanel();
        }

        private void btn_Zoom_Click(object sender, EventArgs e)
        {
            zoomValue += 0.3f;

            RefreshPanel();
        }

        private void btn_DeZoom_Click(object sender, EventArgs e)
        {
            zoomValue -= 0.3f;

            RefreshPanel();
        }

        #endregion

        #endregion

        #endregion

        public Map()
        {
            InitializeComponent();
            //Misc.SetDoubleBuffer(pb_Map, true);
            UpdateColors();

            this.MouseWheel += new MouseEventHandler(pnl_Map_MouseWheel);

            Statics.Map = this;

            SuspendLayout();
            ResumeLayout();

            RefreshPanel();

        }

        public void UpdateColors() { Helper.ChangeColorMode(this.Controls); }

        public void RefreshPanel()
        {

            if (PanelDrawer == null)
            {
                //https://stackoverflow.com/a/60247726
                PanelDrawer = new PBRenderer(pb_Map, new PaintEventArgs(pb_Map.CreateGraphics(), pb_Map.DisplayRectangle));

                PanelDrawer.rendererValues = new RendererBaseClass();
            }

            PanelDrawer.rendererValues.Circles = new List<Circles>(); https://stackoverflow.com/a/60247726

            AddValuesToRenderer();

            pb_Map.Invalidate();
        }

        private void AddValuesToRenderer()
        {
            try
            {
                lbl_PanelInfo.Text =
                    "Panel Values:\nHeight: " + pb_Map.Height +
                    "\nWidth: " + pb_Map.Width +
                    "\nZoom Value: " + (zoomValue > 0 && zoomValue.ToString().Length > 5 ? zoomValue.ToString().Substring(0, 4) : zoomValue.ToString()) +
                    "\nCenter: " + renderCenter.X + " , " + renderCenter.Y +
                    "\nSystem Amount:" + Statics.systemList.Count +
                    "\n" + ((Statics.systemList.Count == 4576) ? "good" : "ohno")
                    ;
            }
            catch (Exception ex)
            {//getting parameter name lenght System.ArgumentOutOfRangeException from zoom value // because its too much/too low

            }




            List<Lines> lines = new List<Lines>();

            List<Circles> circles = new List<Circles>();

            List<Text> texts = new List<Text>();

            Font ourFont = new Font(FontFamily.GenericSansSerif, 3, FontStyle.Regular);

            SolidBrush brush = new SolidBrush(Color.White);

            foreach (Systems system in Statics.systemList)
            {
                Color colorToUse = system.systemColor;

                List<CircleBorders> borders = new List<CircleBorders>();

                system.highlights.ForEach(hl =>
                {
                    if (!hl.isActive) return;

                    borders.Add(new CircleBorders(hl.radius, hl.color, hl.thickness));
                });

                circles.Add(new Circles(system.location, system.radius, borders, system.systemColor, true));

                SystemData connectedSystemData = Statics.systemDataList.FirstOrDefault(s => s.ID == system.ID);

                string textToWriteUnderSystem = connectedSystemData?.SystemName;

                if (textToWriteUnderSystem == null) continue;

                Text text = new Text(textToWriteUnderSystem, ourFont, brush, new Point(system.location.X, system.location.Y + system.radius));

                texts.Add(text);

                //now its time for the connection lines FUCK

                // ok the plan is simple
                // you get dat fuken name of the systems from the array of strings
                // then get the system locations from those fuken systems 
                // then make lines between this one and those
                // FUCK
                // İT WORKS ĞĞĞĞĞĞĞĞĞĞĞĞĞ


                string[] placesThisSystemConnectsTo = Statics.Lines[connectedSystemData.SystemName];

                for (int i = 0; i < placesThisSystemConnectsTo.Length; i++)
                {
                    SystemData data = Statics.systemDataList.FirstOrDefault(x => x.SystemName == placesThisSystemConnectsTo[i]);

                    Systems connectedSystem = Statics.systemList.FirstOrDefault(x => x.ID == data.ID);

                    if (connectedSystem == null) continue;

                    lines.Add(new Lines(system.location, connectedSystem.location, 1, Statics.systemConnectionColor));
                }

            }

            PanelDrawer.rendererValues.Lines.Clear();

            PanelDrawer.rendererValues.Lines.AddRange(lines);

            PanelDrawer.rendererValues.texts.Clear();

            PanelDrawer.rendererValues.texts.AddRange(texts);

            PanelDrawer.rendererValues.Circles.Clear();

            PanelDrawer.rendererValues.Circles.AddRange(circles);

            PanelDrawer.BackgroundColor = Color.Black;

            PanelDrawer.rendererValues.zoomValue = zoomValue + 1;

            PanelDrawer.rendererValues.center = renderCenter;




        }

        private void pnlMap_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            PictureBox pB = sender as PictureBox;



            if (PanelDrawer == null)
            {
                PanelDrawer = new PBRenderer(pB, e);

                PanelDrawer.rendererValues = new RendererBaseClass();
            }



            //PanelDrawer.Render(sender, e);

        }

        private void TrackBar_Zoom_ValueChanged(object sender, EventArgs e)
        {
            zoomValue = (sender as TrackBar).Value / 100f;
            RefreshPanel();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {//https://stackoverflow.com/a/31464086

            float moveAmount = -100f;//im suppose to change the -s under but thats too much work so ill just - the move amount
                                     //TODO: dont be lazy

            switch (keyData)
            {
                case Keys.D0://0 key on line
                case Keys.NumPad0://0 key on numpad
                    btn_ResetMapVisuals_Click(null, null);//reset zooms
                    break;
                case Keys.Oemplus://+ key on line 
                case Keys.Add://+ key on numpad
                    btn_Zoom_Click(null, null);//zoom in
                    break;
                case Keys.OemMinus://- key on line
                case Keys.Subtract://- key on numpad
                    btn_DeZoom_Click(null, null);//zoom out
                    break;
                #region move

                case Keys.NumPad1://go down left by 100 (not sqrted)
                    Move(-moveAmount, moveAmount);
                    break;
                case Keys.NumPad2://go down
                case Keys.Down:
                    Move(0f, moveAmount);
                    break;
                case Keys.NumPad3://go down right
                    Move(moveAmount, moveAmount);
                    break;

                case Keys.NumPad4://go left
                case Keys.Left:
                    Move(-moveAmount, 0);
                    break;
                //no 5, cope 
                case Keys.NumPad6://go right 
                case Keys.Right://go right 
                    Move(moveAmount, 0f);
                    break;

                case Keys.NumPad7://go down left by 100 (not sqrted)
                    Move(-moveAmount, -moveAmount);
                    break;
                case Keys.NumPad8://go down
                case Keys.Up:
                    Move(0f, -moveAmount);
                    break;
                case Keys.NumPad9://go down right
                    Move(moveAmount, -moveAmount);
                    break;

                #endregion

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        private void Move(float x, float y)
        {
            renderCenter = Helper.CombineCoordinates(renderCenter, new PointF(x, y));

            RefreshPanel();
        }

        #region FormSize
        private void btn_FormSizeDecrease_Click(object sender, EventArgs e)
        {
            this.Width += this.Width > 100 ? -100 : 0;
            this.Height += this.Height > 100 ? -100 : 0;
        }

        private void btn_FormSizeIncrease_Click(object sender, EventArgs e)
        {
            this.Width += 100;
            this.Height += 100;
        }
        #endregion

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            PanelDrawer.rendererValues.reDraw = true;

            RefreshPanel();

            PanelDrawer.rendererValues.reDraw = false;

        }
    }


}