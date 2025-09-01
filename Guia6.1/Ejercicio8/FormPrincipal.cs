using Ejercicio8.DALs;
using Ejercicio8.Models;
using System.Drawing.Drawing2D;

namespace Ejercicio8;

public partial class FormPrincipal : Form
{
    FigurasDAL figuraDAL = new FigurasDAL();

    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        listView1.View = View.Tile;
        listView1.FullRowSelect = true;
        listView1.HideSelection = false;
        listView1.OwnerDraw = true; // nos permite customizar el dibujo
        listView1.TileSize = new Size(300, 100);
        listView1.BackColor = Color.WhiteSmoke;
        listView1.BorderStyle = BorderStyle.None;

        // vista que dibuja cards
        listView1.DrawItem += ListView1_DrawItem;
    }

    async private void btnActualizar_Click(object sender, EventArgs e)
    {
        List<Figura> figuras = await figuraDAL.GetAll();
        listView1.Items.Clear();

        foreach (var figura in figuras)
        {
            if (figura is Circulo c)
            {
                var item = new ListViewItem($"Círculo #{c.Id}");
                item.SubItems.Add($"Área: {c.Area:F2}");
                item.SubItems.Add($"Radio: {c.Radio:F2}");
                listView1.Items.Add(item);
            }
            else if (figura is Rectangulo r)
            {
                var item = new ListViewItem($"Rectángulo #{r.Id}");
                item.SubItems.Add($"Área: {r.Area:F2}");
                item.SubItems.Add($"Ancho: {r.Ancho:F2}, Largo: {r.Largo:F2}");
                listView1.Items.Add(item);
            }
        }
    }

    private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        // Card background
        var rect = e.Bounds;
        using (var brush = new SolidBrush(Color.White))
        using (var pen = new Pen(Color.LightGray, 1))
        {
            // borde redondeado
            int radius = 10;
            var path = RoundedRect(rect, radius);
            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(pen, path);
        }

        // Texto
        string text = e.Item.Text;
        var fontTitle = new Font("Segoe UI", 10, FontStyle.Bold);
        var fontSub = new Font("Segoe UI", 9, FontStyle.Regular);

        // Primera línea en bold
        e.Graphics.DrawString(text, fontTitle, Brushes.Black, rect.X + 10, rect.Y + 10);

        // Subitems (se ven como líneas extra)
        int offsetY = 30;
        foreach (ListViewItem.ListViewSubItem sub in e.Item.SubItems)
        {
            if (sub == e.Item.SubItems[0]) continue; // skip title
            e.Graphics.DrawString(sub.Text, fontSub, Brushes.DimGray, rect.X + 10, rect.Y + offsetY);
            offsetY += 18;
        }
    }

    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        // Top left arc
        path.AddArc(arc, 180, 90);

        // Top right arc
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        // Bottom right arc
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // Bottom left arc
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        Figura nueva = null;

        if (radioButton1.Checked)
        {
            double ancho = Convert.ToDouble(tbAncho.Text);
            double largo = Convert.ToDouble(tbLargo.Text);

            nueva =new  Rectangulo(){ Ancho=ancho, Largo=largo };
            ;
        }else if (radioButton2.Checked)
        {
            double radio= Convert.ToDouble(tbRadio.Text);
            nueva = new Circulo() { Radio=radio};
        }

        figuraDAL.Save(nueva);
    }
}
