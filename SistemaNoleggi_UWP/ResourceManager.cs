using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using Noleggio_Library;

namespace SistemaNoleggi_UWP
{
    /// <summary>
    /// Oggetto che permette di sovrascrivere su file csv e caricare dati dai medesimi
    /// </summary>
    public class ResourceManager
    {
        StorageFile[] files;
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
            files = new StorageFile[3];
        }


        public async void Save(List<Cliente> list)
        {
            var file = files[(int)FileType.Cliente];

            if (file == null)
            {
                Message($"File inesistente, path: {file.Path}");
                return;
            }

            List<string> strList = new List<string>();
            foreach (Cliente cliente in list)
                strList.Add(cliente.CsvFormat());

            IEnumerable<string> lines = strList;
            await FileIO.WriteLinesAsync(file, lines);
        }
        public async void Save(List<Veicolo> list)
        {
            var file = files[(int)FileType.Veicolo];

            if (file == null)
            {
                Message($"File inesistente, path: {file.Path}");
                return;
            }

            List<string> strList = new List<string>();
            foreach (Veicolo veicolo in list)
                strList.Add(veicolo.CsvFormat());

            IEnumerable<string> lines = strList;
            await FileIO.WriteLinesAsync(file, lines);
        }
        public async void Save(List<Noleggio> list)
        {
            var file = files[(int)FileType.Noleggio];

            if (file == null)
            {
                Message($"File inesistente, path: {file.Path}");
                return;
            }

            List<string> strList = new List<string>();
            foreach (Noleggio noleggio in list)
                strList.Add(noleggio.CsvFormat());

            IEnumerable<string> lines = strList;
            await FileIO.WriteLinesAsync(file, lines);
        }


        public async Task<List<Cliente>> RefreshCliente()
        {
            List<Cliente> list = new List<Cliente>();

            var file = files[(int)FileType.Cliente];
            if (file == null)
            {
                Message("File dei clienti inesistente");
                return new List<Cliente>();
            }

            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var str in readFile)
                list.Add(new Cliente(str));

            return list;
        }
        public async Task<List<Veicolo>> RefreshVeicolo()
        {
            List<Veicolo> list = new List<Veicolo>();

            var file = files[(int)FileType.Veicolo];
            if (file == null)
            {
                Message("File dei veicoli inesistente");
                return new List<Veicolo>();
            }

            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var str in readFile)
                list.Add(new Veicolo(str));

            return list;
        }
        public async Task<List<Noleggio>> RefreshNoleggio()
        {
            List<Noleggio> list = new List<Noleggio>();

            var file = files[(int)FileType.Noleggio];
            if (file == null)
            {
                Message("File dei noleggi inesistente");
                return new List<Noleggio>();
            }

            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var str in readFile)
                list.Add(new Noleggio(str));

            return list;
        }


        public async void Load(FileType pathType)
        {
            var picker = new FileOpenPicker() { ViewMode = PickerViewMode.Thumbnail };
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file == null)
            {
                Message("File inesistente");
                return;
            }
            files[(int)pathType] = file;
        }

        void Message(string msg)
        {
            ErrorDialog errorDialog = new ErrorDialog(msg);
            errorDialog.Show();
        }
    }

    public enum FileType
    {
        Cliente,
        Veicolo,
        Noleggio
    }
}