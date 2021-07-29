using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHostsEditor
{
    /// <summary>
    /// Si occupa della gestione del file di host
    /// </summary>
    public class HostFile
    {
        private const string FILE = @"C:\Windows\System32\drivers\etc\hosts";

        /// <summary>
        /// Entries registrate
        /// </summary>
        public List<HostEntry> Entries { get; private set; }

        /// <summary>
        /// Crea una nuova istanza del file di host
        /// </summary>
        public HostFile()
        {
        }

        /// <summary>
        /// Ottiene una entry
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static HostEntry NextEntry(StreamReader reader)
        {
            // Se siamo alla fine, diamo errore
            if (reader.EndOfStream)
                return null;

            // Leggiamo
            string header = "";
            while (!reader.EndOfStream)
            {
                // Ottiene la linea
                var line = reader.ReadLine();

                // Procediamo
                if (string.IsNullOrEmpty(line))
                {
                    header += line + Environment.NewLine;
                    continue;
                }

                // Crea la entry
                line = line.Trim();
                HostEntry entry = new HostEntry();

                // Se inizia con # è disabilitata
                if (line.StartsWith("#"))
                    entry.Enabled = false;
                else
                    entry.Enabled = true;

                // Splittiamo ip nome fino al primo carattere non numerico
                bool isReadingIp = true;
                entry.Ip = "";
                entry.Host = "";
                for (var i = line.StartsWith("#") ? 1 : 0; i < line.Length; i++)
                {
                    // Se abbiamo trovato il separatore, cambiamo tipo di lettura
                    if (char.IsSeparator(line[i]))
                    {
                        if (isReadingIp)
                        {
                            isReadingIp = false;
                            continue;
                        }
                    }
                    else if (line[i] == ' ' || line[i] == '\t')
                    {
                        if (isReadingIp)
                        {
                            isReadingIp = false;
                            continue;
                        }
                    }

                    // Procediamo
                    if (isReadingIp)
                        entry.Ip += line[i];
                    else
                        entry.Host += line[i];
                }

                // Evitiamo errori e quindi stringhe vuote
                if (string.IsNullOrEmpty(entry.Ip) || string.IsNullOrEmpty(entry.Host))
                {
                    header += line + Environment.NewLine;
                    continue;
                }

                if (!IsValidIp(entry.Ip))
                {
                    header += line + Environment.NewLine; 
                    continue;
                }

                // Ritorniamo la entry appena letta
                entry.Comment = header;
                header = "";
                return entry;
            }

            // Non abbiamo trovato nulla
            return null;
        }

        /// <summary>
        /// Salva il file di host scrivendolo
        /// </summary>
        internal void Save()
        {
            // Riscrivi il file di hosts
            using (var writer = new StreamWriter(FILE))
            {
                foreach (var e in Entries)
                { 
                    if (!string.IsNullOrWhiteSpace(e.Comment))
                        writer.Write(  e.Comment);
                    if (!e.Enabled)
                        writer.Write("#");
                    writer.WriteLine(e.Ip + "\t" + e.Host); 
                }
            }
        }

        /// <summary>
        /// Ritorna se l'ip è valido
        /// </summary>
        /// <param name="Ip"></param>
        /// <returns></returns>
        private static bool IsValidIp(string Ip)
        {
            if (string.IsNullOrEmpty(Ip))
                return false;
            if (Ip.StartsWith(":"))
                return true;
            var data = Ip.Split(".");
            if (data.Length != 4)
                return false;
            foreach (var d in data)
            {
                foreach (var c in d)
                    if (!char.IsNumber(c))
                        return false;
            }
            return true;
        }


        /// <summary>
        /// Effettua il backup in locale
        /// </summary>
        internal void Backup()
        {
            // Fai una copia del file in locale
            File.Copy(FILE, "hosts", true);
        }

        /// <summary>
        /// Tenta la lettura del file
        /// </summary>
        /// <returns></returns>
        public void Read()
        {
            // Creaiamo un reader
            using (var reader = new StreamReader(FILE))
            {
                Entries = new List<HostEntry>();

                // Finchè non siamo alla fine
                while (!reader.EndOfStream)
                {
                    /// Otteniamo una entry
                    var entry = NextEntry(reader);

                    // Se è valida, andiamo avanti
                    if (entry != null)
                        Entries.Add(entry);
                }
            }
        }
    }
}
