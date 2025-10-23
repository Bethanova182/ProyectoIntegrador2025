
using System;

namespace Proyecto_Integrador2025
{
	/// <summary>
	/// Description of Capitan.
	/// </summary>
	public class Capitan:Jugador
	{
		private double bonificacion;
		private Grupo grupoEntrenamiento;

		public Capitan(string nombre, string apellido, int dni, double sueldo, int numeroFicha, string posicion, double bonificacion, Grupo grupoEntrenamiento) : base(nombre, apellido, dni, sueldo, numeroFicha, posicion)
		{
			this.bonificacion = bonificacion;
			this.grupoEntrenamiento = grupoEntrenamiento;
		}
		
		public double Bonificacion {
			get { return bonificacion; }
			set { bonificacion = value; }
		}
		public Grupo GrupoEntrenamiento{
			get{return grupoEntrenamiento;}
			set{grupoEntrenamiento = value;}
		}
		public void imprimirCapitan() {
			double sueldoBase = this.Sueldo;
			double totalSueldo= sueldoBase+(sueldoBase*(this.Bonificacion)/100.0);
			Console.WriteLine("\nNombre: {0} {1}\nDNI: {2}\nGrupo de entrenamiento: {3}\nSueldo (Con bonificacion): {4}", nombre,
			                  apellido, dni, grupoEntrenamiento.Id, totalSueldo);
		}
		
	}
}
