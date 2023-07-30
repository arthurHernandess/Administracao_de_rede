using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PW_Prova
{
    public partial class frm_provaPW : Form
    {
        public frm_provaPW()
        {
            InitializeComponent();
        }

        #region Instancias e Load
        Computador PC1 = new Computador(1, "Dell", "Intell Core i3", 10, true, 220);
        Computador PC2 = new Computador(2, "HP", "AMD Ryzen 5", 10, true, 400);
        Computador PC3 = new Computador(3, "Dell", "AMD Ryzen 3", 10, false, 360);
        Computador PC4 = new Computador(4, "Lenovo", "Intel Core i7", 10, true, 1000);

        List<Computador> PCs = new List<Computador>();

        Software Teams = new Software("Teams", 1, "Funciona", "Microsoft" ,"Resources/Teams.png", 3);
        Software Illustrator = new Software("Illustrator", 2, "Gera tristeza", "Adobe","Resources/Illustrator.png", 5);
        Software Photoshop = new Software("Photoshop", 3, "Gera alegria", "Adobe","Resources/Photoshop.png" , 6);
        Software VScode = new Software("Visual Studio Code", 4, "Gera muita alegria", "Microsoft","Resources/VScode.jpg", 2);

        List<Software> Apps = new List<Software>();

        private void frm_provaPW_Load(object sender, EventArgs e)
        {
            PCs.Add(PC1);
            PCs.Add(PC2);
            PCs.Add(PC3);
            PCs.Add(PC4);

            Apps.Add(Teams);
            Apps.Add(Illustrator);
            Apps.Add(Photoshop);
            Apps.Add(VScode);

            for (int g = 0; g < PCs.Count; g++)
            {
                cmbAppExec.Items.Add(Apps[g].GetNome());
            }

            pnlComputadores.Visible = false;
            pnlApps.Visible = false;
        }
        #endregion

        #region Exibir Specs PC e App
        public void ExibirEspecificacoesPC()
        {
            txtID.Text = PCs[PC_Selecionado].MostrarEspecificacoes()[0];
            txtFab.Text = PCs[PC_Selecionado].MostrarEspecificacoes()[1];
            txtProcessador.Text = PCs[PC_Selecionado].MostrarEspecificacoes()[2];
            txtRAMtotal.Text = PCs[PC_Selecionado].MostrarEspecificacoes()[3];
            lblEstado.Text = PCs[PC_Selecionado].MostrarEspecificacoes()[4];
            txtHD.Text = PCs[PC_Selecionado].MostrarEspecificacoes()[5];
            lblRAM.Text = PCs[PC_Selecionado].RamDisponivel.ToString();

            if (PCs[PC_Selecionado].softwareEmExecucao != null)
            {
                pcbAppExec.Load("../../" + PCs[PC_Selecionado].softwareEmExecucao.GetEnderecoIcone());
                cmbAppExec.Text = "Mudar app";
            }
            else
            {
                pcbAppExec.Image = null;
                cmbAppExec.Text = "Abrir app";
            }

            if (PCs[PC_Selecionado].ChecarEstado() == "Desligado")
            {
                gpbAppExec.Enabled = false;
                btnLigarPC.BackColor = Color.Green;
                lblEstado.Image = Properties.Resources.Desligado;
            }
            else
            {
                gpbAppExec.Enabled = true;
                btnLigarPC.BackColor = Color.Red;
                lblEstado.Image = Properties.Resources.Ligado;
            }

            pnlComputadores.Visible = true;
        }

        public void ExibirEspecificacoesApp()
        {
            txtNomeApp.Text = Apps[App_Selecionado].MostrarEspecificacoes()[0];
            txtIDApp.Text = Apps[App_Selecionado].MostrarEspecificacoes()[1];
            rtxDescricaoApp.Text = Apps[App_Selecionado].MostrarEspecificacoes()[2];
            txtDesenvolvedora.Text = Apps[App_Selecionado].MostrarEspecificacoes()[3];
            txtRamApp.Text = Apps[App_Selecionado].MostrarEspecificacoes()[4];

            pcbAppSelecionado.Load("../../" + Apps[App_Selecionado].GetEnderecoIcone());
            pnlApps.Visible = true;
        }
        #endregion

        #region Executar um programa e ligar/desligar PC
        private void cmbAppExec_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbAppExec.SelectedIndex == 0)
            {
                PCs[PC_Selecionado].PararSoftware();
                pcbAppExec.Image = null;
                PCs[PC_Selecionado].DesalocarRam();
                lblRAM.Text = "0";
            }
            else
            {
                PCs[PC_Selecionado].IniciarSoftware(Apps[cmbAppExec.SelectedIndex - 1]);
                pcbAppExec.Load("../../" + PCs[PC_Selecionado].softwareEmExecucao.GetEnderecoIcone());

                PCs[PC_Selecionado].AlocarRam(Apps[cmbAppExec.SelectedIndex - 1].GetRam());
                lblRAM.Text = PCs[PC_Selecionado].RamDisponivel.ToString();
            }
        }

        private void btnLigar_Click(object sender, EventArgs e)
        {
            PCs[PC_Selecionado].Ligar_Desligar();
            PCs[PC_Selecionado].PararSoftware();
            PCs[PC_Selecionado].DesalocarRam();
            ExibirEspecificacoesPC();
        }
        #endregion

        #region PC Selecionado   
        int PC_Selecionado = 0;
        private void mnsPC1_Click(object sender, EventArgs e)
        {
            PC_Selecionado = 0;
            ExibirEspecificacoesPC();
        }

        private void mnsPC2_Click(object sender, EventArgs e)
        {
            PC_Selecionado = 1;
            ExibirEspecificacoesPC();
        }

        private void mnsPC3_Click(object sender, EventArgs e)
        {
            PC_Selecionado = 2;
            ExibirEspecificacoesPC();
        }

        private void mnsPC4_Click(object sender, EventArgs e)
        {
            PC_Selecionado = 3;
            ExibirEspecificacoesPC();
        }
        #endregion

        #region App selecionado
        int App_Selecionado = 0;
        private void teamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Selecionado = 0;
            ExibirEspecificacoesApp();
        }

        private void illustratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Selecionado = 1;
            ExibirEspecificacoesApp();
        }

        private void photoshopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Selecionado = 2;
            ExibirEspecificacoesApp();
        }

        private void visualStudioCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_Selecionado = 3;
            ExibirEspecificacoesApp();
        }
        #endregion

        #region Fechar
        private void fecharJanelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlComputadores.Visible = false;
        }

        private void fecharJanelaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlApps.Visible = false;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
