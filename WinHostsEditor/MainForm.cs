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
    public partial class MainForm : Form
    {
        /// <summary>
        /// File di host sul quale lavorare
        /// </summary>
        protected HostFile HostFile { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            // Crea il file
            HostFile = new HostFile();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Leggi il file
                HostFile.Read();
            }
            catch(Exception error)
            {
                MessageBox.Show(this, "Non è stato possibile leggere il file di host. Sei amministratore?", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Setup iniziale della lista
            foreach(var i in HostFile.Entries)
            {
                AggiungiVoce(i);
            }
        }

        /// <summary>
        /// Aggiungi una voce alla lista
        /// </summary>
        /// <param name="e"></param>
        private void AggiungiVoce(HostEntry e)
        {

            // Aggiungi il list item
            var lItem = MainList.Items.Add(e.Enabled ? "Si" : "No");
            lItem.SubItems.Add(e.Host);
            lItem.SubItems.Add(e.Ip);
            lItem.SubItems.Add(e.Comment);
            lItem.Tag = e;
        }

        private void MainList_DoubleClick(object sender, EventArgs e)
        { 
            foreach(var l in MainList.SelectedIndices)
            {
                var lv = MainList.Items[(int)l];
                var i = MainList.Items[(int)l].Tag as HostEntry;
                if (i != null)
                {
                    var dialog = new EntryEditor(i);
                    if(dialog.ShowDialog() == DialogResult.OK)
                    {
                        lv.SubItems[0].Text = i.Enabled ? "Si" : "No";
                        lv.SubItems[1].Text = i.Host;
                        lv.SubItems[2].Text = i.Ip;
                        lv.SubItems[3].Text = i.Comment;
                    }
                }
            } 
        }

        private void btnApplica_Click(object sender, EventArgs e)
        {
            // Salva il file
            try
            {
                // Salva un backup del file prima di procedere
                HostFile.Backup();

                // Salva il file
                HostFile.Save();

                MessageBox.Show(this, "File di host aggiornato!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception exc)
            {
                MessageBox.Show(this, "Non è stato possibile salvare il file di host. Dati errore: "  + exc.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextListMenu_Opening(object sender, CancelEventArgs e)
        {
            tsmEdit.Enabled = MainList.SelectedIndices.Count > 0;
            tsmRemove.Enabled = MainList.SelectedIndices.Count > 0;
        }

        private void contextListMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tsmAdd)
            {
                var dialog = new EntryEditor(new HostEntry() { Ip = HostFile.Entries.Last().Ip });
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    HostFile.Entries.Add(dialog.Entry);
                    AggiungiVoce(dialog.Entry);
                }
            }
            else if (e.ClickedItem == tsmRemove)
            {
                List<object> items = new List<object>();
                foreach (var i in MainList.SelectedItems)
                    items.Add(i);
                foreach (var i in items)
                    MainList.Items.Remove(i as ListViewItem);
            }
            else if (e.ClickedItem == tsmEdit)
                MainList_DoubleClick(sender, null);
        }
    }
}
