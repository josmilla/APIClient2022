﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIClient.Infrastructure.Data.Entities
{

    public partial class Aplicativo
    {


        //public Aplicativo()
        //{
        //    Asignars = new HashSet<Asignacion>();
        //}
        [Key]
        public int IdAplicativo { get; set; }
        public string CodAplicativo { get; set; }
        public string NombreAplicativo { get; set; }
        public string BiddingblockAplicativo { get; set; }
        public string EstadoAplicativo { get; set; }
        //public int? IdPeriodo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool? Estado { get; set; }

        [JsonIgnore]
        public ICollection<Asignacion> Asignacion { get; set; }
    }
}