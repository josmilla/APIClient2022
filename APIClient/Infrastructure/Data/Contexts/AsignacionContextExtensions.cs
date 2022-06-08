using Microsoft.EntityFrameworkCore;
using APIClient.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
 

namespace APIClient.Infrastructure.Data.Contexts
{
    public static class AsignacionContextExtensions
    {

         

        public static void EnsureSeeDataForContext(this AsignacionContext context)
        {
            
           // context.Asignacion.RemoveRange(context.Asignacion);
           // context.SaveChanges();

            //List<Asignacion> asignaciones = new List<Asignacion>();

            //asignaciones.Add(new Asignacion
            //{
            //    //Id = new Guid("40abd248-4b9f-4120-976b-a3ca4f3f7494"),
            //   // Id = 1,
            //    Matricula = "U20200",
            //    Nombres = "Juan P",
            //    ApellidoPaterno = "Rojas",
            //    ApellidoMaterno = "Rivas",
            //    Rol = "Developer",
            //    RolInsourcing = "DEV",
            //    CodApp = "E210",
            //    Asignar = 50,
            //    FechaRegistro = DateTime.Now
            //});
            //asignaciones.Add(new Asignacion
            //{
            //    //Id = new Guid("0f8c4dd9-ebb2-4ef3-a22f-4a9fb35a6f39"),
            //  //  Id = 2,
            //    Matricula = "U20200",
            //    Nombres = "Juan P",
            //    ApellidoPaterno = "Rojas",
            //    ApellidoMaterno = "Rivas",
            //    Rol = "Develepor",
            //    RolInsourcing = "DEV",
            //    CodApp = "E212",
            //    Asignar = 50,
            //    FechaRegistro = DateTime.Now
            //});
            //asignaciones.Add(new Asignacion
            //{
            //    //Id = new Guid("7695dbc2-66ca-4513-b63b-f989de30c2df"),
            //   // Id = 3,
            //    Matricula = "U20100",
            //    Nombres = "Juan P",
            //    ApellidoPaterno = "Rojas",
            //    ApellidoMaterno = "Rivas",
            //    Rol = "Developer",
            //    RolInsourcing = "DEV",
            //    CodApp = "E213",
            //    Asignar = 20,
            //    FechaRegistro = DateTime.Now
            //});
            //asignaciones.Add(new Asignacion
            //{
            //    //Id = new Guid("1910902f-73f9-447d-a8ff-92f43c8e1b12"),
            //   // Id = 4,
            //    Matricula = "U20100",
            //    Nombres = "Juan P",
            //    ApellidoPaterno = "Rojas",
            //    ApellidoMaterno = "Rivas",
            //    Rol = "Developer",
            //    RolInsourcing = "DEV",
            //    CodApp = "E214",
            //    Asignar = 70,
            //    FechaRegistro = DateTime.Now
            //});
            //asignaciones.Add(new Asignacion
            //{
            //    //Id = new Guid("0453dce5-e557-4ee7-8ba0-6f6599787e37"),
            //   // Id = 5,
            //    Matricula = "U20100",
            //    Nombres = "Juan P",
            //    ApellidoPaterno = "Rojas",
            //    ApellidoMaterno = "Rivas",
            //    Rol = "Developer",
            //    RolInsourcing = "DEV",
            //    CodApp = "E215",
            //    Asignar = 10,
            //    FechaRegistro = DateTime.Now
            //});

            //List<Rol> Roles = new List<Rol>();
          
            //    Roles.Add(new Rol
            //            {
                            
            //                    IdRol = 1,
            //                    SqRol = "DEVELOPER",
            //                    RolInsourcing = "DEV",
            //                    Especialidad ="NET",
            //                    FechaRegistro =DateTime.Now,
            //                    UsuarioRegistro ="U20200",
            //                    FechaModificacion =DateTime.Now,
            //                    UsuarioModificacion ="U20300",
            //                    Estado = true
            //              }); 
            
            //context.Asignacion.AddRange(asignaciones);
           
            //context.SaveChanges();
            
        }
    }
}
