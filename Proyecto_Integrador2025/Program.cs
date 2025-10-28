/*
 * Integrantes:
* Yanina Elizabeth Encina Franco */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto_Integrador2025
{
	class Program
	{
		public static void Main(string[] args)
		{
			Club club = new Club("Atletico Barto");
			
			cargaInicial(club);
			
			menuPrincipal(club);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		//el men principal 
static void menuPrincipal(Club club){
			
			string opcion ="";
			bool salir = false;
			do{
				
				Console.Clear();
				
					Console.WriteLine("***Gestion de Club***"  + "\n" +
                    "a. Fichar jugador"  + "\n" +
                    "b. Dar de baja a un jugador"+ "\n"+
                    "c. Designar Capitan"  + "\n" +
                    "d. Submenu de reportes"  + "\n" +
                    "e. Actualizar estado de campaña"  + "\n" +
                    "f. Dar de baja un Dt"  + "\n" +
                    "g. Salir "  + "\n");
					Console.WriteLine("Seleccione una opcion");
					
					opcion = Console.ReadLine().ToLower();
					try{
						
					switch(opcion){
						case "a":
							ficharJugador(club); break;//listo
						case "b" :
							bajaJugador(club); break;//listo
						case"c" :
							designarCapitan(club); break;//listo
						case "d" :
							submenu(club); break;
						case "e" :
							actualizarEstadoCampania(club); break;
						case "f" :
							bajaDT(club); break;
						case "g" :
							salir = true;	break;
						default: 
							Console.WriteLine("***Opcion no valida, intente nuevamnte***"); break;
						}
						
					}
					catch(OperacionInvalidaExcepcion error)
					{
						throw new OperacionInvalidaExcepcion(string.Format("Error: {0}", error.Message));
					}
						if(!salir)
						{
						Console.WriteLine("***Presione alguna tecla para vover al menu principal***");
						Console.ReadKey();
						}
			}
						while(!salir); 
						Console.Clear();
						Console.WriteLine("***Progama finalizado***");
			
		}
			
	
			
		

		
		//fichar un jugador listo
static void ficharJugador(Club club)
		{
			
				string nombre, apellido;
				string posicion= "No asignada";
				
				Console.WriteLine("***Fichar jugador***");
				
				
				Console.Write("Nombre: ");  nombre = Console.ReadLine();
				Console.Write("Apellido: "); apellido = Console.ReadLine();
			
				int dni = intValidoIngresado("Dni: ");
				double sueldo = doubleValidoIngresado("Sueldo: ");
				int numeroFicha = intValidoIngresado("Numero de ficha: ");
				
				//seleccionar posicion
				Console.WriteLine("seleccione posicion"  + "\n" +
	                    "a. Arquero"  + "\n"+
						"b. Defensor"+  "\n"+
						"c. Mediocampista"+"\n"+
						"d. Delantero");
				string seleccionPosicion = Console.ReadLine();
				switch(seleccionPosicion){
					case "a":
						posicion = "Arquero";break;
					case "b" :
						posicion = "Defensor";break;
					case "c" :
						posicion = "Mediocampista";break;
					case "d" :
						posicion =  "Delantero";break;
					default:
						Console.WriteLine("Seleccione una opcion valida....");break;
				}
				Jugador nuevoJugador = new Jugador(nombre, apellido, dni, sueldo,numeroFicha, posicion);
				club.agregarJugador(nuevoJugador);
				Console.WriteLine("{0}, Agregado de manera correcta");
				nuevoJugador.imprimir();
			}
			
			
			
		//dar de baja al jugador listo
static void bajaJugador(Club club)
		{
			int numeroFicha = intValidoIngresado("Ingrese elnumero de ficha del jugador");
			Jugador jugadorBaja = club.obtenerJugadorPorFicha(numeroFicha);
			if (jugadorBaja !=null)
			{
				club.eliminarJugador(jugadorBaja);
				Console.WriteLine("Jugador con numero de ficha: {0}, dado de baja de manera correcta", numeroFicha);
			}else{
				Console.WriteLine("***Numero de ficha {0} inexistente***", numeroFicha );
			}
			Console.WriteLine("Baja finalizada");
			
			
		}
		
		//Designo un Capitan
static void designarCapitan(Club club)
{
	
	Console.WriteLine("***Designar un nuevo Capitan***");
	
	bool terminado= false;
	do{
		
	
	
	
		int numeroficha = intValidoIngresado("Ingrese el numero de ficha del jugador a designar como Capitan: ");
		
		Jugador jugadorAscender = club.obtenerJugadorPorFicha(numeroficha);//aca lo busco por la ficha ingresada
		
		if(jugadorAscender == null){
			Console.WriteLine("***Ficha: {0} no encontrada",numeroficha);
			return;
		} else if(jugadorAscender is Capitan){
			Console.WriteLine("***El jugador ya esta asignado como Capitan***");
			return;
		}
		
		Console.WriteLine("***Ingrese datos del Capitan***");
		
		double nuevaBonifcacion = doubleValidoIngresado("Bonificacion: ");
		int idGrupo = intValidoIngresado("Ingrese el id del grupo para designar: ");
		try{
			
			Grupo grupoAsignado = club.obtenerGrupoPorId(idGrupo);
			
			if (grupoAsignado == null){
				throw new NoHayGrupoLibreExcepcion(string.Format("***No se encontro ningun grupo con id: {0}***",idGrupo));
			}
			
			//Creo el Capitan
			Capitan nuevoCapitan= new Capitan(
				jugadorAscender.Nombre,
				jugadorAscender.Apellido,
				jugadorAscender.Dni,
				jugadorAscender.Sueldo,
				jugadorAscender.NumeroFicha,
				jugadorAscender.Posicion,
				nuevaBonifcacion,
				grupoAsignado
			);
			
			//Reemplazo
			club.eliminarJugador(jugadorAscender);
			club.agregarJugador(nuevoCapitan);
			
			Console.WriteLine("{0} {1} designado como capitan", nuevoCapitan.Nombre, nuevoCapitan.Apellido);
			nuevoCapitan.imprimirCapitan();
			
			
		}catch(NoHayGrupoLibreExcepcion error){
			Console.WriteLine(" Error al designar al capitán.");
			Console.WriteLine("Detalle: {0}",error.Message);
		}
		catch(Exception){
			Console.WriteLine("**No se pudo designar al capitan**");
		}
	}while(!terminado);
		Console.WriteLine("***Designacion terminada***");
	
	
}
			

		
static void submenu(Club club)
		{
			int opcion =0;
			bool salir = false;
		
			do{
				
				Console.Clear();
				Console.WriteLine("1. Ver listado de jugadores" + "\n"+
					                  "2. Ver listado de Equipo en competencia" +"\n"+
					                  "3. Ver listado de Equipos con campaña finalizada" +"\n"+
					                  "4. Listado de equipos de tipo 'Copa'" +"\n"+
					                  "5. Ver listado de capitanes " +"\n"+
					                  "0. Salir ");
				opcion = intValidoIngresado("\nSeleccione una de las opciones ");
				try{
					switch(opcion){
						case 1:		
							listarJugadoresConVinietas(club); break;//Listo
						case 2:
							listarEquiposEnCompetencia(club); break;//listo
						case 3: 
							listarEquiposConCampaniaFin(club); break;//listo
						case 4:
							listarEquiposTipoCopa(club); break;	//listo
						case 5:
							listarCapitanes(club); break;//listo
						case 0:
							salir = true; break;
						default:
							Console.WriteLine("***Opcion no valida, intente nuevamente***"); break;
					}
				}catch(OperacionInvalidaExcepcion error){
					throw new OperacionInvalidaExcepcion(string.Format("Error: {0}",error.Message));
					}
				if(!salir)
					{
					Console.WriteLine("**Presione alguna tecla para vover al menu principal**");
					Console.ReadKey();
				}}
				while(!salir);
			}

//Submenu 1
static void listarJugadoresConVinietas(Club club)
{
	ArrayList  jugadoresArayList = club.listarJugadores();
	if(jugadoresArayList.Count  == 0){
		Console.WriteLine("La lista de jugadores esta vacia");
		return;
		
	}
	foreach(object item in jugadoresArayList){
		Jugador jugador = (Jugador)item;
		Console.Write("º.");
		jugador.imprimir();
		Console.WriteLine("----------------------------");
	}
	
}
//submenu2
static void listarEquiposEnCompetencia(Club club)
{
	ArrayList todosLosEquipos = club.listarEquipos();
	
		//reviso si esta vacio:
	if(todosLosEquipos.Count == 0){
		Console.WriteLine("**La lista esta vacia**");
		return;
	}
	foreach( object item in todosLosEquipos )
	{
		Equipo equipo = (Equipo)item;
		//reviso por cada equipo el estado de campaña
		if(equipo.EstadoDeCampania>0){
			Console.WriteLine("º. ");
			equipo.imprimir();
			Console.WriteLine("------------------------");
			
		}
	}
	
}
//submenu3
static void listarEquiposConCampaniaFin(Club club)
{
	ArrayList todosLosEquipos = club.listarEquipos();
		
	//reviso si esta vacio:
	if(todosLosEquipos.Count == 0){
		Console.WriteLine("**La lista esta vacia**");
		return;
	}
	foreach( object item in todosLosEquipos )
	{
		Equipo equipo = (Equipo)item;
		//reviso por cada equipo el estado de campaña
		if(equipo.EstadoDeCampania== 0.0){
			Console.WriteLine("º. ");
			equipo.imprimir();
			Console.WriteLine("------------------------");
		}
	}
	
}

//submenu4
static void listarEquiposTipoCopa(Club club){
	ArrayList todosLosEquipos = club.listarEquipos();
	
	
	if(todosLosEquipos.Count == 0){
		Console.WriteLine("**La lista esta vacia**");
		return;
		}
	foreach( object item in todosLosEquipos){
		Equipo equipo = (Equipo)item;
		
		if(equipo.TipoCompetencia.ToLower() == "copa"){
			Console.WriteLine("º. ");
			equipo.imprimir();
			Console.WriteLine("------------------------");
		}
	}
	
}
		
//submenu5
static void listarCapitanes(Club club)
{
	ArrayList  todosLosJugadores = club.listarJugadores();
	
	if(todosLosJugadores.Count  == 0){
		Console.WriteLine("La lista de Capitanes esta vacia");
		return;
		
	}
	foreach(object item in todosLosJugadores){
		if(item is Capitan){
			
			Capitan capitan = (Capitan)item;
			Console.WriteLine("º. ");
			capitan.imprimirCapitan();
			Console.WriteLine("------------------------");
		}
	}
	
}	
			
		
static void bajaDT(Club club)
{
	int dni = intValidoIngresado("Ingrese el dni del Director Tecnico : ");
	DirectorTecnico dtBaja = club.obtenerDtPorDni(dni);
	if( dtBaja != null){
		club.eliminarDt(dtBaja);
		Console.WriteLine("El director tecnico {0} {1} dado de baja de manera correcta ",dtBaja.Nombre, dtBaja.Apellido);
		Console.WriteLine("Baja finalizada");
	}else{
		Console.WriteLine("**El dni: {0} no encontrado**", dni );
	}
	
	
	
}
static void actualizarEstadoCampania(Club club)
{
	int codInter = intValidoIngresado("Ingrese el codigo intermo del Equipo a modificar: ");
	
	Equipo miEquipo = club.obtenerEquipoPorCod(codInter);
	if(miEquipo ==null){
		Console.WriteLine("**No se encontro ningun equipo con codigo interno: {0}",codInter);
		return;
				
	}
	double nuevoEstado = doubleValidoIngresado("Ingrese el nuevo estado del equipo: ");
	miEquipo.EstadoDeCampania = nuevoEstado;
	
	Console.WriteLine("Estado de campaña de {0} actualizado.", miEquipo.Nombre);
	Console.WriteLine(" Nuevo estado: {0}", miEquipo.EstadoDeCampania);
}
		

static int intValidoIngresado(string mensaje) 
{
    Console.Write(mensaje); 
    
    int valorInt = 0;
    bool valido = false;
    
    while (!valido)
    {
        try
        {
            string input = Console.ReadLine(); 
            valorInt = int.Parse(input);       
            valido = true;
            return valorInt;                   
        }
        catch (FormatException)
        {
            Console.WriteLine("*** Error: La entrada debe ser un número entero. ***");
            Console.Write(mensaje); 
        }
        catch (OverflowException)
        {
            Console.WriteLine("*** Error: El número ingresado es muy grande. ***");
            Console.Write(mensaje); 
        }
    }
    return valorInt; 
}
		

static double doubleValidoIngresado(string mensaje) 
{
    Console.Write(mensaje); 
    
    double valorDouble = 0;
    bool valido = false;
    
    while (!valido)
    {
        try
        {
            string input = Console.ReadLine(); 
            valorDouble = double.Parse(input);       
            valido = true;
            return valorDouble;                   
        }
        catch (FormatException)
        {
            Console.WriteLine("*** Error: La entrada debe ser un decimal ej: 199.0. ***");
            Console.Write(mensaje); 
        }
        catch (OverflowException)
        {
            Console.WriteLine("*** Error: El número ingresado es muy grande. ***");
            Console.Write(mensaje); 
        }
    }
    return valorDouble; 
}


		
			 
			
static void cargaInicial(Club club)
{
	
Grupo grupo_mañana = new Grupo(1);
Grupo grupo_tarde = new Grupo(2);
Grupo grupo_femenino = new Grupo(3);

club.agregarGrupo(grupo_mañana);
club.agregarGrupo(grupo_tarde);
club.agregarGrupo(grupo_femenino);


DirectorTecnico dt_principal = new DirectorTecnico("Horacio", "Morales", 43676527, 50000.0);
DirectorTecnico dt_reserva = new DirectorTecnico("Laura", "Gómez", 30987654, 45000.0);

club.agregarDirectorTecnico(dt_principal);
club.agregarDirectorTecnico(dt_reserva);

Equipo eq1 = new Equipo("Primera A", "Adultos", 200, "Liga", 90.0, dt_principal, 10000000.0, grupo_mañana);
Equipo eq2 = new Equipo("Reserva", "Sub 20", 201, "Liga", 5.0, dt_reserva, 4000000.0, grupo_tarde);
Equipo eq3 = new Equipo("Senior", "Veteranos", 202, "Copa", 0.0, dt_principal, 2000000.0, grupo_mañana);
Equipo eq4 = new Equipo("Femenino", "Adultas", 203, "Copa", 50.0, dt_reserva, 3000000.0, grupo_femenino);
Equipo eq5 = new Equipo("Juvenil B", "Sub 17", 204, "Torneo", 0.0, dt_reserva, 1500000.0, grupo_mañana);

club.agregarEquipo(eq1);
club.agregarEquipo(eq2);
club.agregarEquipo(eq3);
club.agregarEquipo(eq4);
club.agregarEquipo(eq5);


Jugador j1 = new Jugador("Lolo", "Martinez", 78545444, 25000.0, 6, "Arquero");
Jugador j2 = new Jugador("Juan", "Bodoque", 34212121, 30000.0, 7, "Mediocampista");
Jugador j3 = new Jugador("Tulio", "Lopez", 7567777, 35000.0, 5, "Delantero");
Jugador j4 = new Jugador("Enrriqueto", "Anacleto", 78545444, 788.0, 8, "Arquero");
Jugador j5 = new Jugador("Lucas", "Perez", 11111111, 25000.0, 10, "Arquero");
Jugador j6 = new Jugador("Maria", "Gomez", 22222222, 35000.0, 11, "Defensor");
Jugador j7 = new Jugador("Carlos", "Lopez", 33333333, 40000.0, 12, "Mediocampista");
Jugador j8 = new Jugador("Sofia", "Ruiz", 44444444, 30000.0, 13, "Delantero");
Jugador j9 = new Jugador("Pablo", "Silva", 55555555, 32000.0, 14, "Mediocampista");
Jugador j10 = new Jugador("Andres", "Vidal", 88888888, 28000.0, 17, "Arquero");
Jugador j11 = new Jugador("Lucia", "Castro", 99999999, 31000.0, 18, "Delantero");
Jugador j12 = new Jugador("Diego", "Alvarez", 10101010, 36000.0, 19, "Defensor");


Capitan c1 = new Capitan("Martina", "Diaz", 66666666, 50000.0, 15, "Defensor", 10.0, grupo_mañana);
Capitan c2 = new Capitan("Esteban", "Rojas", 77777777, 55000.0, 16, "Mediocampista", 15.0, grupo_tarde);


club.agregarJugador(j1); club.agregarJugador(j2); club.agregarJugador(j3); club.agregarJugador(j4); 
club.agregarJugador(j5); club.agregarJugador(j6); club.agregarJugador(j7); club.agregarJugador(j8); 
club.agregarJugador(j9); club.agregarJugador(j10); club.agregarJugador(j11); club.agregarJugador(j12);

club.agregarJugador(c1); club.agregarJugador(c2);
  



    Console.WriteLine("hecho.");
}


		

	}
}