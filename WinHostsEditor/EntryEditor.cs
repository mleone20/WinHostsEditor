using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHostsEditor
{
    public partial class EntryEditor : Form
    {
        /// <summary>
        /// Entry da modificare
        /// </summary>
        public HostEntry Entry { get; private set; }

        public EntryEditor(HostEntry Entry)
        {
            InitializeComponent();
            this.Entry = Entry;
            this.txtHost.Text = Entry.Host;
            this.txtIp.Text = Entry.Ip;
            this.chkAbilita.Checked = Entry.Enabled;
            this.txtComment.Text = Entry.Comment;
        }
        
        /// <summary>
        /// Ritorna se l'ip è valido
        /// </summary>
        /// <param name="Ip"></param>
        /// <returns></returns>
        private bool IsValidIp(string Ip)
        {
            if (string.IsNullOrEmpty(Ip))
                return false;
            var data = Ip.Split(".");
            if (data.Length != 4)
                return false;
            foreach(var d in data)
            {
                foreach (var c in d)
                    if (!char.IsNumber(c))
                        return false;
            }
            return true;
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            var ip = txtIp.Text;
            var host = txtHost.Text;

            var anyError = 0;

            errProvider.Clear();
            if (!IsValidIp(ip))
            {
                anyError++;
                errProvider.SetError(txtIp, "IP non valido");
            }
            if (string.IsNullOrEmpty(host))
            {
                errProvider.SetError(txtHost, "Hostname non valido");
                anyError++;
            }


            if (anyError > 0)
                return;

            // Salva la config
            Entry.Host = this.txtHost.Text;
            Entry.Ip = this.txtIp.Text;
            Entry.Enabled = this.chkAbilita.Checked;
            Entry.Comment = this.txtComment.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
