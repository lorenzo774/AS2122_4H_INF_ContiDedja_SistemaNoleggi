using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using Noleggio_Library;
using System.IO;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Oggetto che permette di sovrascrivere su file csv e caricare dati dai medesimi
    /// </summary>
    public class ResourceManager
    {
        public string[] Paths { get; set; }
        static ResourceManager instance;


        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResourceManager();

                return instance;
            }
        }


        public ResourceManager()
        {
            Paths = new string[3];
        }


        public void Save(List<Cliente> list)
        {
            string path = Paths[(int)PathType.Cliente];
            if (!File.Exists(path)) return;

            StreamWriter stream = new StreamWriter(path);

            foreach (Cliente obj in list)
                stream.WriteLine(obj.CsvFormat());

            stream.Close();
        }
        public void Save(List<Veicolo> list)
        {
            string path = Paths[(int)PathType.Veicolo];
            if (!File.Exists(path)) return;

            StreamWriter stream = new StreamWriter(path);

            foreach (Veicolo obj in list)
                stream.WriteLine(obj.CsvFormat());

            stream.Close();
        }
        public void Save(List<Noleggio> list)
        {
            string path = Paths[(int)PathType.Noleggio];
            if (!File.Exists(path)) return;

            StreamWriter stream = new StreamWriter(path);

            foreach (Noleggio obj in list)
                stream.WriteLine(obj.CsvFormat());

            stream.Close();
        }


        public List<Cliente> RefreshCliente()
        {
            string path = Paths[(int)PathType.Cliente];
            if (!File.Exists(path))
            {
                ErrorDialog errorDialog = new ErrorDialog("File non trovato, importarne uno nuovo");
                return null;
            }

            List<Cliente> list = new List<Cliente>();
            StreamReader stream = new StreamReader(path);

            string s;
            while ((s = stream.ReadLine()) != null)
                list.Add(new Cliente(s));

            stream.Close();
            return list;
        }
        public List<Veicolo> RefreshVeicolo()
        {
            string path = Paths[(int)PathType.Veicolo];
            if (!File.Exists(path))
            {
                ErrorDialog errorDialog = new ErrorDialog("File non trovato, importarne uno nuovo");
                return null;
            }

            List<Veicolo> list = new List<Veicolo>();
            StreamReader stream = new StreamReader(path);

            string s;
            while ((s = stream.ReadLine()) != null)
                list.Add(new Veicolo(s));

            stream.Close(); 
            return list;
        }
        public List<Noleggio> RefreshNoleggio()
        {
            string path = Paths[(int)PathType.Noleggio];
            if (!File.Exists(path))
            {
                ErrorDialog errorDialog = new ErrorDialog("File non trovato, importarne uno nuovo");
                return null;
            }

            List<Noleggio> list = new List<Noleggio>();
            StreamReader stream = new StreamReader(path);

            string s;
            while ((s = stream.ReadLine()) != null)
                list.Add(new Noleggio(s));

            stream.Close();
            return list;
        }


        public async void Load(PathType pathType)
        {
            var picker = new FileOpenPicker() { ViewMode = PickerViewMode.Thumbnail };
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();
            Paths[(int)pathType] = file.Path;
        }


        bool checkType<T>(List<T> list)
        {
            if (list.Count > 0)
                if (list[0] is CsvSerializableObject)
                    return true;

            return false;
        }
    }

    public enum PathType
    {
        Cliente,
        Veicolo,
        Noleggio
    }

    public abstract class CsvSerializableObject { }
}