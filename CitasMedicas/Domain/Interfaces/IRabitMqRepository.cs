using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitasMedicas.Infrastructure.Repository
{
    interface IRabitMqRepository
    {
        Task<bool> SendMessage(object message);
    }
}
