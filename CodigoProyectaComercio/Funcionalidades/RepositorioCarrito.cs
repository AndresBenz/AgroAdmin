using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Funcionalidades
{
    public class RepositorioCarrito
    {
        public List<ItemCarrito> Items { get; set; }

        public RepositorioCarrito()
        {
            Items = new List<ItemCarrito>();
        }

        public void AgregarProducto(Producto producto)
        {
           
            var itemExistente = Items.FirstOrDefault(i => i.Producto.IdProducto == producto.IdProducto);

            if (itemExistente != null)
            {
               
                itemExistente.Cantidad++;
            }
            else
            {
                
                Items.Add(new ItemCarrito
                {
                    Producto = producto,
                    Cantidad = 1 
                });
            }
        }

        public void LimpiarCarrito()
        {
            Items.Clear();
        }

        public decimal ObtenerTotal()
        {
            return Items.Sum(item => item.Producto.Precio * item.Cantidad);
        }
    }

    public class ItemCarrito
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
