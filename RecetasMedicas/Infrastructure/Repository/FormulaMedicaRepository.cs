using RecetasMedicas.Domain.Entities;
using RecetasMedicas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace RecetasMedicas.Infrastructure.Repository
{
	public class FormulaMedicaRepository: IFormulaMedicaRepository
    {
        private readonly FormulaMedicaContext context;

        public FormulaMedicaRepository(FormulaMedicaContext context)
        {
            this.context = context;
        }
         
        
        public async Task<List<FormulaMedica>> GetAll()
        {
            return await context.RecetaMedica.ToListAsync(); 
        }

        public async Task<FormulaMedica> GetById(int id)
        {
            return await context.RecetaMedica.FindAsync(id);
        }
        public async Task Update(FormulaMedica formulaMedica) 
        {
            context.Entry(formulaMedica).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<FormulaMedica> GetByCodigoRecetaAsync(string codigoReceta)
        {
            return await context.RecetaMedica
                .FirstOrDefaultAsync(r => r.CodigoReceta == codigoReceta);
        }
        public async Task UpdateAsync(FormulaMedica formulaMedica)
        {
            context.Entry(formulaMedica).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<bool> AddFormulaMedicaAsync(FormulaMedica formulaMedica)
        {
            context.RecetaMedica.Add(formulaMedica); 
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteByCodigoRecetaAsync(string codigoReceta)
        {
            var formula = await context.RecetaMedica.FirstOrDefaultAsync(f => f.CodigoReceta == codigoReceta);
            if (formula == null) return false;

            context.RecetaMedica.Remove(formula);
            return await context.SaveChangesAsync() > 0;
        }

    }
}