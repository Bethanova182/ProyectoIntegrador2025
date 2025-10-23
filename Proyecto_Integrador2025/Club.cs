/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 13/10/2025
 * Time: 12:16 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Proyecto_Integrador2025
{
	/// <summary>
	/// Description of Club.
	/// </summary>
	public class Club
	{
		private ArrayList lista_Equipos = new ArrayList();
		private ArrayList lista_Grupos = new ArrayList();
		private ArrayList lista_Jugadores = new ArrayList();
		private ArrayList lista_Dts = new ArrayList();

		private string nombreClub;
		
		public Club(string nombreClub)
		{
			this.nombreClub= nombreClub;
		}
		
		public string NombreClub{
			get{ return nombreClub; }
			set{nombreClub = value; }
		}
	
		
		
		//Metodos de Equipos

		public void agregarEquipo(Equipo nuevoEquipo) { lista_Equipos.Add(nuevoEquipo); }
		public void eliminarEquipo(Equipo equipo){ lista_Equipos.Remove(equipo); }
		public bool existeEquipo(Equipo equipo){ return lista_Equipos.Contains(equipo); }
		public Equipo obtenerEquipoPosicion(int i){return (Equipo)lista_Equipos[i] ;}
		public int cantidadEquipos(){return lista_Equipos.Count; }
		public ArrayList listarEquipos(){ return lista_Equipos; }
		public Equipo obtenerEquipoPorCod(int cod){
			foreach(object item in lista_Equipos){
				Equipo e = (Equipo)item;
				if( e.CodInterno == cod){
					return e;
				}
			}
			return null;
		}
		
		//metodos de Grupos
		public void agregarGrupo(Grupo nuevoGrupo) { lista_Grupos.Add(nuevoGrupo); }
		public void eliminarGrupo(Grupo grupo){ lista_Grupos.Remove(grupo); }
		public bool existeGrupo(Grupo grupo){ return lista_Grupos.Contains(grupo); }
		public Grupo obtenerGrupoPosicion(int i){return (Grupo)lista_Grupos[i] ;}
		public int cantidadGrupos(){return lista_Grupos.Count; }
		public ArrayList listarGrupos(){ return lista_Grupos;}
		public Grupo obtenerGrupoPorId(int cod){
			foreach(object item in lista_Grupos){
				Grupo gru = (Grupo)item;
				if( gru.Id == cod){
					return gru;
				}
			}
			return null;
		}
		
		//Metodos Jugadores
		public void agregarJugador(Jugador nuevoJugador) { lista_Jugadores.Add(nuevoJugador); }
		public void eliminarJugador(Jugador jugador){ lista_Jugadores.Remove(jugador); }
		public bool existeJugador(Jugador jugador){ return lista_Jugadores.Contains(jugador); }
		public Jugador obtenerJugadorPosicion(int i){return (Jugador)lista_Jugadores[i]; }
		public Jugador obtenerJugadorPorFicha(int numeroficha){
			foreach(object item in lista_Jugadores){//recorro la lista con un foreach objeto por objeto
				
				Jugador j = (Jugador)item; //casteo el objeto a un jugador
				if(j.NumeroFicha == numeroficha){ //comparo si son iguales
					return j;}
				}	
				return null;
		}
		public int cantidadJugadores(){return lista_Jugadores.Count; }
		public ArrayList listarJugadores(){ return lista_Jugadores; }
		
		//Director tecnico aca debo gregar algunos metodos para administrar esta clase
		
		
		public void agregarDirectorTecnico(DirectorTecnico dt){lista_Dts.Add(dt);}
		public void eliminarDt(DirectorTecnico dt){lista_Dts.Remove(dt);}
		public bool existeDt(DirectorTecnico dt){ return lista_Dts.Contains(dt);}
		public DirectorTecnico obtenerDtPosicion(int i){ return (DirectorTecnico)lista_Dts[i];}
		public DirectorTecnico obtenerDtPorDni(int dni){
			foreach(object item in lista_Dts){
				DirectorTecnico dt =(DirectorTecnico)item;
				if(dt.Dni == dni){
					return dt;
				}
				
			}
			return null;
		}
	}

	
}
