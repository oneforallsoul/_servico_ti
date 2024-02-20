using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _servico_ti
{
    public partial class Servicos_Tl : Form
    {
        string servidor;
        MySqlConnection conexao;
        MySqlCommand comando;
        string idREGISTRO;
        string op = "";

        public Servicos_Tl()
        {
            InitializeComponent();
            servidor = "Server=localhost;Database=nicolas_servico_ti;Uid=root;Pwd=";
            conexao = new MySqlConnection(servidor);
            conexao.Close();
        }
        private void ATUALIZAR_CADASTRO()
        {

        }

        private void Limpar_Cadastro()
        {
            textBoxNOME.Clear();
            textBoxCELULAR.Clear();
            textBoxSOBRENOME.Clear();
            textBoxNOME.Clear();
            textBoxTELEFONE.Clear();
            textBoxCPF.Clear();
            textBoxDATAENTRADA.Clear();
            textBoxQUEIXACLIENTE.Clear();
            textBoxCARACTERISITCASEQUIPAMENTOS.Clear();
            textBoxVALORTOTAL.Clear();
            radioButtonATIVO.Checked = false;
            radioButtonCANCELADO.Checked = false;
            radioButtonCONCLUIDO.Checked = false;
            radioButtonANDAMENTO.Checked = false;
        }

        private void buttonCADASTRO_Click(object sender, EventArgs e)
        {
            labelNOME.ForeColor = Color.Black;

            if (radioButtonANDAMENTO.Checked)
            {
                op = "Opção ANDAMENTO";
            }
            if (radioButtonCONCLUIDO.Checked)
            {
                op = "Opção CONCLUIDO";
            }


            if (radioButtonCANCELADO.Checked)
            {
                op = "Opção CANCELADO";
            }
            if (radioButtonATIVO.Checked)
            {
                op = "Opção ATIVO";
            }

            try
            {
                if (textBoxNOME.Text != "" && textBoxEMAIL.Text != "")
                {
                    conexao.Open();
                    comando.CommandText = "INSERT INTO tbl_cliente (nome,sobrenome, cpf, celular, email, telefone, observacao, data_entrada, queixa_cliente, valor_total, obeservações, caracteristicas_equipamentos) VALUES ('" + textBoxNOME.Text + "', '" + textBoxSOBRENOME.Text + "', '" + textBoxTELEFONE.Text + "', '" + textBoxCELULAR.Text + "', '" + textBoxEMAIL.Text + "', '" + textBoxDATAENTRADA.Text + "', '" + textBoxQUEIXACLIENTE.Text + "' , '" + textBoxVALORTOTAL.Text + "', '" + textBoxCARACTERISITCASEQUIPAMENTOS + "','" + TextBoxOBESERVACAO + "');";
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com SUCESSO!");
                    Limpar_Cadastro();
                }
                else
                {
                    MessageBox.Show("Nome da pessoa e/ou sobrenome  estão em BRANCO! Por favor preencha!");

                    if (textBoxNOME.Text == "")
                    {
                        textBoxNOME.Focus();
                        labelNOME.ForeColor = Color.Red;
                    }
                    else
                    {
                        textBoxEMAIL.Focus();
                        labelEMAIL.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception erro_mysql)
            {
                MessageBox.Show("Erro de Sistema. Solicite ajuda!");
            }
            finally
            {
                conexao.Close();
            }
            ATUALIZAR_CADASTRO();
        }

        private void buttonEXCLUIR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente EXCLUIR este registro?", "ATENÇÃO!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    conexao.Open();
                    comando.CommandText = "DELETE FROM tbl_cliente WHERE id = " + idREGISTRO + ";";
                    int resultado = comando.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        MessageBox.Show("Informação(s) removido(s) com sucesso! - " + resultado + "registros removidos...");
                    }
                    else
                    {
                        MessageBox.Show("Cadastro não encontrado!");
                    }
                }
                catch (Exception erro_mysql)
                {
                    MessageBox.Show("Erro de Sistema. Solicite ajuda!");
                }
                finally
                {
                    conexao.Close();
                }
                ATUALIZAR_CADASTRO();
            }
            Limpar_Cadastro();
        }

        private void buttonALTERAR_Click(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
                comando.CommandText = "UPDATE tbl_cliente SET nome = '" + textBoxNOME.Text + "', sobrenome = '" + textBoxSOBRENOME.Text + "', telefone =  '" + textBoxTELEFONE.Text + "', cpf = '" + textBoxCPF.Text + "', celular= '" + textBoxCELULAR.Text + "', email= '" + textBoxEMAIL.Text + "', dataentrada  = '" + textBoxDATAENTRADA.Text + "', queixa_cliente ='" + textBoxQUEIXACLIENTE.Text + "', valor_total='" + textBoxVALORTOTAL.Text + "', obeservacoes= '" + TextBoxOBESERVACAO.Text + "', caracteristicas_equipamentos = '" + textBoxCARACTERISITCASEQUIPAMENTOS.Text + "'  WHERE id = " + idREGISTRO + ";";
                int resultado = comando.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Cadastro(s) atualizado(s) com sucesso! - " + resultado + " registros atualizados...");
                }
                else
                {
                    MessageBox.Show("Cadastro não encontrado!");
                }
            }
            catch (Exception erro_mysql)
            {
                MessageBox.Show("Erro de Sistema. Solicite ajuda!");
            }
            finally
            {
                conexao.Close();
            }
            ATUALIZAR_CADASTRO();
            Limpar_Cadastro();
        }

        private void Serviços_Tl_Load(object sender, EventArgs e)
        {

        }
    }
}







