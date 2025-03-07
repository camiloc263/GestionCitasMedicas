using RecetasMedicas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasMedicas.Domain.Interfaces
{
    public interface IFormulaMedicaRepository
    {
        Task<List<Entities.FormulaMedica>> GetAll();
        Task<FormulaMedica> GetById(int id);
        Task<FormulaMedica> GetByCodigoRecetaAsync(string codigoReceta);
        Task UpdateAsync(FormulaMedica formulaMedica);
        Task<bool> AddFormulaMedicaAsync(FormulaMedica formulaMedica);
        Task<bool> DeleteByCodigoRecetaAsync(string codigoReceta);
        

    }
}
