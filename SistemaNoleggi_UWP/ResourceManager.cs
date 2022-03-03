using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using Noleggio_Library;
using System.IO;

namespace SistemaNoleggi_UWP
{
    public class ResourceManager
    {
        static ResourceManager instance;

        /// <summary>
        /// Singleton dell'oggetto ResourceManager
        /// </summary>
        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceManager();
                }
                return instance;
            }
        }

        public string PathClienti { get; private set; }
        public string PathVeicoli { get; private set; }
        public string PathNoleggi { get; private set; }

        public ResourceManager() { }

        public void Save(List<Cliente> lista, string path)
        {
            if (File.Exists(path))
            {
                StreamWriter streamWriter = new StreamWriter(path);
                for (int i = 0; i < lista.Count; i++)
                {
                }
                streamWriter.Close();
            }
        }

        public void Save(List<Veicolo> lista, string path)
        {
            if (File.Exists(path))
            {
                StreamWriter streamWriter = new StreamWriter(path);
                for (int i = 0; i < lista.Count; i++)
                {
                }
                streamWriter.Close();
            }
        }

        public void Save(List<Noleggio> lista)
        {
            if (File.Exists(PathNoleggi))
            {
                StreamWriter streamWriter = new StreamWriter(PathNoleggi);
                for (int i = 0; i < lista.Count; i++)
                {
                }
                streamWriter.Close();
            }
        }

        public List<Cliente> Refresh(List<Cliente> lista)
        {
            if (!File.Exists(PathClienti))
            {
                ErrorDialog errorDialog = new ErrorDialog("File non trovato nel percorso.");
            }

            StreamReader streamReader = new StreamReader(PathClienti);

            while (!streamReader.EndOfStream)
            {
                var data = streamReader.ReadLine().Split(',');

                lista.Add(new Cliente(data[0], data[1], data[2]));
            }

            streamReader.Close();

            return lista;
        }

        public void Refresh(List<Veicolo> lista)
        {
            StreamReader streamReader = new StreamReader(PathVeicoli);

            while (!streamReader.EndOfStream)
            {
                var data = streamReader.ReadLine().Split(',');

                lista.Add(new Veicolo(data[0], data[1], decimal.Parse(data[2]), decimal.Parse(data[3])));
            }

            streamReader.Close();
        }

        public void Refresh(List<Noleggio> lista)
        {
            StreamReader streamReader = new StreamReader(PathNoleggi);

            while (!streamReader.EndOfStream)
            {
                var data = streamReader.ReadLine().Split(',');

                Cliente cliente = SistemaNoleggi.Instance.CercaCliente(data[2]);
                Veicolo veicolo = SistemaNoleggi.Instance.CercaVeicolo(data[3]);

                lista.Add(new Noleggio(DateTime.Parse(data[0]), int.Parse(data[1]), cliente, veicolo));
            }

            streamReader.Close();
        }

        public async void LoadClienti()
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();
            PathClienti = file.Path;
        }
        
        public async void LoadVeicoli()
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();
            PathVeicoli = file.Path;
        }

        public async void LoadNoleggi()
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();
            PathNoleggi = file.Path;
        }
    }
}