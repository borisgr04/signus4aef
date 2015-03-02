using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Radicar r = new Radicar();
            RadicacionDTO dto =new RadicacionDTO ();
            
            dto.ban_cod = "40";
            dto.ban_cta = "CUENTA CONVENIO";
            dto.dcod = "20134001254";
            dto.dest = "PR";
            dto.dfpre = DateTime.Now;
            dto.usap = "admin";
            r.rad = dto;

            

            MessageBox.Show(r.RadicarD());

        


        }
    }
}
