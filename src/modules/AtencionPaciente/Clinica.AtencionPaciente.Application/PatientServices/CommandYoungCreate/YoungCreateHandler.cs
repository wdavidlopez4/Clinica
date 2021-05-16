using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate
{
    public class YoungCreateHandler : IRequestHandler<YoungCreate, YoungCreateDTO>
    {
        public Task<YoungCreateDTO> Handle(YoungCreate request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
