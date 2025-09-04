using Ejercicio8.DALs;
using Ejercicio8.Models;
using Ejercicio8_abm.DALs;
using System.Drawing.Drawing2D;

namespace Ejercicio8;

public partial class FormPrincipalView : Form
{
    IFigurasDAL figuraDAL = FigurasDALFactory.CrearDao(TipoDAL.MSQL);
    FiguraModel figuraSelected;

    public FormPrincipalView()
    {
        InitializeComponent();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        lvwInicializar();
    }
    
    async private void btnActualizar_Click(object sender, EventArgs e)
    {
        List<FiguraModel> figuras = await figuraDAL.GetAll();
        lvwFiguras.Items.Clear();

        foreach (var figura in figuras)
        {
            ListViewItem item = null;

            if (figura is CirculoModel c)
            {
                item = new ListViewItem($"C�rculo #{c.Id}");
                item.SubItems.Add($"�rea: {c.Area:F2}");
                item.SubItems.Add($"Radio: {c.Radio:F2}");
            }
            else if (figura is RectanguloModels r)
            {
                item = new ListViewItem($"Rect�ngulo #{r.Id}");
                item.SubItems.Add($"�rea: {r.Area:F2}");
                item.SubItems.Add($"Ancho: {r.Ancho:F2}, Largo: {r.Largo:F2}");
            }

            if (item != null)
            {
                item.Tag = figura;
                lvwFiguras.Items.Add(item);
            }
        }
    }
       
    async private void btnAgregar_Click(object sender, EventArgs e)
    {
        
        if (rbtTipoRectangulo.Checked)
        {
            RectanguloModels r = figuraSelected==null? new RectanguloModels(): figuraSelected as RectanguloModels;

            double ancho = Convert.ToDouble(tbAncho.Text);
            double largo = Convert.ToDouble(tbLargo.Text);

            r.Ancho = ancho;
            r.Largo = largo;
        }
        else if (rbtTipoCirculo.Checked)
        {
            CirculoModel c = figuraSelected == null ? new CirculoModel() : figuraSelected as CirculoModel;

            double radio = Convert.ToDouble(tbRadio.Text);
            c.Radio = radio;
        }

        if(figuraSelected.Id>0)
           await figuraDAL.Save(figuraSelected);
        else
           await figuraDAL.Add(figuraSelected);

        #region clear del area de edici�n
        tbAncho.Enabled = true;
        tbLargo.Enabled = true;
        tbRadio.Enabled = true;
        tbAncho.Clear();
        tbLargo.Clear();
        tbRadio.Clear();
        rbtTipoCirculo.Checked = false;
        rbtTipoRectangulo.Checked = false;
        rbtTipoCirculo.Enabled = true;
        rbtTipoRectangulo.Enabled = true;
        #endregion
    }

    private void btnVer_Click(object sender, EventArgs e)
    {
        if (lvwFiguras.SelectedItems.Count > 0)
        {
            figuraSelected = lvwFiguras.SelectedItems[0].Tag as FiguraModel;

            if (figuraSelected != null)
            {
                tbAncho.Clear();
                tbLargo.Clear();
                tbRadio.Clear();
                rbtTipoRectangulo.Enabled = false;
                rbtTipoCirculo.Enabled = false;

                if (figuraSelected is RectanguloModels r)
                {
                    rbtTipoRectangulo.Checked = true;
                    tbAncho.Text = r.Ancho.ToString();
                    tbLargo.Text = r.Largo.ToString();

                    tbAncho.Enabled = true;
                    tbLargo.Enabled = true;
                    tbRadio.Enabled = false;
                }
                else if (figuraSelected is CirculoModel c)
                {
                    rbtTipoCirculo.Checked = true;
                    tbRadio.Text = c.Radio.ToString();

                    tbAncho.Enabled = false;
                    tbLargo.Enabled = false;
                    tbRadio.Enabled = true;
                }
            }
        }
        else
        {
            MessageBox.Show("No hay ning�n elemento seleccionado");
        }
    }

    #region lvw redibujado
    public void lvwInicializar()
    {
        lvwFiguras.View = View.Tile;
        lvwFiguras.FullRowSelect = true;
        lvwFiguras.HideSelection = false;
        lvwFiguras.OwnerDraw = true;
        lvwFiguras.TileSize = new Size(300, 100);
        lvwFiguras.BackColor = Color.WhiteSmoke;
        lvwFiguras.BorderStyle = BorderStyle.None;
        lvwFiguras.DrawItem += lvwFiguras_DrawItem;
        lvwFiguras.SelectedIndexChanged += lvwFiguras_SelectedIndexChanged;
    }
    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        path.AddArc(arc, 180, 90);

        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }
    private void lvwFiguras_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        var rect = e.Bounds;

        Color backColor = e.Item.Selected ? Color.LightBlue : Color.White;
        Color borderColor = e.Item.Selected ? Color.DodgerBlue : Color.LightGray;

        using (var brush = new SolidBrush(backColor))
        using (var pen = new Pen(borderColor, 2))
        {
            int radius = 10;
            var path = RoundedRect(rect, radius);
            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(pen, path);
        }

        string text = e.Item.Text;
        var fontTitle = new Font("Segoe UI", 10, FontStyle.Bold);
        var fontSub = new Font("Segoe UI", 9, FontStyle.Regular);

        e.Graphics.DrawString(text, fontTitle, Brushes.Black, rect.X + 10, rect.Y + 10);

        int offsetY = 30;
        foreach (ListViewItem.ListViewSubItem sub in e.Item.SubItems)
        {
            if (sub == e.Item.SubItems[0]) continue;
            e.Graphics.DrawString(sub.Text, fontSub, Brushes.DimGray, rect.X + 10, rect.Y + offsetY);
            offsetY += 18;
        }
    }
    private void lvwFiguras_SelectedIndexChanged(object sender, EventArgs e)
    {
        lvwFiguras.Invalidate(); 
    }

    #endregion
}
