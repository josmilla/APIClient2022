﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIClient.Infrastructure.Data.Entities
{
    public partial class PorcentajeAsignacion
    {
        [Key]
        public int IdPorcentajeAsignacion { get; set; }
        public int? IdCarga { get; set; }
        public int? IdPeriodo { get; set; }
        public int? IdRol { get; set; }
        public int? IdAplicativo { get; set; }
        public double? Porcentaje { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool? Estado { get; set; }
    }
}