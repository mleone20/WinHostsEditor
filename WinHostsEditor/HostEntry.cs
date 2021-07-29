using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHostsEditor
{
    /// <summary>
    /// Rappresenta una entry nel file di host
    /// </summary>
    public class HostEntry
    {
        /// <summary>
        /// Abilitato?
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Commento associato
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// IP impostato
        /// </summary>
        public string Ip { get; set; }

        public override string ToString()
        {
            return Ip + " " + Host;
        }
    }
}
