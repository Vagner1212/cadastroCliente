using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventAr.gs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private int clienteIdAtual = 0; // Armazena o ID do cliente atual.

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=Cliente;User=root;Password=12345;";

            if (clienteIdAtual <= 0)
            {
                MessageBox.Show("Nenhum cliente está carregado para remover a imagem.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Clientes SET foto = NULL WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", clienteIdAtual);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Imagem removida com sucesso!");


                            pictureBox1.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Erro: Nenhum cliente encontrado para remover a imagem.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erro ao remover a imagem do banco de dados: {ex.Message}");
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=Cliente;User=root;Password=12345;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão estabelecida com sucesso!");


                    string tipoDocumento = radioButton3.Checked ? "CPF" : radioButton4.Checked ? "CNPJ" : null;
                    if (tipoDocumento == null)
                    {
                        MessageBox.Show("Selecione o tipo de documento (CPF ou CNPJ).");
                        return;
                    }

                    string genero = radioButton1.Checked ? "Masculino" : radioButton2.Checked ? "Feminino" : null;
                    if (genero == null)
                    {
                        MessageBox.Show("Selecione o gênero (Masculino ou Feminino).");
                        return;
                    }


                    DateTime dataNascimento;
                    if (!DateTime.TryParseExact(DataBox.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
                    {
                        MessageBox.Show("Formato de data inválido. Use o formato dd/MM/yyyy.");
                        return;
                    }
                    string dataNascimentoFormatada = dataNascimento.ToString("yyyy-MM-dd");

                    string query = "INSERT INTO Clientes (nome_cliente, tipo_documento, documento, genero, rg, estado_civil, data_nascimento, cep, endereco, numero, bairro, cidade, estado, celular, email, observacoes, situacao_cadastral, foto) " +
                                   "VALUES (@nome_cliente, @tipo_documento, @documento, @genero, @rg, @estado_civil, @data_nascimento, @cep, @endereco, @numero, @bairro, @cidade, @estado, @celular, @email, @observacoes, @situacao_cadastral, @foto)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@nome_cliente", TextName.Text);
                        command.Parameters.AddWithValue("@tipo_documento", tipoDocumento);
                        command.Parameters.AddWithValue("@documento", TextCPF.Text);
                        command.Parameters.AddWithValue("@genero", genero);
                        command.Parameters.AddWithValue("@rg", RGBox.Text);
                        command.Parameters.AddWithValue("@estado_civil", EstadoCivilBox.Text);
                        command.Parameters.AddWithValue("@data_nascimento", dataNascimentoFormatada);
                        command.Parameters.AddWithValue("@cep", CEPTextBox.Text);
                        command.Parameters.AddWithValue("@endereco", EnderecoBox.Text);
                        command.Parameters.AddWithValue("@numero", NumeroBox.Text);
                        command.Parameters.AddWithValue("@bairro", BairroBox.Text);
                        command.Parameters.AddWithValue("@cidade", CidadeBox.Text);
                        command.Parameters.AddWithValue("@estado", EstadoBox.Text);
                        command.Parameters.AddWithValue("@celular", CelularBox.Text);
                        command.Parameters.AddWithValue("@email", EmailBox.Text);
                        command.Parameters.AddWithValue("@observacoes", ObservacoesBox.Text);
                        command.Parameters.AddWithValue("@situacao_cadastral", true);


                        if (imagemClienteBytes != null)
                        {
                            command.Parameters.AddWithValue("@foto", imagemClienteBytes);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@foto", DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente inserido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao inserir o cliente.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro ao se conectar ao banco de dados:\n" + ex.Message);
                }
            }
        }




        private object textBox2_Text()
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void CadastroClienteCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                SendKeys.Send("{TAB}");

                e.SuppressKeyPress = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private byte[] imagemClienteBytes;

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.Title = "Selecione uma imagem";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {

                        imagemClienteBytes = File.ReadAllBytes(filePath);


                        pictureBox1.Image = Image.FromFile(filePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        MessageBox.Show("Imagem carregada com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}");
                    }
                }
            }
        }

    }
}