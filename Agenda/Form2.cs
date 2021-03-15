using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form2 : Form
    {
        public DateTime dt;
        public Form1 reference;

        public Form2(DateTime dt, Form1 reference)
        {
            this.dt = dt;
            this.reference = reference;
            InitializeComponent();
        }

        private void addButtonConfirm_Click(object sender, EventArgs e)
        {
            if(confirmTextbox.Text != "")
            {
                Evento eve = Database.DatabaseCreate(confirmTextbox.Text, dt);
                AgendaInterface.eventos.Add(eve);
                this.Close();
                this.reference.UpdateListBox();
            }
        }
    }
}
