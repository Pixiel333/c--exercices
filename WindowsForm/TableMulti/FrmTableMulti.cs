using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppMulti
{
    public partial class FrmTableMulti : Form
    {
        public FrmTableMulti()
        {
            InitializeComponent();
        }

        private void FrmTableMulti_Load(object sender, EventArgs e)
        {
            panelExcercer.Enabled = false;
            panelReviser.Enabled = false;
            nudTable.Enabled = false;
        }     
        private void rbUneTable_CheckedChanged(object sender, EventArgs e)
        {
            nudTable.Enabled = true;
        }

        private void rbToutesLesTables_CheckedChanged(object sender, EventArgs e)
        {
            nudTable.Enabled = false;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtReponse.Text.Length==0)
            {
                MessageBox.Show("Vous devez saisir une réponse !", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {      
                int table = int.Parse(txtTable.Text);
                int nombre = int.Parse(txtNombre.Text);
                int resultat = int.Parse(txtReponse.Text);
                if (table*nombre==resultat)
                {
                    MessageBox.Show("Bonne réponse !", "RÉSULTAT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mauvaise réponse !", "RÉSULTAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnAutreMulti.Enabled = true;
                txtReponse.ReadOnly = true;
                btnValider.Enabled = false;
            }

        }

        private void btnAutreMulti_Click(object sender, EventArgs e)
        {
            affichageExercer();
        }

        private void btnExercer_Click(object sender, EventArgs e)
        {
            panelExcercer.Enabled = true;
            affichageExercer();
            supprimeTxtAffiche();
        }
        private void affichageExercer()
        {
            btnAutreMulti.Enabled = false;
            txtReponse.ReadOnly = false;
            btnValider.Enabled = true;
            panelReviser.Enabled = false;
            txtAfficheTable.Clear();
            txtReponse.Clear();
            Random aleatoire = new Random();
            int nombre = aleatoire.Next(1, 10);
            string affichNombre = nombre.ToString();
            txtNombre.Text = affichNombre;
            if (nudTable.Enabled == true)
            {
                decimal table = nudTable.Value;
                string affichTable = table.ToString();
                txtTable.Text = affichTable;
            }
            else
            {
                int table = aleatoire.Next(1, 10);
                string affichTable = table.ToString();
                txtTable.Text = affichTable;
            }
        }

        private void btnTerminerExercer_Click(object sender, EventArgs e)
        {
            panelExcercer.Enabled = false;
            txtTable.Clear();
            txtNombre.Clear();
            txtReponse.Clear();
        }

        private void btnReviser_Click(object sender, EventArgs e)
        {
            panelReviser.Enabled = true;
            panelExcercer.Enabled = false;
            txtTable.Clear();
            txtNombre.Clear();
            txtReponse.Clear();           
            if (nudTable.Enabled == true)
            {
                txtAfficheTable.Text = $"TABLE DU {nudTable.Value}------------------------" + Environment.NewLine;
                for (int i=1;i<=10;i++)
                {
                    txtAfficheTable.Text = txtAfficheTable.Text + $"{nudTable.Value} x {i} = {nudTable.Value * i}" + Environment.NewLine;
                }
            }
            else
            {               
                if (tlpResultat.Controls.Count<10)
                {
                    txtAfficheTable.Text = $"TABLE DU 1------------------------" + Environment.NewLine;
                    for (int i = 1; i <= 10; i++)
                        {
                            txtAfficheTable.Text = txtAfficheTable.Text + $"1 x {i} = {1 * i}" + Environment.NewLine;
                        }
                    creationTxtAffiche();
                }

            }
        }
        
        private void creationTxtAffiche()
        {
            for (int i = 1; i <= 9; i++)
            {
                this.txtAfficheTable = new System.Windows.Forms.TextBox();
                this.txtAfficheTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                if (i < 5)
                {
                    this.tlpResultat.Controls.Add(this.txtAfficheTable, i, 0);
                }
                else
                {
                    this.tlpResultat.Controls.Add(this.txtAfficheTable, i - 5, 1);
                }
                this.txtAfficheTable.Margin = new System.Windows.Forms.Padding(4);
                this.txtAfficheTable.Multiline = true;
                this.txtAfficheTable.Name = "txtAfficheTable";
                this.txtAfficheTable.ReadOnly = true;
                this.txtAfficheTable.Size = new System.Drawing.Size(105, 208);
                this.txtAfficheTable.TabIndex = i;
                txtAfficheTable.Text = $"TABLE DU {i + 1}------------------------" + Environment.NewLine;
                for (int j = 1; j <= 10; j++)
                {
                    txtAfficheTable.Text = txtAfficheTable.Text + $"{i + 1} x {j} = {(i + 1) * j}" + Environment.NewLine;
                }
            }
        }


        private void supprimeTxtAffiche()
        {
            this.tlpResultat.Controls.Clear();
            this.txtAfficheTable = new System.Windows.Forms.TextBox();
            this.tlpResultat.Controls.Add(this.txtAfficheTable, 0, 0);
            this.txtAfficheTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtAfficheTable.Location = new System.Drawing.Point(4, 4);
            this.txtAfficheTable.Margin = new System.Windows.Forms.Padding(4);
            this.txtAfficheTable.Multiline = true;
            this.txtAfficheTable.Name = "txtAfficheTable";
            this.txtAfficheTable.ReadOnly = true;
            this.txtAfficheTable.Size = new System.Drawing.Size(105, 208);
            this.txtAfficheTable.TabIndex = 0;
            panelReviser.Enabled = false;
        }

        private void btnTerminerReviser_Click(object sender, EventArgs e)
        {
            supprimeTxtAffiche();            
        }
    }
}
