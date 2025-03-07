using RecetasMedicas.Domain.Entities;
using RecetasMedicas.Domain.Interfaces;
using RecetasMedicas.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RecetasMedicas.Application.Services
{
    public class FormulaMedicaServices : IFormulaMedicaServices
    {
        private readonly IFormulaMedicaRepository formulaMedicaRepository;

        public FormulaMedicaServices(IFormulaMedicaRepository formulaMedicaRepository)
        {
            this.formulaMedicaRepository = formulaMedicaRepository;
        }

        public async Task<List<FormulaMedica>> GetAllFormulasMedicas()
        {
            return await formulaMedicaRepository.GetAll();
        }
        public async Task<FormulaMedica> GetById(int id)
        {
            return await formulaMedicaRepository.GetById(id);
        }
        public async Task<FormulaMedica> GetByCodigoRecetaAsync(string codigoReceta)
        {
            return await formulaMedicaRepository.GetByCodigoRecetaAsync(codigoReceta);
        }
        public async Task<bool> UpdateByCodigoRecetaAsync(string codigoReceta, FormulaMedica updatedFormula)
        {
            var existingFormula = await formulaMedicaRepository.GetByCodigoRecetaAsync(codigoReceta);
            if (existingFormula == null)
            {
                return false;
            }

            existingFormula.FechaEmision = updatedFormula.FechaEmision;
            existingFormula.FechaVencimiento = updatedFormula.FechaVencimiento;
            existingFormula.Estado = updatedFormula.Estado;
            existingFormula.IdPaciente = updatedFormula.IdPaciente;

            await formulaMedicaRepository.UpdateAsync(existingFormula);
            return true;
        }
        public async Task<bool> AddFormulaMedicaAsync(FormulaMedica formulaMedica)
        {
            return await formulaMedicaRepository.AddFormulaMedicaAsync(formulaMedica);
        }
        public async Task<bool> DeleteByCodigoRecetaAsync(string codigoReceta)
        {
            return await formulaMedicaRepository.DeleteByCodigoRecetaAsync(codigoReceta);
        }


        public async Task CrearRecetaAsync(FormulaMedica receta)
        {
            await formulaMedicaRepository.AddFormulaMedicaAsync(receta);
        }

    }
}