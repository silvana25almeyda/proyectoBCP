﻿using BCP.Optimizacion.Domain.Entity;
using BCP.Optimizacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Contract
{
    public interface IServiceSale
    {
        Task<GenericResponse<SaleResponse>> crearVenta(SaleRequest saleRequest);
    }
}
