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
	/// Description of Equipo.
	/// </summary>
	public class Equipo
	{
		 private string nombre, categoria, tipoCompetencia;
		 private static int nextCodInterno = 1;
		 private int codInterno;
		 private double estadoDeCampania, presupuesto;
		 private DirectorTecnico dt;    	 
    	 private Grupo grupoEntrenamiento;
    	 
		public Equipo(string nombre, string categoria, string tipoCompetencia, double estadoDeCampania, DirectorTecnico dt, double presupuesto, Grupo nuevoGrupo)
		{
			this.nombre = nombre;
			this.categoria = categoria;
			this.codInterno = nextCodInterno;
			nextCodInterno++;
			this.tipoCompetencia = tipoCompetencia;
			this.estadoDeCampania = estadoDeCampania;
			this.dt = dt;
			this.presupuesto = presupuesto;
			this.grupoEntrenamiento = nuevoGrupo;
		}
		public string Nombre{
			get{return nombre;}
			set{nombre = value;}
		}
		public string Categoria{
			get{return categoria;}
			set{categoria = value;}
		}
		public string TipoCompetencia{
			get{ return tipoCompetencia;}
			set{tipoCompetencia = value;}
		}
		public int CodInterno{
			get{ return codInterno;}
			//set{codInterno = value;}
		}
		public double EstadoDeCampania{
			get{return estadoDeCampania;}
			set{estadoDeCampania = value;}
		}
		public double Presupuesto{
			get{return presupuesto;}
			set{presupuesto = value;}
		}
		public DirectorTecnico DT{
			get{return dt;}
			set{dt = value;}
		}
		public Grupo GrupoEntrenamiento{
			get{return grupoEntrenamiento;}
			set{grupoEntrenamiento = value;}
		}
		public void imprimir(){
        	Console.WriteLine("Equipo");
        	Console.WriteLine("Código Interno: {0}", codInterno);
        	Console.WriteLine("Nombre: {0}", nombre);
        	Console.WriteLine("Categoria: {0}",categoria);
        	Console.WriteLine("Estado de campaña: {0}", estadoDeCampania);
        	Console.WriteLine("Director Tecnico: {0} {1}  ", dt.Nombre, dt.Apellido);
        	Console.WriteLine("Grupo de entrenamiento: {0}", grupoEntrenamiento.Id);
        	                  
        }
	
	}
}
