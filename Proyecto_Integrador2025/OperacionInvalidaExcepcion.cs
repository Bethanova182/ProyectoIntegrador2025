/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 22/10/2025
 * Time: 7:50 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto_Integrador2025
{
	/// <summary>
	/// Description of OperacionInvalidaExcepcion.
	/// </summary>
	public class OperacionInvalidaExcepcion : Exception
	{
		public OperacionInvalidaExcepcion(string mensaje): base(mensaje)
		{
		}
	}
}
