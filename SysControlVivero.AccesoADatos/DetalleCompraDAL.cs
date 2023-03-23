﻿using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.AccesoADatos
{
    public class DetalleCompraDAL
    {
        public static async Task<int> CrearAsync(DetalleCompra pCompras)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCompras);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(DetalleCompra pCompras)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detallecompra = await bdContexto.DetalleCompra.FirstOrDefaultAsync(s => s.IdCompras == pCompras.IdCompras);
                detallecompra.NombreEmpresa = pCompras.NombreEmpresa;
                bdContexto.Update(detallecompra);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(DetalleCompra pCompras)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detallecompra = await bdContexto.DetalleCompra.FirstOrDefaultAsync(s => s.IdCompras == pCompras.IdCompras);
                bdContexto.DetalleCompra.Remove(detallecompra);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<DetalleCompra> ObtenerPorIdAsync(DetalleCompra pCompras)
        {
            var detallecompra = new DetalleCompra();
            using (var bdContexto = new BDContexto())
            {
                detallecompra = await bdContexto.DetalleCompra.FirstOrDefaultAsync(s => s.IdCompras == pCompras.IdCompras);
            }
            return detallecompra;
        }
        public static async Task<List<DetalleCompra>> ObtenerTodosAsync()
        {
            var detallecompras = new List<DetalleCompra>();
            using (var bdContexto = new BDContexto())
            {
                detallecompras = await bdContexto.DetalleCompra.ToListAsync();
            }
            return detallecompras;
        }
    }
}
