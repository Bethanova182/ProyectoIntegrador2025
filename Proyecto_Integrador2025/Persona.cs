/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 13/10/2025
 * Time: 12:15 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto_Integrador2025
{
	public class Persona
{
    protected string nombre,apellido;
    protected int dni;
    protected double sueldo;
    //Constructor
    public Persona(string nombre, string apellido, int dni, double sueldo)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.dni = dni;
        this.sueldo = sueldo;
    }
    //Propiedades
    public string Nombre {
		get { return nombre; }
		set { nombre = value; }
	}
    public string Apellido {
		get { return apellido; }
		set { apellido = value; }
	}
    public int Dni {
		get { return dni; }
		set { dni = value; }
	}
    	public double Sueldo {
		get { return sueldo; }
		set { sueldo = value; }
	}
    

}

	
}
