namespace BinalyFileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(txtContent.Text);
                    }
                    MessageBox.Show("Archivo guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog1.FileName;
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        txtContent.Text = reader.ReadString();
                    }
                    MessageBox.Show("Archivo cargado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
