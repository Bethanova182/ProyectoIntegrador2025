
using System;

namespace Proyecto_Integrador2025
{
	/// <summary>
	/// Description of DirectorTecnico.
	/// </summary>
	public class DirectorTecnico : Persona
	{
		private Equipo equipoAsignado;
		
		public DirectorTecnico(string nombre, string apellido, int dni, double sueldo) : base(nombre, apellido, dni, sueldo)
		{
		
		}
		public Equipo Equipo{
			get{return equipoAsignado;}
			set{equipoAsignado =value;				
				if (equipoAsignado == null)
					return;}
			}
		public void imprimir(){
			
		Console.WriteLine("\nNombre: {0} {1}\nDNI: {2}\nSueldo: {3}\nNombre de equipo: {4}", nombre, apellido, dni, equipoAsignado.Nombre);
		}
	}
	
	
}
