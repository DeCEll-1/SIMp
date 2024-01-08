using SSSystemGenerator.Forms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSSystemGenerator.Classes
{
    public class Helper
    {

        #region misc

        public static void ThrowCrash(string fileName, string functionName)
        {

            throw new Exception(
                "filename:" + fileName +
                "\nfunctionname:" + functionName +
                "\nping me on corvus or usc with the reproduction way and your system JSON");

        }

        public static PointF GetPointOnCircumference(PointF center, float angle, float distance)
        {
            //https://stackoverflow.com/questions/14096138/find-the-point-on-a-circle-with-given-center-point-radius-and-degree

            //problem: 
            /*
             90 = 270
             45 = 305
             etc
             */
            //solution:
            //multiply angle with -1

            angle *= -1;

            float x_oncircle = (float)(center.X + distance * Math.Cos(angle * (Math.PI / 180f)));
            float y_oncircle = (float)(center.Y + distance * Math.Sin(angle * (Math.PI / 180f)));

            return new PointF(x_oncircle, y_oncircle);
        }

        public static PointF SubtractCoordinates(PointF toSubtractFrom, PointF subtract)
        {
            toSubtractFrom.X -= subtract.X;
            toSubtractFrom.Y -= subtract.Y;

            return toSubtractFrom;
        }

        public static PointF CombineCoordinates(PointF toAddTo, PointF subtract)
        {
            toAddTo.X += subtract.X;
            toAddTo.Y += subtract.Y;

            return toAddTo;
        }

        public static Map GetMap() { return Statics.Map; }
        public static BaseMDIContainer GetMDIContainer() { return Statics.BaseMDIContainer; }

        //TODO: get this on a seperate file
        #region Colors 

        public static void ChangeColorMode(Control.ControlCollection container)
        {


            UpdateComponentColors(container.Owner);

            foreach (Control component in container)
            {

                //if (!component.Enabled) continue;



                DrawBorderToComplonent(component);

                //HoverColorEventSetup(component);

                UpdateComponentColors(component);

                if (component is MenuStrip)
                {
                    ChangeColorMode((component as MenuStrip).Items);
                }

                if (component.Controls.Count != 0)
                {
                    ChangeColorMode(component.Controls);

                    continue;
                }


            }



        }

        private static void UpdateComponentColors(Control component)
        {
            ////https://stackoverflow.com/a/19315175 // remove it before adding so you dont add it multiple times
            //component.EnabledChanged -= EnabledColorUpdateEvent;
            //component.EnabledChanged += EnabledColorUpdateEvent;//except it doesnt work

            bool wasDisabled = false;

            if (component is Button && !component.Enabled)
            {
                if (!Settings.ColorMode)//Dark mode
                {
                    return;
                }

            }

            //if (!component.Enabled)
            //{//https://stackoverflow.com/a/46100278
            //    wasDisabled = true;
            //    component.Enabled = true;
            //}


            //component.EnabledChanged -= EnabledColorUpdateEvent;
            //component.EnabledChanged += EnabledColorUpdateEvent;

            //if (!component.Enabled) return;



            foreach (var borderlessControl in borderlessControls)
            {
                if (component.GetType() == borderlessControl.GetType() || component.GetType().GetInterface("IFormInterface") != null)
                {
                    component.BackColor = FormBackground();
                    component.ForeColor = FormText();

                    //if (wasDisabled) component.Enabled = false;
                    return;
                }
            }

            component.BackColor = Background();
            component.ForeColor = Text();

            //if (wasDisabled) component.Enabled = false;

        }

        private static void EnabledColorUpdateEvent(object sender, System.EventArgs eventArgs)
        {
            Control senderControl = (Control)sender;
            UpdateComponentColors(senderControl);

            DrawBorderToComplonent(senderControl);
        }

        #region Border

        private static void DrawBorderToComplonent(Control component)
        {

            component.Paint += Component_Paint;

            component.Refresh();

            component.Paint -= Component_Paint;

        }

        private static void Component_Paint(object sender, PaintEventArgs e)
        {//https://stackoverflow.com/a/59478243

            foreach (var borderlessControl in borderlessControls)
            {
                if (sender.GetType() == borderlessControl.GetType())
                {
                    return;
                }
            }

            int borderWidth = 6;
            ButtonBorderStyle borderStyle = ButtonBorderStyle.Solid;
            if (Settings.ColorMode)//light mode
            {
                e.Graphics.Clear(Colors.LIGHT_MODE_BG);
                var borderColor = Colors.LIGHT_MODE_BORDER;
                //https://stackoverflow.com/questions/2200974/controlpaint-drawborder-but-thicker

                ControlPaint.DrawBorder(
                                    e.Graphics,
                                    e.ClipRectangle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle
                                    );
            }
            else//dark mode
            {
                e.Graphics.Clear(Colors.DARK_MODE_BG);
                var borderColor = Colors.DARK_MODE_BORDER;



                ControlPaint.DrawBorder(
                                    e.Graphics,
                                    e.ClipRectangle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle,
                                    borderColor,
                                    borderWidth,
                                    borderStyle
                                    );
            }

        }

        #endregion

        #region ToolStrip

        private static void ChangeColorMode(ToolStripItemCollection TSICollection)
        {
            foreach (ToolStripItem TSI in TSICollection)
            {

                UpdateToolStripColors(TSI);

                if (TSI is ToolStripMenuItem)
                {
                    //HoverColorEventSetup(TSI);
                    ChangeColorMode((TSI as ToolStripMenuItem).DropDownItems);

                }

            }
        }

        private static void UpdateToolStripColors(ToolStripItem toolStripItem)
        {
            if (!toolStripItem.Enabled) return;

            toolStripItem.BackColor = FormBackground();
            toolStripItem.ForeColor = FormText();

        }

        #endregion

        #region Hover // obsolete, doesnt work/makes everything shet itself

        [ObsoleteAttribute]
        private static void HoverColorEventSetup(Control component)
        {//https://stackoverflow.com/questions/37777688/c-sharp-how-to-change-menustrip-hover-color
         //draw stuff when mouse entered and reset when leaved

            component.MouseEnter -= Hover_MouseEnter_Control;
            component.MouseEnter += Hover_MouseEnter_Control;//enter

            component.MouseLeave -= Hover_MouseLeave_Control;
            component.MouseLeave += Hover_MouseLeave_Control;//leave

            component.Paint -= Hover_Paint_Control;
            component.Paint += Hover_Paint_Control;//paint
        }

        [ObsoleteAttribute]
        private static void HoverColorEventSetup(ToolStripItem TSI)
        {//https://stackoverflow.com/questions/37777688/c-sharp-how-to-change-menustrip-hover-color
            //draw stuff when mouse entered and reset when leaved

            TSI.MouseEnter -= Hover_MouseEnter_TSI;
            TSI.MouseEnter += Hover_MouseEnter_TSI;//enter

            TSI.MouseLeave -= Hover_MouseLeave_TSI;
            TSI.MouseLeave += Hover_MouseLeave_TSI;//leave

            TSI.Paint -= Hover_Paint_Control;
            TSI.Paint += Hover_Paint_Control;//paint
        }

        [ObsoleteAttribute]
        private static void Hover_MouseEnter_Control(object sender, EventArgs e) { (sender as Control).Refresh(); }

        [ObsoleteAttribute]
        private static void Hover_MouseLeave_Control(object sender, EventArgs e) { (sender as Control).Refresh(); }

        [ObsoleteAttribute]
        private static void Hover_MouseEnter_TSI(object sender, EventArgs e) { (sender as ToolStripItem).Invalidate(); }

        [ObsoleteAttribute]
        private static void Hover_MouseLeave_TSI(object sender, EventArgs e) { (sender as ToolStripItem).Invalidate(); }

        [ObsoleteAttribute]
        private static void Hover_Paint_Control(object sender, PaintEventArgs e)
        {
            if (sender == null || (sender as Control) == null) return;

            using (sender as Control)
            {
                e.Graphics.FillRectangle(new SolidBrush((sender as Control).BackColor), (sender as Control).Bounds);
            }
        }

        [ObsoleteAttribute]
        private static void Hover_PaintTSI(object sender, PaintEventArgs e)
        {
            if (sender == null || (sender as Control) == null) return;

            using (sender as Control)
            {
                e.Graphics.FillRectangle(new SolidBrush((sender as Control).BackColor), (sender as Control).Bounds);
            }
        }

        #endregion

        #region returnColors

        public static Color Text()
        {
            if (Settings.ColorMode)//lightMode
            { return Colors.LIGHT_MODE_FG; }
            else
            { return Colors.DARK_MODE_FG; }
        }

        public static Color Background()
        {
            if (Settings.ColorMode)//lightMode
            { return Colors.LIGHT_MODE_BG; }
            else
            { return Colors.DARK_MODE_BG; }
        }

        public static Color FormText()
        {
            if (Settings.ColorMode)//lightMode
            //{ return Colors.LIGHT_MODE_FORM_FG; }
            { return Form.DefaultForeColor; }
            else
            { return Colors.DARK_MODE_FORM_FG; }
        }

        public static Color FormBackground()
        {
            if (Settings.ColorMode)//lightMode
            //{ return Colors.LIGHT_MODE_FORM_BG; }
            { return Form.DefaultBackColor; }
            else
            { return Colors.DARK_MODE_FORM_BG; }
        }

        public static Color Border()
        {
            if (Settings.ColorMode)//lightMode
            { return Colors.LIGHT_MODE_BORDER; }
            else
            { return Colors.DARK_MODE_BORDER; }
        }

        public static Color Hover()
        {
            if (Settings.ColorMode)//lightMode
            { return Colors.LIGHT_MODE_HOVER_COLOR; }
            else
            { return Colors.DARK_MODE_HOVER_COLOR; }
        }

        #endregion

        #region ComboBox // not used because the coloring works on flat and this makes it look like flat anyways

        [ObsoleteAttribute]
        private static void ChangeColorOfDropBoxes(Component component)
        {
            if (component is ComboBox)
            {
                (component as ComboBox).DrawItem += ComboBox_DrawItem;
                (component as ComboBox).Refresh();
                (component as ComboBox).DrawItem -= ComboBox_DrawItem;
            }
        }

        [ObsoleteAttribute]
        private static void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {//https://stackoverflow.com/a/60421006/21149029

            ComboBox comboBox = (sender as ComboBox);

            int index = e.Index >= 0 ? e.Index : -1;
            Brush brush = ((e.State & DrawItemState.Selected) > 0) ? SystemBrushes.HighlightText : new SolidBrush(comboBox.ForeColor);
            e.DrawBackground();
            if (index != -1)
            {
                e.Graphics.DrawString(comboBox.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        #endregion

        #region borderlessControls // also stuff that takes form background

        private static List<Control> borderlessControls = new List<Control>()
        {
            new Label(),
            new Button(),
            new GroupBox(),
            new Panel(),
            new Form(),
        };

        #endregion

        #endregion

        #endregion

        #region obsolete



        #endregion
    }
}
