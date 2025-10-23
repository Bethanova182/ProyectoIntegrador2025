/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 13/10/2025
 * Time: 1:20 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto_Integrador2025
{

		public class Jugador:Persona
		{
		private int numeroFicha;
		private string posicion;
		//constructor
		public Jugador(string nombre, string apellido, int dni, double sueldo, int numeroFicha, string posicion) : base(nombre, apellido, dni, sueldo){
			this.numeroFicha = numeroFicha;
			this.posicion = posicion;
				
		}
		public int NumeroFicha {
			get { return numeroFicha; }
			set { numeroFicha = value; }
		}
		public string Posicion{
			get { return posicion; }
			set {posicion = value; }
		}
		public void imprimir() {
			Console.WriteLine("\nNombre: {0} {1}\nDNI: {2}\nNumero de ficha: {3}\nSueldo: {4}\nPosicion: {5}", nombre, apellido, dni, numeroFicha, sueldo, posicion);
		}
		
	}
}
