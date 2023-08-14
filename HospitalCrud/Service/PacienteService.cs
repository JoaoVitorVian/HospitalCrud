using HospitalCrud.Data;
using HospitalCrud.Entity;
using HospitalCrud.Service.interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace HospitalCrud.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly NavigationManager _navigationManager;

        public PacienteService(ApplicationDbContext context, NavigationManager navigationManager = null)
        {
            _context = context;
            _navigationManager = navigationManager;
        }

        public async Task<int> CriarFichaPaciente(Paciente pacienteDto, string base64Image)
        {
            var paciente = new Paciente
            {
                NomeCompleto = pacienteDto.NomeCompleto,
                FotoBase64 = base64Image,
                CPF = pacienteDto.CPF,
                NumeroCelular = pacienteDto.NumeroCelular,
                Endereco = pacienteDto.Endereco
            };

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente.Id;
        }

        public async Task DeletarFichaPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                throw new Exception("Paciente não encontrado. :/");

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<Paciente> ObterFichaPorId(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                throw new Exception("Paciente não encontrado. :/");

            return paciente;
        }

        public async Task<List<Paciente>> ListarFichasPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task AtualizarFichaPaciente(Paciente paciente, string base64Image)
        {
            var dbPaciente = await _context.Pacientes.FindAsync(paciente.Id);
            if (dbPaciente == null)
                throw new Exception("Paciente não encontrado. :/");

            dbPaciente.NomeCompleto = paciente.NomeCompleto;

            if (!string.IsNullOrEmpty(base64Image))
            {
                dbPaciente.FotoBase64 = base64Image;
            }

            dbPaciente.CPF = paciente.CPF;
            dbPaciente.NumeroCelular = paciente.NumeroCelular;
            dbPaciente.Endereco = paciente.Endereco;

            await _context.SaveChangesAsync();
        }
    }
}
