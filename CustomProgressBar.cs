using System.Drawing;
using System.Windows.Forms;

public class CustomProgressBar : ProgressBar
{
    public CustomProgressBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;
        Graphics g = e.Graphics;

        // Define your custom color
        Color customColor = Color.Red;

        // Calculate the width of the progress bar based on the Value and Maximum properties
        rect.Width = (int)((float)Value / Maximum * rect.Width);

        // Fill the progress bar with the custom color
        using (SolidBrush brush = new SolidBrush(customColor))
        {
            g.FillRectangle(brush, rect);
        }
    }
}
