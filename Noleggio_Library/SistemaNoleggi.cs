﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Noleggio_Library
{
    public class SistemaNoleggi
    {
        public static SistemaNoleggi Instance {
            get 
            { 
                if(instance == null)
                {
                    instance = new SistemaNoleggi();
                }
                return instance;
            }
        }
        private static SistemaNoleggi instance;

        public List<Veicolo> Veicoli { get; private set; }
        public List<Noleggio> Noleggi { get; private set; }
        public List<Cliente> Clienti { get; private set; }

        public List<Automobile> Automobili { 
            get 
            { 
                return Veicoli.OfType<Automobile>().ToList();
            } 
        }
        public List<Furgone> Furgoni { 
            get 
            {
                return Veicoli.OfType<Furgone>().ToList();
            } 
        }

        public SistemaNoleggi()
        {
            Clienti = new List<Cliente>();
            Noleggi = new List<Noleggio>();
            Veicoli = new List<Veicolo>();
        }


        public Veicolo CercaVeicolo(string targa)
        {
            return Veicoli.FirstOrDefault(v => v.Targa == targa);
        }

        public Cliente CercaCliente(string cF)
        {
            return Clienti.FirstOrDefault(v => v.CF == cF);
        }

        public void AggiungiCliente(string nome, string cognome, string cF)
        {
            Clienti.Add(new Cliente(nome, cognome, cF));
        }

        public void AggiungiAutomobile(string targa, string modello, decimal costo, decimal tariffaGiornaliera, int numeroPosti)
        {
            Veicoli.Add(new Automobile(targa, modello, costo, tariffaGiornaliera, numeroPosti));
        }

        public void AggiungiFurgone(string targa, string modello, decimal costo, decimal tariffaGiornaliera, double capacita)
        {
            Veicoli.Add(new Furgone(targa, modello, costo, tariffaGiornaliera, capacita));
        }

        public void AggiungiNoleggio(DateTime dataInizio, int durataGiorni, Cliente cliente, Veicolo veicolo)
        {
            Noleggi.Add(new Noleggio(dataInizio, durataGiorni, cliente, veicolo));
        }

        public void RimuoviCliente(Cliente cliente)
        {
            Clienti.Remove(cliente);
        }

        public void RimuoviVeicolo(Veicolo veicolo)
        {
            Veicoli.Remove(veicolo);
        }

        public void RimuoviNoleggio(Noleggio noleggio)
        {
            Noleggi.Remove(noleggio);
        }
    }
}