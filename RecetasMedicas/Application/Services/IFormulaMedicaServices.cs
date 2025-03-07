using RecetasMedicas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasMedicas.Application.Services
{
    public interface IFormulaMedicaServices
    {
        Task<List<FormulaMedica>> GetAllFormulasMedicas();
        Task<FormulaMedica> GetById(int id);
        Task<FormulaMedica> GetByCodigoRecetaAsync(string codigoReceta);
        Task<bool> UpdateByCodigoRecetaAsync(string codigoReceta, FormulaMedica updatedFormula);
        Task<bool> AddFormulaMedicaAsync(FormulaMedica formulaMedica);
        Task<bool> DeleteByCodigoRecetaAsync(string codigoReceta);
    }
}
