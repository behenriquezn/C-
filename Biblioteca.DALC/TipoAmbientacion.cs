
//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Biblioteca.DALC
{

using System;
    using System.Collections.Generic;
    
public partial class TipoAmbientacion
{

    public TipoAmbientacion()
    {

        this.Cenas = new HashSet<Cenas>();

        this.Cocktail = new HashSet<Cocktail>();

    }


    public int IdTipoAmbientacion { get; set; }

    public string Descripcion { get; set; }



    public virtual ICollection<Cenas> Cenas { get; set; }

    public virtual ICollection<Cocktail> Cocktail { get; set; }

}

}
