/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 22/10/2025
 * Time: 6:09 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Proyecto_Integrador2025
{

	public class NoHayGrupoLibreExcepcion : Exception
	{
		public NoHayGrupoLibreExcepcion(string mensaje): base(mensaje)
		{
			
		}
	}
}
