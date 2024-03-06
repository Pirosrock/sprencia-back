using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Repositories;
using Sprencia_Api.Services.Security;
using System.Globalization;

namespace Sprencia_Api.Configuration
{
    internal static class InitDatabase
    {
        internal static async Task Init(WebApplication app)
        {
            // Registrar en la BD los datos iniciales

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<DataBaseContext>();

                // Realiza las migraciones automáticamente
                dbContext.Database.Migrate();


                var encryptionServices = services.GetRequiredService<IEncryptService>();
                var existingUser = await dbContext.Usuarios.ToListAsync();
                if (!existingUser.Any())
                {
                    await dbContext.Usuarios.AddAsync(new Usuario { UserName = "Admin", Contraseña = encryptionServices.EncryptString("12345Aa.") });
                    await dbContext.SaveChangesAsync();
                }

                var existingActividad = await dbContext.Actividades.ToListAsync();
                if (!existingActividad.Any())
                {
                    await dbContext.Actividades.AddRangeAsync(
                        new Actividad { Nombre = "Sendero Majaceite", Resumen = "Recorre el viejo sendero de pastoreo disfrutando de su rio y bellas vistas", Precio = 30, Estado = true },
                        new Actividad { Nombre = "MasterClass Banca", Resumen = "Le enseñaremos a realizar bizum, transferencias y acciones en cajeros de las principales entidades", Precio = 8, Estado = true },
                        new Actividad { Nombre = "Baile moderno", Resumen = "Mueve el esqueleto con nosotros, pasemos un rato divertido mientras aprendemos los bailes más modernos", Precio = 10, Estado = true },
                        new Actividad { Nombre = "Clases de informatica básica", Resumen = "Introducción al manejo de Windows y al paquete office", Precio = 20, Estado = true },
                        new Actividad { Nombre = "Excursión Selwo", Resumen = "Visita selwo con alojamiento incluido y visita guiada", Precio = 40, Estado = true },
                        new Actividad { Nombre = "Acercamiento intergeneracional", Resumen = "Convivencia entre jovenes y adultos para que ambos puedan aprender de los otros", Precio = 0, Estado = true },
                        new Actividad { Nombre = "Torneo de muss", Resumen = "Que la suerte esté de vuestra parte", Precio = 10, Estado = true },
                        new Actividad { Nombre = "Clases de interpretación", Resumen = "¿Llevas un actor dentro, nunca es tarde para ganar un oscar?", Precio = 22, Estado = true },
                        new Actividad { Nombre = "Cata de vinos", Resumen = "Disfruta del sabor de nuestra tierra, deleita tu paladar con los mejores vinos", Precio = 20, Estado = true },
                        new Actividad { Nombre = "Nuevas tecnologías y redes sociales", Resumen = "Mantente al día, para que la proxima vez seas tu quien enseñe a tu nieto", Precio = 10, Estado = true }
                        );
                    await dbContext.SaveChangesAsync();
                }
                var existingOpiniones = await dbContext.Opiniones.ToListAsync();
                if (!existingOpiniones.Any())
                {
                    await dbContext.Opiniones.AddRangeAsync(
                        new Opinion { Texto = "Paisajes preciosos un paseo muy agradable", Fecha = DateTime.ParseExact("08-01-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 1 },
                        new Opinion { Texto = "Me encantó cada momento de la excursión. ¡Definitivamente quiero hacerlo de nuevo!", Fecha = DateTime.ParseExact("25-08-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 1 },
                        new Opinion { Texto = "La clase fue muy útil para aprender a realizar operaciones bancarias. Los instructores fueron pacientes y explicaron todo claramente.", Fecha = DateTime.ParseExact("10-03-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 2 },
                        new Opinion { Texto = "Me siento mucho más seguro manejando mi cuenta bancaria después de tomar esta clase. ¡Recomendaría esta experiencia a cualquier persona mayor!.", Fecha = DateTime.ParseExact("25-04-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 2 },
                        new Opinion { Texto = "Me encantó la clase de baile moderno.Fue divertida y me hizo sentir joven de nuevo.", Fecha = DateTime.ParseExact("25-04-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 3 },
                        new Opinion { Texto = "La clase de baile moderno fue genial para mantenerme activo. Los instructores eran increíblemente amigables y pacientes", Fecha = DateTime.ParseExact("28-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 3 },
                        new Opinion { Texto = "La clase de informática básica fue muy útil para aprender los conceptos fundamentales. Los instructores explicaron todo de manera clara y paciente", Fecha = DateTime.ParseExact("12-09-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 4 },
                        new Opinion { Texto = "Disfruté mucho de la clase de informática básica. Aprendí desde lo más básico hasta tareas más avanzadas. Los ejercicios prácticos fueron geniales para aplicar lo aprendido ", Fecha = DateTime.ParseExact("05-11-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 4 },
                        new Opinion { Texto = "Los animales, la naturaleza y la interacción con la vida silvestre fueron impresionantes. Los guías proporcionaron información interesante y cuidaron bien de nosotros", Fecha = DateTime.ParseExact("12-09-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 5 },
                        new Opinion { Texto = "Selwo es un lugar maravilloso para disfrutar de la naturaleza y los animales. La excursión fue educativa y divertida para toda la familia.", Fecha = DateTime.ParseExact("03-09-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 5 },
                        new Opinion { Texto = "Sin duda fue una experiencia enriquecedora, un aprendizaje mutuo de vivencias", Fecha = DateTime.ParseExact("12-02-2019", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 6 },
                        new Opinion { Texto = "Una mañana muy divertida, con una organización perfecta, se hablaron de temas de actualidad y los comparamos con nuestra historia", Fecha = DateTime.ParseExact("17-06-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 6 },
                        new Opinion { Texto = "El torneo fue un éxito. Bien organizado, ambiente agradable y nivel de juego variado", Fecha = DateTime.ParseExact("20-07-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 7 },
                        new Opinion { Texto = "Los torneos de mus para personas mayores son una excelente forma de promover la actividad física y mental, y de socializar", Fecha = DateTime.ParseExact("11-01-2024", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 7 },
                        new Opinion { Texto = "Las clases de interpretación me han ayudado a mejorar mi expresión corporal, mi voz y mi capacidad de improvisación", Fecha = DateTime.ParseExact("20-07-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 8 },
                        new Opinion { Texto = "Las clases me han ayudado a aprender a trabajar en equipo y a comunicarme de forma efectiva", Fecha = DateTime.ParseExact("12-09-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 8 },
                        new Opinion { Texto = "La cata de vinos fue una experiencia muy enriquecedora. Aprendí mucho sobre los diferentes tipos de vinos y pude probar vinos que nunca antes había probado", Fecha = DateTime.ParseExact("12-09-2019", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 9 },
                        new Opinion { Texto = "Las catas de vinos son una excelente forma de aprender sobre el vino y de conocer nuevos vinos. Son una oportunidad perfecta para compartir la pasión por el vino con otros amantes del vino", Fecha = DateTime.ParseExact("09-04-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 9 },
                        new Opinion { Texto = "La clase me ha ayudado a ser más crítica con la información que encuentro en internet", Fecha = DateTime.ParseExact("10-02-2023", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 10 },
                        new Opinion { Texto = "Las clases me han ayudado a entender cómo funcionan las redes sociales y cómo utilizarlas para conectar con mi público objetivo", Fecha = DateTime.ParseExact("12-09-2018", "dd-MM-yyyy", CultureInfo.InvariantCulture), ActividadId = 10 }
                        );

                    await dbContext.SaveChangesAsync();
                }

                var existingHorarios = await dbContext.Horarios.ToListAsync();
                if(!existingHorarios.Any())
                {
                    await dbContext.AddRangeAsync(
                        new Horario { Nombre = "Mañana"},
                        new Horario { Nombre = "Tarde"},
                        new Horario { Nombre = "Fin de semana"}
                        );
                    await dbContext.SaveChangesAsync();
                }
                var existingActividad_Horarios = await dbContext.Actividad_Horarios.ToListAsync();
                if(!existingActividad_Horarios.Any())
                {
                    await dbContext.AddRangeAsync(
                        new Actividad_horarios { ActividadId = 1, HorarioID = 1},
                        new Actividad_horarios { ActividadId = 1, HorarioID = 3 },
                        new Actividad_horarios { ActividadId = 2, HorarioID = 1 },
                        new Actividad_horarios { ActividadId = 2, HorarioID = 2 },
                        new Actividad_horarios { ActividadId = 3, HorarioID = 1 },
                        new Actividad_horarios { ActividadId = 3, HorarioID = 2 },
                        new Actividad_horarios { ActividadId = 4, HorarioID = 1 },
                        new Actividad_horarios { ActividadId = 4, HorarioID = 2 },
                        new Actividad_horarios { ActividadId = 5, HorarioID = 3 },
                        new Actividad_horarios { ActividadId = 6, HorarioID = 3 },
                        new Actividad_horarios { ActividadId = 7, HorarioID = 3 },
                        new Actividad_horarios { ActividadId = 8, HorarioID = 1 },
                        new Actividad_horarios { ActividadId = 8, HorarioID = 2 },
                        new Actividad_horarios { ActividadId = 9, HorarioID = 3 },
                        new Actividad_horarios { ActividadId = 10, HorarioID = 1 },
                        new Actividad_horarios { ActividadId = 10, HorarioID = 2 }

                        );

                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
