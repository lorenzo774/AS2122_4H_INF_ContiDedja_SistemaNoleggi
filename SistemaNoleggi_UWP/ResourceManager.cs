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


        public async void SaveAsync(List<Cliente> list)
        {
            var file = files[(int)FileType.Cliente];

            if (file == null)
            {
                Message($"File per i 'Clienti' inesistente");
                return;
            }

            List<string> strList = new List<string>();
            foreach (Cliente cliente in list)
                strList.Add(cliente.CsvFormat());

            IEnumerable<string> lines = strList;
            await FileIO.WriteLinesAsync(file, lines);
        }
        public async void SaveAsync(List<Veicolo> list)
        {
            var file = files[(int)FileType.Veicolo];

            if (file == null)
            {
                Message($"File per i 'Veicoli' inesistente");
                return;
            }

            List<string> strList = new List<string>();
            foreach (Veicolo veicolo in list)
                strList.Add(veicolo.CsvFormat());

            IEnumerable<string> lines = strList;
            await FileIO.WriteLinesAsync(file, lines);
        }
        public async void SaveAsync(List<Noleggio> list)
        {
            var file = files[(int)FileType.Noleggio];

            if (file == null)
            {
                Message($"File per i 'Noleggi' inesistente");
                return;
            }

            List<string> strList = new List<string>();
            foreach (Noleggio noleggio in list)
                strList.Add(noleggio.CsvFormat());

            IEnumerable<string> lines = strList;
            await FileIO.WriteLinesAsync(file, lines);
        }


        public async Task<List<Cliente>> RefreshClienteAsync()
        {
            List<Cliente> list = new List<Cliente>();

            var file = files[(int)FileType.Cliente];
            if (file == null)
                return new List<Cliente>();

            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var str in readFile)
                list.Add(new Cliente(str));

            return list;
        }
        public async Task<List<Veicolo>> RefreshVeicoloAsync()
        {
            List<Veicolo> list = new List<Veicolo>();

            var file = files[(int)FileType.Veicolo];
            if (file == null)
                return new List<Veicolo>();

            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var str in readFile)
                list.Add(DeserializeVeicolo(str));

            return list;
        }
        public async Task<List<Noleggio>> RefreshNoleggioAsync()
        {
            List<Noleggio> list = new List<Noleggio>();

            var file = files[(int)FileType.Noleggio];
            if (file == null)
                return new List<Noleggio>();

            var readFile = await FileIO.ReadLinesAsync(file);
            foreach (var str in readFile)
                list.Add(new Noleggio(str));

            return list;
        }


        public async void LoadAsync(FileType pathType)
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

        Veicolo DeserializeVeicolo(string str)
        {
            string[] data = str.Split(',');

            // Se i kg di capacitá sono meno di 10 il veicolo verrá valutato come autmomobile
            if (int.Parse(data[3]) < 10)
                return new Automobile(str);

            return new Furgone(str);
        }
    }

    public enum FileType
    {
        Cliente,
        Veicolo,
        Noleggio
    }
}