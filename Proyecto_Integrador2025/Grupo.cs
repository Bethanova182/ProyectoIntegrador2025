/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 13/10/2025
 * Time: 12:17 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Proyecto_Integrador2025
{
	/// <summary>
	/// Description of Grupo.
	/// </summary>
	public class Grupo
	{
		private static int cantGrupos = 0;
		private int id;
		private int codEquipo;	
		private ArrayList grupoIntegrantes = new ArrayList();
	
		public Grupo( int codEquipo)
		{
			cantGrupos++;
			this.id = cantGrupos;
			this.codEquipo = codEquipo;
		}
		public int Id {
			get { return id; }
		}
		public int CodEquipo {
			get { return codEquipo; }
			set { codEquipo = value; }
		}
		public void agregarJugador(Jugador nuevoIntegrante ) { grupoIntegrantes.Add(nuevoIntegrante); }
		public void eliminarJugador(Jugador jugador){ grupoIntegrantes.Remove(jugador); }
		public bool existeJugador(Jugador jugador){ return grupoIntegrantes.Contains(jugador); }
		public Jugador obtenerJugadorPosicion(int i){return (Jugador)grupoIntegrantes[i]; }
		public int cantidadJugadores(){return grupoIntegrantes.Count; }
		public ArrayList listarJugadores(){ return grupoIntegrantes; }
	}
}
