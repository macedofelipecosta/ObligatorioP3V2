using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class precarga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "PassWord"}, new object[] { "email@email.com", "Password123!"});
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "PassWord"}, new object[] { "email1@email.com", "Password123!"});
            migrationBuilder.InsertData("Usuarios", new[] { "Email", "PassWord"}, new object[] { "email2@email.com", "Password123!"});

            migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {1, "Simple", "una habitación asignada a dos personas. Puede tener una o más camas.", "Doble", 1, 1, 2, "hotel_index.jpg" });
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {2, "Simple doble", "una habitación con dos camas dobles o tal vez queen. Puede ser ocupado por una o más personas.", "Doble-doble", 1, 1, 4, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {3, "Estudio 1", "una habitación con una cama de estudio, un sofá que se puede convertir en una cama. También puede tener una cama adicional.", "Estudio", 1, 1, 2, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {4, "Individual simple", "una habitación asignada a una persona. Puede tener una o más camas.", "Individual", 1, 1, 2, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {5, "Suite junior", "Una habitación individual con una cama y una sala de estar. A veces, el área para dormir está en un dormitorio separado del salón o la sala de estar.", "Junior Suite", 1, 1, 2, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {6, "King junior", "una habitación con una cama king-size. Puede ser ocupado por una o más personas.", "King", 1, 1, 5, "Sin_título.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {7, "Master Suite", "Un salón o sala de estar conectada a uno o más dormitorios.", "Master Suite", 1, 1, 8, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {8, "Quadrulpe", "una sala asignada a cuatro personas. Puede tener dos o más camas", "Quad", 1, 1, 8, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {9, "Queen Isabel", "una habitación con una cama de matrimonio. Puede ser ocupado por una o más personas", "Quee", 1, 1, 4, "hotel_index.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {10, "Triplete", "una habitación asignada a tres personas. Puede tener dos o más camas", "Triple", 1, 1, 3, "Sin_título.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {11, "Twin's", "Una cabaña en la llanura", "Twi", 1, 1, 2, "OIP.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {12, "Estudio 2", "una habitación con una cama de estudio, un sofá que se puede convertir en una cama. También puede tener una cama adicional.", "Estudio", 1, 1, 5, "Sin_título.jpg"});
			migrationBuilder.InsertData("Cabanas", new[] { "NumeroHabitacion", "Nombre", "Descripcion", "NombreTipo", "Jacuzzi", "HabilitadoAReservas", "CapacidadHabitacion", "Fotografia" }, new object[] {13, "Estudio 3", "una habitación con una cama de estudio, un sofá que se puede convertir en una cama. También puede tener una cama adicional.", "Estudio", 1, 1, 6, "OIP.jpg"});

            migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Doble", "una habitación asignada a dos personas. Puede tener una o más camas.", 130});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Doble-doble", "una habitación con dos camas dobles (o tal vez queen. Puede ser ocupado por una o más personas.", 310});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Estudio", "una habitación con una cama de estudio, un sofá que se puede convertir en una cama. También puede tener una cama adicional.", 340});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Individual", "una habitación asignada a una persona. Puede tener una o más camas.", 100});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Junior Suite", "Una habitación individual con una cama y una sala de estar. A veces, el área para dormir está en un dormitorio separado del salón o la sala de estar.", 400});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"King", "una habitación con una cama king-size. Puede ser ocupado por una o más personas.", 250});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Master Suite", "Un salón o sala de estar conectada a uno o más dormitorios.", 370});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Quad", "una sala asignada a cuatro personas. Puede tener dos o más camas", 190});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Queen", "una habitación con una cama de matrimonio. Puede ser ocupado por una o más personas", 220});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Triple", "una habitación asignada a tres personas. Puede tener dos o más camas", 160});
			migrationBuilder.InsertData("Tipos", new[] { "Nombre", "Descripcion", "CostoHuesped"}, new object[] {"Twi", "una habitación con dos camas. Puede ser ocupado por una o más personas.", 280});
            

            migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] { 1, "2023-04-29 12:22:00", "Prueba", 5, "Felipe", 3 });
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {2, "2023-04-29 12:28:00", "tema1", 1211, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {3, "2023-04-12 12:47:00", "Prueba", 6, "Felipe", 5});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {4, "2023-04-29 13:06:00", "a", 1234, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {4, "2023-04-29 13:06:00", "a", 1234, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {5, "2023-04-16 13:06:00", "a", 1234, "Felipe", 6});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {6, "2023-04-30 13:24:00", "Prueba", 4, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {7, "2023-04-30 13:28:00", "Prueba", 49, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {8, "2023-04-30 13:30:00", "qwerty", 18, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {9, "2023-05-01 13:30:00", "qwerty", 18, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {10, "2023-05-01 13:35:00", "qwerty", 6, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {11, "2023-05-01 13:38:00", "qwerty", 5, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {12, "2023-05-02 13:42:00", "Prueba", 5, "Felipe", 3});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {13, "2023-04-30 13:46:00", "Prueba", 6, "Felipe", 1});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {14, "2023-05-02 13:49:00", "qwerty", 12, "Felipe", 4});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {15, "2023-05-01 20:44:00", "Prueba1", 12, "Felipe", 5});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {16, "2023-05-01 20:44:00", "Prueba1", 12, "Felipe", 5});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {17, "2023-05-01 20:45:00", "Prueba2", 12, "Felipe", 5});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {18, "2023-04-30 19:41:00", "Prueba mantenimiento 8/5", 122, "Lunes", 1});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {19, "2023-04-30 19:00:00", "Prueba mantenimiento 8/5", 123, "lunes", 1});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {20, "2023-05-08 19:00:00", "Prueba mantenimiento 8/5", 124, "lunes", 1});
			migrationBuilder.InsertData("Mantenimientos", new[] { "FechaMantenimiento", "Descripcion", "Costo", "Operados", "CabanaId"}, new object[] {21, "2023-05-10 14:33:00", "Ultima prueba de mantenimiento", 500, "Felipe", 1});



            

        }

        /// <inheritdoc />
      
    }
}
