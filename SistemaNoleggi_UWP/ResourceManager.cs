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

        /// <summary>
        /// Rappresenta i percorsi per i tre oggetti Cliente [0], Veicolo [1], e Noleggio [2].
        /// </summary>
        public string[] Paths { get; set; }

        public ResourceManager()
        {
            Paths = new string[3];
        }

        /// <summary>
        /// Metodo che permette di convertire i dati in formato csv per poi salvarli sul file indicato dal percorso
        /// </summary>
        public void Save(List<ICsvSerializable> lista, PathType pathType)
        {
            ErrorDialog errorDialog1 = new ErrorDialog();
            string path = Paths[(int)pathType];
            
            if (!File.Exists(path))
            {
                ErrorDialog errorDialog = new ErrorDialog("Percorso non trovato");
                errorDialog.Show();
                return;
            }

            StreamWriter stream = new StreamWriter(path);

            foreach (var item in lista)
            {
                stream.WriteLine(item.CsvFormat());
            }

            stream.Close();
        }

        /// <summary>
        /// Metodo che permette di ricavare una lista di oggetti da un file csv dato il suo percorso
        /// </summary>
        public async Task<List<ICsvSerializable>> Load()
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.FileTypeFilter.Add(".csv");

            StorageFile file = await picker.PickSingleFileAsync();

            List<ICsvSerializable> serializableObjects = new List<ICsvSerializable>();
            StreamReader stream = File.OpenText(file.Path);
            string s;
            while ((s = stream.ReadLine()) != null)
            {
                serializableObjects.Add(serializableObjects[0]);
            }

            return serializableObjects;
        }


        public void Refresh(PathType pathType)
        {
            string path = Paths[(int)pathType];

            if (!File.Exists(path))
            {
                ErrorDialog errorDialog = new ErrorDialog("File non trovato nel percorso.");
                return;
            }


            StreamReader streamReader = new StreamReader(path);

            while (!streamReader.EndOfStream)
            {
                var data = streamReader.ReadLine().Split(',');

                //lista.Add(new Cliente(data[0], data[1], data[2]));
            }

            streamReader.Close();
        }
    }

    /// <summary>
    /// Enumeratore utilizzabile per specificare se il percorso desiderato é quello per i Clienti, Veicoli o Noleggi
    /// </summary>
    public enum PathType
    {
        Cliente,
        Veicolo,
        Noleggio
    }
}