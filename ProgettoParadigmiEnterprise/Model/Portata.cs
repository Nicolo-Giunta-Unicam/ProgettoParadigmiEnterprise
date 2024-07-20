﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProgettoParadigmiEnterprise.Model
{
    [Table("Portate")]
    public class Portata
    {
        [Key]
        public int id;
        public String nome { get; set; }
        public double prezzo { get; set; }
        public TipologiaPortata tipologia { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Ordine> ordini { get; set; } = new HashSet<Ordine>();
        public Portata(string nome, double prezzo, TipologiaPortata tipologia)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.tipologia = tipologia;
        }

        public Portata() { }
    }

    public enum TipologiaPortata
    {
        Primo, Secondo, Contorno, Dolce
    }
}
