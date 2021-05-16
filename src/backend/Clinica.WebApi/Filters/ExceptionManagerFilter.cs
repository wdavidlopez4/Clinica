using Clinica.AtencionPaciente.Application.Execptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.WebApi.Filters
{
    public class ExceptionManagerFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ExceptionManagerFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EdadException)
            {
                context.Result = new JsonResult($"error de edad de paciente en: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if (context.Exception is EntityNullException)
            {
                context.Result = new JsonResult($"error de entidad, la entidad no existe: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if (context.Exception is ArgumentNullException)
            {
                context.Result = new JsonResult($"error de argumnete es nulo o vacio: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
            else if (context.Exception is ArgumentException)
            {
                context.Result = new JsonResult($"error de argumentos los datos son erroneos: {this.webHostEnvironment.ApplicationName} " +
                    $"tipo exepcion: {context.Exception.GetType()} exepcion: {context.Exception.Message}");
            }
        }
    }
}
